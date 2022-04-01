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
    public class AderenteService : BaseService, IAderenteService
    {
        private readonly IAderenteRepository _repository;
        public event EventHandler<AderenteCreateEventArgs> CreateEventHandler;
        public event EventHandler<AderenteUpdateEventArgs> UpdateEventHandler;
        public event EventHandler<AderenteDeleteEventArgs> DeleteEventHandler;

        public AderenteService(IUnitOfWork uow, IAderenteRepository repository) : base(uow)
        {
            _repository = repository;
        }

        protected virtual void OnCreateEventEvent(AderenteCreateEventArgs e)
        {
            CreateEventHandler?.Invoke(this, e);
        }

        protected virtual void OnUpdateEvent(AderenteUpdateEventArgs e)
        {
            UpdateEventHandler?.Invoke(this, e);
        }

        protected virtual void OnDeleteEvent(AderenteDeleteEventArgs e)
        {
            DeleteEventHandler?.Invoke(this, e);
        }

        public AderenteCreateCommandResult Create(AderenteCreateCommand command)
        {
            var model = command.ToModel();

            var erros = model.CreateValidate();

            if (erros.Count == 0)
            {
                _repository.Create(model);
                Commit();

                OnCreateEventEvent(new AderenteCreateEventArgs { });
            }

            return new AderenteCreateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }

        public AderenteDeleteCommandResult Delete(AderenteDeleteCommand command)
        {
            var erros = new List<string>();

            try
            {
                var model = _repository.GetById(command.Id);

                if (erros.Count == 0)
                {
                    _repository.Delete(model);

                    Commit();

                    OnDeleteEvent(new AderenteDeleteEventArgs { });
                }
            }
            catch (DbUpdateException ex)
            {
                erros.Add("Aderente não pode ser excluído.");
            }
            catch (Exception ex)
            {
                erros.Add(ex.Message);
            }

            return new AderenteDeleteCommandResult
            {
                Errors = erros
            };
        }

        public AderenteUpdateCommandResult Update(AderenteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model = command.ToModel(model);

            var erros = model.UpdateValidate();

            if (erros.Count == 0)
            {
                _repository.Update(model);
                Commit();

                OnUpdateEvent(new AderenteUpdateEventArgs { });
            }

            return new AderenteUpdateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }

        public AderenteUpdateCommandResult UpdateNome(AderenteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Nome = command.Nome;

            return Update(model);
        }
        public AderenteUpdateCommandResult UpdateCnpj(AderenteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Cnpj = command.Cnpj;

            return Update(model);
        }
        public AderenteUpdateCommandResult UpdateCampanhaId(AderenteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.EmpresaId = command.EmpresaId;

            return Update(model);
        }


        private AderenteUpdateCommandResult Update(Aderente model)
        {
            var erros = model.UpdateValidate();

            if (erros.Count == 0)
            {
                _repository.Update(model);
                Commit();
            }

            return new AderenteUpdateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }

        public List<Aderente> GetAll()
        {
            return _repository.GetAll();
        }

        public Aderente GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Aderente> GetByCampanha(int campanhaId)
        {
            return _repository.GetByCampanha(campanhaId);
        }

        public bool IsAssociadoCampanha(string cnpj)
        {
            return _repository.IsAssociadoCampanha(cnpj);
        }
    

        public List<Aderente> GetAll(int? empresaId, string nome, int start, int limit, out int total)
        {
            return _repository.GetAll(empresaId, nome, start, limit, out total);
        }
    }
}
