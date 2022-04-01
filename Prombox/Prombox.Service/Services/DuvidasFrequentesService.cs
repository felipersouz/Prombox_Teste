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
    public class DuvidasFrequentesService : BaseService, IDuvidasFrequentesService
    {
        private readonly IDuvidasFrequentesRepository _repository;
        public event EventHandler<DuvidasFrequentesCreateEventArgs> CreateEventHandler;
        public event EventHandler<DuvidasFrequentesUpdateEventArgs> UpdateEventHandler;
        public event EventHandler<DuvidasFrequentesDeleteEventArgs> DeleteEventHandler;

        public DuvidasFrequentesService(IUnitOfWork uow, IDuvidasFrequentesRepository repository) : base(uow)
        {
            _repository = repository;
        }

        protected virtual void OnCreateEventEvent(DuvidasFrequentesCreateEventArgs e)
        {
            CreateEventHandler?.Invoke(this, e);
        }

        protected virtual void OnUpdateEvent(DuvidasFrequentesUpdateEventArgs e)
        {
            UpdateEventHandler?.Invoke(this, e);
        }

        protected virtual void OnDeleteEvent(DuvidasFrequentesDeleteEventArgs e)
        {
            DeleteEventHandler?.Invoke(this, e);
        }

        public DuvidaFrequenteCreateCommandResult Create(DuvidaFrequenteCreateCommand command)
        {
            var model = command.ToModel();

            var erros = model.CreateValidate();

            if (erros.Count == 0)
            {
                _repository.Create(model);
                Commit();

                OnCreateEventEvent(new DuvidasFrequentesCreateEventArgs { });
            }

            return new DuvidaFrequenteCreateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }

        public DuvidaFrequenteDeleteCommandResult Delete(DuvidaFrequenteDeleteCommand command)
        {
            var erros = new List<string>();

            try
            {
                var model = _repository.GetById(command.Id);

                if (erros.Count == 0)
                {
                    _repository.Delete(model);

                    Commit();

                    OnDeleteEvent(new DuvidasFrequentesDeleteEventArgs { });
                }
            }
            catch (DbUpdateException ex)
            {
                erros.Add("A dúvida não pode ser excluída.");
            }
            catch (Exception ex)
            {
                erros.Add(ex.Message);
            }

            return new DuvidaFrequenteDeleteCommandResult
            {
                Errors = erros
            };
        }

        public DuvidaFrequenteUpdateCommandResult Update(DuvidaFrequenteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model = command.ToModel(model);

            var erros = model.UpdateValidate();

            if (erros.Count == 0)
            {
                _repository.Update(model);
                Commit();

                OnUpdateEvent(new DuvidasFrequentesUpdateEventArgs { });
            }

            return new DuvidaFrequenteUpdateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }

        public DuvidaFrequenteUpdateCommandResult UpdatePergunta(DuvidaFrequenteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Pergunta = command.Pergunta;

            return Update(model);
        }
        public DuvidaFrequenteUpdateCommandResult UpdateResposta(DuvidaFrequenteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Resposta = command.Resposta;

            return Update(model);
        }
        public DuvidaFrequenteUpdateCommandResult UpdateOrdem(DuvidaFrequenteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Ordem = command.Ordem;

            return Update(model);
        }
        public DuvidaFrequenteUpdateCommandResult UpdateCampanhaId(DuvidaFrequenteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.CampanhaId = command.CampanhaId;

            return Update(model);
        }


        private DuvidaFrequenteUpdateCommandResult Update(DuvidaFrequente model)
        {
            var erros = model.UpdateValidate();

            if (erros.Count == 0)
            {
                _repository.Update(model);
                Commit();
            }

            return new DuvidaFrequenteUpdateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }

        public List<DuvidaFrequente> GetAll()
        {
            return _repository.GetAll();
        }

        public List<DuvidaFrequente> GetByCampanha(int campanhaId)
        {
            return _repository.GetByCampanha(campanhaId);
        }

        public DuvidaFrequente GetById(int id)
        {
            return _repository.GetById(id);
        }

        public List<DuvidaFrequente> GetAll(int? empresaId, int? campanhaId, string pergunta, int start, int limit, out int total)
        {
            return _repository.GetAll(empresaId, campanhaId, pergunta, start, limit, out total);
        }
    }
}
