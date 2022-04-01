using Microsoft.EntityFrameworkCore;
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

namespace Prombox.Service.Services
{
    public class EmpresasService : BaseService, IEmpresasService
    {
        private readonly IEmpresasRepository _repository;
        public event EventHandler<EmpresasCreateEventArgs> CreateEventHandler;
        public event EventHandler<EmpresasUpdateEventArgs> UpdateEventHandler;
        public event EventHandler<EmpresasDeleteEventArgs> DeleteEventHandler;

        public EmpresasService(IUnitOfWork uow, IEmpresasRepository repository) : base(uow)
        {
            _repository = repository;
        }

        protected virtual void OnCreateEventEvent(EmpresasCreateEventArgs e)
        {
            CreateEventHandler?.Invoke(this, e);
        }

        protected virtual void OnUpdateEvent(EmpresasUpdateEventArgs e)
        {
            UpdateEventHandler?.Invoke(this, e);
        }

        protected virtual void OnDeleteEvent(EmpresasDeleteEventArgs e)
        {
            DeleteEventHandler?.Invoke(this, e);
        }

        public EmpresaCreateCommandResult Create(EmpresaCreateCommand command)
        {
            var model = command.ToModel();

            var erros = model.CreateValidate();

            if (erros.Count == 0)
            {
                var existeCnpj = _repository.ExixtsCnpf(model.Id, model.Cnpj);
                if (existeCnpj) erros.Add(string.Format("O CNPJ {0} já foi cadastrado.", model.Cnpj));
                if (!existeCnpj)
                {
                    _repository.Create(model);
                    Commit();

                    OnCreateEventEvent(new EmpresasCreateEventArgs { });
                }
            }

            return new EmpresaCreateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }

        public EmpresaDeleteCommandResult Delete(EmpresaDeleteCommand command)
        {
            var erros = new List<string>();

            try
            {
                var model = _repository.GetById(command.Id);

                if (erros.Count == 0)
                {
                    _repository.Delete(model);
                    Commit();

                    OnDeleteEvent(new EmpresasDeleteEventArgs { });
                }
            }
            catch (DbUpdateException ex)
            {
                erros.Add("A empresa não pode ser excluída.");
            }
            catch (Exception ex)
            {
                erros.Add(ex.Message);
            }

            return new EmpresaDeleteCommandResult
            {
                Errors = erros
            };
        }

        public EmpresaUpdateCommandResult Update(EmpresaUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model = command.ToModel(model);

            var erros = model.UpdateValidate();

            if (erros.Count == 0)
            {
                var existeCnpj = _repository.ExixtsCnpf(model.Id, model.Cnpj);
                if (existeCnpj) erros.Add(string.Format("O CNPJ {0} já foi cadastrado.", model.Cnpj));
                if (!existeCnpj)
                {
                    _repository.Update(model);
                    Commit();

                    OnUpdateEvent(new EmpresasUpdateEventArgs { });
                }
            }

            return new EmpresaUpdateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }       

        public EmpresaUpdateCommandResult UpdateAtiva(EmpresaUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Ativa = command.Ativa;

            return Update(model);
        }
        public EmpresaUpdateCommandResult UpdateRazaoSocial(EmpresaUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.RazaoSocial = command.RazaoSocial;

            return Update(model);
        }
        public EmpresaUpdateCommandResult UpdateNomeFantasia(EmpresaUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.NomeFantasia = command.NomeFantasia;

            return Update(model);
        }
        public EmpresaUpdateCommandResult UpdateCnpj(EmpresaUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Cnpj = command.Cnpj;

            return Update(model);
        }
        public EmpresaUpdateCommandResult UpdateTelefone(EmpresaUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Telefone = command.Telefone;

            return Update(model);
        }
        public EmpresaUpdateCommandResult UpdateInscricaoMunicipal(EmpresaUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.InscricaoMunicipal = command.InscricaoMunicipal;

            return Update(model);
        }
        public EmpresaUpdateCommandResult UpdateUrlSite(EmpresaUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.UrlSite = command.UrlSite;

            return Update(model);
        }
        public EmpresaUpdateCommandResult UpdateCep(EmpresaUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Cep = command.Cep;

            return Update(model);
        }
        public EmpresaUpdateCommandResult UpdateLogradouro(EmpresaUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Logradouro = command.Logradouro;

            return Update(model);
        }
        public EmpresaUpdateCommandResult UpdateNumero(EmpresaUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Numero = command.Numero;

            return Update(model);
        }
        public EmpresaUpdateCommandResult UpdateComplemento(EmpresaUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Complemento = command.Complemento;

            return Update(model);
        }
        public EmpresaUpdateCommandResult UpdateBairro(EmpresaUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Bairro = command.Bairro;

            return Update(model);
        }
        public EmpresaUpdateCommandResult UpdateCidade(EmpresaUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Cidade = command.Cidade;

            return Update(model);
        }
        public EmpresaUpdateCommandResult UpdateUf(EmpresaUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Uf = command.Uf;

            return Update(model);
        }
        public EmpresaUpdateCommandResult UpdateObservacoes(EmpresaUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Observacoes = command.Observacoes;

            return Update(model);
        }
        public EmpresaUpdateCommandResult UpdateUrlFacebook(EmpresaUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.UrlFacebook = command.UrlFacebook;

            return Update(model);
        }
        public EmpresaUpdateCommandResult UpdateUrlTwitter(EmpresaUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.UrlTwitter = command.UrlTwitter;

            return Update(model);
        }
        public EmpresaUpdateCommandResult UpdateUrlInstagram(EmpresaUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.UrlInstagram = command.UrlInstagram;

            return Update(model);
        }
        public EmpresaUpdateCommandResult UpdateUrlYoutube(EmpresaUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.UrlYoutube = command.UrlYoutube;

            return Update(model);
        }
        public EmpresaUpdateCommandResult UpdateUrlLinkedin(EmpresaUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.UrlLinkedin = command.UrlLinkedin;

            return Update(model);
        }
        public EmpresaUpdateCommandResult UpdateCnpjFaturamento(EmpresaUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.CnpjFaturamento = command.CnpjFaturamento;

            return Update(model);
        }
        public EmpresaUpdateCommandResult UpdatePrecisaOrdemCompra(EmpresaUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.PrecisaOrdemCompra = command.PrecisaOrdemCompra;

            return Update(model);
        }
        public EmpresaUpdateCommandResult UpdateRazaoSocialFaturamento(EmpresaUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.RazaoSocialFaturamento = command.RazaoSocialFaturamento;

            return Update(model);
        }
       
        private EmpresaUpdateCommandResult Update(Empresa model)
        {
            var erros = model.UpdateValidate();

            if (erros.Count == 0)
            {
                _repository.Update(model);
                Commit();
            }

            return new EmpresaUpdateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }

        public List<Empresa> GetAll()
        {
            return _repository.GetAll();
        }

        public Empresa GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Empresa> GetAll(string nome, int start, int limit, out int total)
        {
            return _repository.GetAll(nome, start, limit, out total);
        }
    }
}
