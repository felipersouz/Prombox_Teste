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
    public class ContatosService : BaseService, IContatosService
    {
        private readonly IContatosRepository _repository;
        public event EventHandler<ContatosCreateEventArgs> CreateEventHandler;
        public event EventHandler<ContatosUpdateEventArgs> UpdateEventHandler;
        public event EventHandler<ContatosDeleteEventArgs> DeleteEventHandler;

        public ContatosService(IUnitOfWork uow, IContatosRepository repository) : base(uow)
        {
            _repository = repository;
        }

        protected virtual void OnCreateEventEvent(ContatosCreateEventArgs e)
        {
            CreateEventHandler?.Invoke(this, e);
        }

        protected virtual void OnUpdateEvent(ContatosUpdateEventArgs e)
        {
            UpdateEventHandler?.Invoke(this, e);
        }

        protected virtual void OnDeleteEvent(ContatosDeleteEventArgs e)
        {
            DeleteEventHandler?.Invoke(this, e);
        }

        public ContatosCreateCommandResult Create(ContatosCreateCommand command)
        {
            var model = command.ToModel();

            var erros = model.CreateValidate();

            if (erros.Count == 0)
            {
                _repository.Create(model);
                Commit();

                OnCreateEventEvent(new ContatosCreateEventArgs { });
            }

            return new ContatosCreateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }

        public ContatosDeleteCommandResult Delete(ContatosDeleteCommand command)
        {
            var erros = new List<string>();

            try
            {
                var model = _repository.GetById(command.Id);

                if (erros.Count == 0)
                {
                    _repository.Delete(model);

                    Commit();

                    OnDeleteEvent(new ContatosDeleteEventArgs { });
                }
            }
            catch (DbUpdateException ex)
            {
                erros.Add("O contato não pode ser excluído.");
            }
            catch (Exception ex)
            {
                erros.Add(ex.Message);
            }

            return new ContatosDeleteCommandResult
            {
                Errors = erros
            };
        }

        public ContatosUpdateCommandResult Update(ContatosUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model = command.ToModel(model);

            var erros = model.UpdateValidate();

            if (erros.Count == 0)
            {
                _repository.Update(model);
                Commit();

                OnUpdateEvent(new ContatosUpdateEventArgs { });
            }

            return new ContatosUpdateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }

        private ContatosUpdateCommandResult Update(Contato model)
        {
            var erros = model.UpdateValidate();

            if (erros.Count == 0)
            {
                _repository.Update(model);
                Commit();
            }

            return new ContatosUpdateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }

        public List<Contato> GetAll()
        {
            return _repository.GetAll();
        }

        public Contato GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<Contato> GetAll(int? empresaId, string nome, int start, int limit, out int total)
        {
            return _repository.GetAll(empresaId, nome, start, limit, out total);
        }
    }
}
