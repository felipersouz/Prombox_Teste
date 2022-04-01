using Prombox.Domain.Commands;
using Prombox.Domain.Commands.Results;
using Prombox.Domain.Entities;
using Prombox.Domain.Repositories;
using Prombox.Domain.Scopes;
using Prombox.Domain.Services;
using Prombox.Infra.Transaction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Prombox.Service.Services
{
    public class NotasFiscaisService : BaseService, INotasFiscaisService
    {
        private readonly INotasFiscaisRepository _repository;
        private readonly ICampanhasService _campanhaService;
        private readonly IAderenteService _aderenteService;
        private readonly INumeroDaSorteService _numeroDaSorteService;        
        private readonly IUsuariosClientesService _usuarioClienteService;
        private readonly IClienteCampanhaService _clienteCampanhaService;

        public event EventHandler<NotasFiscaisCreateEventArgs> CreateEventHandler;
        public event EventHandler<NotasFiscaisUpdateEventArgs> UpdateEventHandler;
        public event EventHandler<NotasFiscaisDeleteEventArgs> DeleteEventHandler;

        public NotasFiscaisService(IUnitOfWork uow, 
            INotasFiscaisRepository repository,
            ICampanhasService campanhaService,
            IAderenteService aderenteService,
            INumeroDaSorteService numeroDaSorteService,
            IUsuariosClientesService usuarioClienteService,
            IClienteCampanhaService clienteCampanhaService
            ) : base(uow)
        {
            _aderenteService = aderenteService;
            _campanhaService = campanhaService;
            _repository = repository;
            _numeroDaSorteService = numeroDaSorteService;
            _usuarioClienteService = usuarioClienteService;
            _clienteCampanhaService = clienteCampanhaService;
        }

        protected virtual void OnCreateEventEvent(NotasFiscaisCreateEventArgs e)
        {
            CreateEventHandler?.Invoke(this, e);
        }

        protected virtual void OnUpdateEvent(NotasFiscaisUpdateEventArgs e)
        {
            UpdateEventHandler?.Invoke(this, e);
        }

        protected virtual void OnDeleteEvent(NotasFiscaisDeleteEventArgs e)
        {
            DeleteEventHandler?.Invoke(this, e);
        }

        public NotaFiscalCreateCommandResult Create(NotaFiscalCreateCommand command)
        {
            try
            {                
                var model = command.ToModel();
                model.DataCadastro = DateTime.Now;
                var erros = model.CreateValidate();
                # region [ Regras de Negócio - Validações ]

                var campanha = _campanhaService.GetById(command.CampanhaId);
                var aderentes = _aderenteService.GetByCampanha(command.CampanhaId);
                var usuarioCliente = _usuarioClienteService.GetById(command.UsuarioClienteId);

                bool aderenteValido = _aderenteService.IsAssociadoCampanha(command.Cnpj);

                if(!aderenteValido)
                    erros.Add("O CNPJ da nota não está habilitado para esta campanha. Entre contato com o SAC.");

                if (_repository.GetByUsuarioClienteCampanhaCodigoNota(command.UsuarioClienteId, command.CampanhaId, command.Cod).Count>0)
                    erros.Add("Você já cadastrou uma nota com este mesmo código. Para correções entre em contato com o SAC");

                if (model.DataCompra> campanha.DataFinalPeriodoCompras.Date || model.DataCompra < campanha.DataInicioPeriodoCompras.Date)
                    erros.Add("Data da nota fora do período de compras");

                if (model.DataCompra.Date > DateTime.Now.Date)                
                    erros.Add("Data da nota inválida");                

                if (campanha.ValorLimiteNF.HasValue && model.ValorTotal > campanha.ValorLimiteNF.Value)
                    erros.Add("Para este valor de Nota, entre em contato com o SAC");

                #endregion [ Regras de Negócio - Validações ]

                // Se tem erros, para por aqui
                if (erros.Count>0)
                {
                    return new NotaFiscalCreateCommandResult
                    {
                        Errors = erros,
                        Model = null
                    };
                }

                #region [ Parte 1 - Extrai todos os números da sorte possíveis para a NF que está entrando ]

                List<NumeroDaSorte> numerosSorte = new List<NumeroDaSorte>();


                // Pega valor do número da sorte

                var qntNumerosGerar = (int) ( model.ValorTotal / campanha.ValorParaNumeroDaSorte);

                decimal valorUtilizado = 0;

                if (qntNumerosGerar ==0)
                {
                    // Se não consigo gerar um numero da sorte, só salvo como saldo
                    model.Saldo = model.ValorTotal;                    
                } else
                {
                    for (int i = 0 ; i< qntNumerosGerar ; i++)
                    {

                        var numeroSorte = _numeroDaSorteService.EscolherNumeroDaSorte(usuarioCliente.Cliente.Id, command.CampanhaId);
                        numerosSorte.Add(numeroSorte);                        
                    }

                    valorUtilizado += qntNumerosGerar * campanha.ValorParaNumeroDaSorte;
                    model.Saldo = model.ValorTotal - valorUtilizado;
                }

                // Insiro a Nota fiscal
                _repository.Create(model);
                Commit();                

                // Associo essa nota fiscal para cada NotaDetalhe
                foreach(var numeroSorte in numerosSorte)
                {
                    if (numeroSorte.Detalhes == null)
                        numeroSorte.Detalhes = new List<NumeroDaSorteDetalhe>();
                    NumeroDaSorteDetalhe detalhe = new NumeroDaSorteDetalhe();
                    detalhe.NotaFiscalId = model.Id;
                    detalhe.NumeroDaSorteId = numeroSorte.Id;
                    detalhe.ValorUtilizado = campanha.ValorParaNumeroDaSorte;

                    numeroSorte.Detalhes.Add(detalhe);
                    _numeroDaSorteService.CreateDetalhe(detalhe);
                }

                #endregion [ Parte 1 - Extrai todos os números da sorte possíveis para a NF que está entrando ]

                #region [ Parte 2 - Raspo o saldo de todas as notas e crio um eventual número da sorte ]

                var notasComSaldo = _repository.GetAllWithSaldo(model.UsuarioClienteId, model.CampanhaId);
                decimal valorTotal = 0;
                
                List<NumeroDaSorteDetalhe> numerosSorteDetalhes = new List<NumeroDaSorteDetalhe>();

                foreach(var nota in notasComSaldo)
                {                    
                    valorTotal += nota.Saldo;
                }

                // Se dá pra extrair um número da sorte do saldo
                if (valorTotal >= campanha.ValorParaNumeroDaSorte)
                {
                    decimal valorApoio = 0;

                    foreach (var nota in notasComSaldo)
                    {                        
                        valorApoio += nota.Saldo;
                        NumeroDaSorteDetalhe detalhe = new NumeroDaSorteDetalhe();
                        detalhe.NotaFiscalId = nota.Id;
                        detalhe.ValorUtilizado = nota.Saldo;

                        //Valido se devo parar o loop
                        if (valorApoio >= campanha.ValorParaNumeroDaSorte)
                        {
                            //Se chegou aqui é que passou ou igualou o valor e pode parar
                            nota.Saldo = valorApoio - campanha.ValorParaNumeroDaSorte;
                            detalhe.ValorUtilizado -= nota.Saldo;
                            numerosSorteDetalhes.Add(detalhe);


                            // Crio um novo número da sorte
                            var numeroSorte = _numeroDaSorteService.EscolherNumeroDaSorte(usuarioCliente.Cliente.Id, command.CampanhaId);
                            numeroSorte.Detalhes = numerosSorteDetalhes;

                            //Salva tudo e vaza
                            _numeroDaSorteService.Update(numeroSorte);

                            _repository.Update(nota);
                            Commit();

                            break; // sai do loop
                        } else
                        {
                            nota.Saldo = 0;
                            numerosSorteDetalhes.Add(detalhe);
                            _repository.Update(nota);
                            Commit();
                        }
                    }
                } 
                
                #endregion [ Parte 2 - Raspo o saldo de todas as notas e crio um eventual número da sorte ]

                return new NotaFiscalCreateCommandResult
                {
                    Errors = erros,
                    Model = null
                };
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public NotaFiscalDeleteCommandResult Delete(NotaFiscalDeleteCommand command)
        {
            var erros = new List<string>();

            try
            {
                var model = _repository.GetById(command.Id);

                if (erros.Count == 0)
                {
                    _repository.Delete(model);

                    Commit();

                    OnDeleteEvent(new NotasFiscaisDeleteEventArgs { });
                }
            }
            catch (Exception ex)
            {
                erros.Add(ex.Message);
                erros.Add(ex.StackTrace);
            }

            return new NotaFiscalDeleteCommandResult
            {
                Errors = erros
            };
        }
        public NotaFiscaUpdateCommandResult Update(NotaFiscalUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model = command.ToModel(model);

            var erros = model.UpdateValidate();

            if (erros.Count == 0)
            {
                _repository.Update(model);
                Commit();

                OnUpdateEvent(new NotasFiscaisUpdateEventArgs { });
            }

            return new NotaFiscaUpdateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }
        public NotaFiscaUpdateCommandResult UpdateData(NotaFiscalUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.DataCompra = command.Data;

            return Update(model);
        }
        public NotaFiscaUpdateCommandResult UpdateCod(NotaFiscalUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Cod = command.Cod;

            return Update(model);
        }
        public NotaFiscaUpdateCommandResult UpdateCnpj(NotaFiscalUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Cnpj = command.Cnpj;

            return Update(model);
        }
        public NotaFiscaUpdateCommandResult UpdateValorTotal(NotaFiscalUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.ValorTotal = command.ValorTotal;

            return Update(model);
        }

        private NotaFiscaUpdateCommandResult Update(NotaFiscal model)
        {
            var erros = model.UpdateValidate();

            if (erros.Count == 0)
            {
                _repository.Update(model);
                Commit();
            }

            return new NotaFiscaUpdateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }

        public List<NotaFiscal> GetAll()
        {
            return _repository.GetAll();
        }

        public List<NotaFiscal> GetByUsuarioClienteCampanha(long usuarioClienteId, int campanhaId)
        {
            return _repository.GetByUsuarioClienteCampanha(usuarioClienteId, campanhaId);
        }

        public NotaFiscal GetById(long id)
        {
            return _repository.GetById(id);
        }

        public decimal GetSaldo(long usuarioClienteId, int campanhaId)
        {
            return _repository.GetSaldo(usuarioClienteId, campanhaId);
        }

        public List<NotaFiscal> GetAll(int start, int limit, out int total)
        {
            return _repository.GetAll(start, limit, out total);
        }

        public decimal GetTotalNotasByUsuarioClienteCampanha(long usuarioClienteId, int campanhaId)
        {
            return _repository.GetTotalNotasByUsuarioClienteCampanha(usuarioClienteId, campanhaId);
        }

    }
}
