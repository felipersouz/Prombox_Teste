using Prombox.Domain.Commands;
using Prombox.Domain.Commands.Results;
using Prombox.Domain.Entities;
using Prombox.Domain.Repositories;
using Prombox.Domain.Scopes;
using Prombox.Domain.Services;
using Prombox.Infra.Transaction;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Prombox.Service.Services
{
    public class CampanhasService : BaseService, ICampanhasService
    {
        private readonly ICampanhasRepository _repository;
        private readonly IDuvidasFrequentesRepository _duvidasFrequentesRepository;
        private readonly ICampanhasLayoutRepository _campanhasLayoutRepository;

        public event EventHandler<CampanhasCreateEventArgs> CreateEventHandler;
        public event EventHandler<CampanhasUpdateEventArgs> UpdateEventHandler;
        public event EventHandler<CampanhasDeleteEventArgs> DeleteEventHandler;

        public CampanhasService(IUnitOfWork uow, ICampanhasRepository repository, IDuvidasFrequentesRepository duvidasFrequentesRepository, ICampanhasLayoutRepository campanhasLayoutRepository)
            : base(uow)
        {
            _repository = repository;
            _duvidasFrequentesRepository = duvidasFrequentesRepository;
            _campanhasLayoutRepository = campanhasLayoutRepository;
        }

        protected virtual void OnCreateEventEvent(CampanhasCreateEventArgs e)
        {
            CreateEventHandler?.Invoke(this, e);
        }

        protected virtual void OnUpdateEvent(CampanhasUpdateEventArgs e)
        {
            UpdateEventHandler?.Invoke(this, e);
        }

        protected virtual void OnDeleteEvent(CampanhasDeleteEventArgs e)
        {
            DeleteEventHandler?.Invoke(this, e);
        }

        public CampanhaCreateCommandResult Create(CampanhasCreateCommand command)
        {
            var model = command.ToModel();

            var erros = model.CreateValidate();

            if (erros.Count == 0)
            {
                var duvidasFrequentes = _duvidasFrequentesRepository.GetDefault();

                foreach (var x in duvidasFrequentes)
                {
                    model.DuvidasFrequentes.Add(new DuvidaFrequente
                    {
                        EmpresaId = model.EmpresaId,
                        Pergunta = x.Pergunta,
                        Resposta = x.Resposta,
                        Ordem = x.Ordem,
                    });
                }

                _repository.Create(model);
                Commit();

                OnCreateEventEvent(new CampanhasCreateEventArgs { });
            }

            return new CampanhaCreateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }

        public CampanhaDeleteCommandResult Delete(CampanhaDeleteCommand command)
        {
            var erros = new List<string>();

            try
            {
                var model = _repository.GetById(command.Id);

                if (erros.Count == 0)
                {
                    var campanhaLayout = _campanhasLayoutRepository.GetByCampanhaId(model.Id);
                    if (campanhaLayout != null) _campanhasLayoutRepository.Delete(campanhaLayout);

                    model.CampanhaAderentes.Clear();
                    _repository.Update(model);

                    _repository.Delete(model);

                    Commit();

                    OnDeleteEvent(new CampanhasDeleteEventArgs { });
                }
            }
            catch (DbUpdateException ex)
            {
                erros.Add("A campanha não pode ser excluída.");
            }
            catch (Exception ex)
            {
                erros.Add(ex.Message);
            }

            return new CampanhaDeleteCommandResult
            {
                Errors = erros
            };
        }

        public CampanhaUpdateCommandResult Update(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model = command.ToModel(model);

            var erros = model.UpdateValidate();

            if (erros.Count == 0)
            {
                _repository.Update(model);
                Commit();

                OnUpdateEvent(new CampanhasUpdateEventArgs { });
            }

            return new CampanhaUpdateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }

        public CommandResult UpdateAderentes(UpdateAderentesCommand command)
        {
            var model = _repository.GetById(command.CampanhaId);

            foreach (var aderente in command.Aderentes)
            {
                var exists = model.CampanhaAderentes.Any(x => x.AderenteId == aderente.Id);
                if (!exists) model.CampanhaAderentes.Add(new CampanhaAderente { CampanhaId = model.Id, AderenteId = aderente.Id });
            }

            for (int i = model.CampanhaAderentes.Count - 1; i >= 0; i--)
            {
                var index = i;
                var exists = command.Aderentes.Any(x => x.Id == model.CampanhaAderentes[index].AderenteId);
                if (!exists) model.CampanhaAderentes.RemoveAt(index);
            }

            _repository.Update(model);
            Commit();

            OnUpdateEvent(new CampanhasUpdateEventArgs { });

            return new CampanhaUpdateCommandResult
            {
                Errors = new List<string>(),
            };
        }


        public CampanhaUpdateCommandResult UpdateDataInicioCampanha(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.DataInicioCampanha = command.DataInicioCampanha;

            return Update(model);
        }
        public CampanhaUpdateCommandResult UpdateDataFinalCampanha(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.DataFinalCampanha = command.DataFinalCampanha;

            return Update(model);
        }
        public CampanhaUpdateCommandResult UpdateDataLimiteCadastro(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.DataLimiteCadastro = command.DataLimiteCadastro;

            return Update(model);
        }
        public CampanhaUpdateCommandResult UpdateDataInicioPeriodoCompras(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.DataInicioPeriodoCompras = command.DataInicioPeriodoCompras;

            return Update(model);
        }
        public CampanhaUpdateCommandResult UpdateDataFinalPeriodoCompras(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.DataFinalPeriodoCompras = command.DataFinalPeriodoCompras;

            return Update(model);
        }
        public CampanhaUpdateCommandResult UpdateDataSorteio(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.DataSorteio = command.DataSorteio;

            return Update(model);
        }
        public CampanhaUpdateCommandResult UpdateResumoRegulamento(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.ResumoRegulamento = command.ResumoRegulamento;

            return Update(model);
        }
        public CampanhaUpdateCommandResult UpdateCertificadoAutorizacao(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.CertificadoAutorizacao = command.CertificadoAutorizacao;

            return Update(model);
        }
        public CampanhaUpdateCommandResult UpdateEmailSac(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.EmailSac = command.EmailSac;

            return Update(model);
        }
        public CampanhaUpdateCommandResult UpdateTelefoneSac(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.TelefoneSac = command.TelefoneSac;

            return Update(model);
        }
        public CampanhaUpdateCommandResult UpdateEmpresaId(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.EmpresaId = command.EmpresaId;

            return Update(model);
        }
        public CampanhaUpdateCommandResult UpdateTipoCampanha(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.TipoCampanha = command.TipoCampanha;

            return Update(model);
        }
        public CampanhaUpdateCommandResult UpdateIsMaior18Anos(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.IsMaior18Anos = command.IsMaior18Anos;

            return Update(model);
        }
        public CampanhaUpdateCommandResult UpdateIsLimiteGeografico(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.IsLimiteGeografico = command.IsLimiteGeografico;

            return Update(model);
        }
        public CampanhaUpdateCommandResult UpdateEstado(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Estado = command.Estado;

            return Update(model);
        }
        public CampanhaUpdateCommandResult UpdateCidade(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Cidade = command.Cidade;

            return Update(model);
        }
        public CampanhaUpdateCommandResult UpdateBairro(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Bairro = command.Bairro;

            return Update(model);
        }
        public CampanhaUpdateCommandResult UpdateIsLimiteTrocasNf(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.IsLimiteTrocasNF = command.IsLimiteTrocasNF;

            return Update(model);
        }
        public CampanhaUpdateCommandResult UpdateValorLimiteNf(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.ValorLimiteNF = command.ValorLimiteNF;

            return Update(model);
        }
        public CampanhaUpdateCommandResult UpdateQuantidadeLimiteNf(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.QuantidadeLimiteNF = command.QuantidadeLimiteNF;

            return Update(model);
        }
        public CampanhaUpdateCommandResult UpdateIsLimiteGeneroSexual(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.IsLimiteGeneroSexual = command.IsLimiteGeneroSexual;

            return Update(model);
        }
        public CampanhaUpdateCommandResult UpdateGeneroSexual(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.GeneroSexual = command.GeneroSexual;

            return Update(model);
        }
        public CampanhaUpdateCommandResult UpdateIsBloquearFuncionario(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.IsBloquearFuncionario = command.IsBloquearFuncionario;

            return Update(model);
        }
        public CampanhaUpdateCommandResult UpdateRegraParticipacao(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.RegraParticipacao = command.RegraParticipacao;

            return Update(model);
        }

        public CampanhaUpdateCommandResult UpdateDataEnvioNF(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.DataEnvioNF = command.DataEnvioNF;

            return Update(model);
        }
        public CampanhaUpdateCommandResult UpdateDataVencimento(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.DataVencimento = command.DataVencimento;

            return Update(model);
        }



        private CampanhaUpdateCommandResult Update(Campanha model)
        {
            var erros = model.UpdateValidate();

            if (erros.Count == 0)
            {
                _repository.Update(model);
                Commit();
            }

            return new CampanhaUpdateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }

        public List<Campanha> GetAll(int empresaId)
        {
            return _repository.GetAll(empresaId);
        }

        public Campanha GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Campanha> GetAll(int? empresaId, string nome, int start, int limit, out int total)
        {
            return _repository.GetAll(empresaId, nome, start, limit, out total);
        }

        public CampanhaUpdateCommandResult UpdateUrlImagemGanhadores(CampanhasUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.UrlImagemGanhadores = command.UrlImagemGanhadores;

            return Update(model);
        }
    }
}
