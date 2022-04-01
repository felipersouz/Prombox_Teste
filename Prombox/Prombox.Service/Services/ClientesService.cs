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
    public class ClientesService : BaseService, IClientesService
    {
        private readonly IClientesRepository _repository;
        public event EventHandler<ClientesCreateEventArgs> CreateEventHandler;
        public event EventHandler<ClientesUpdateEventArgs> UpdateEventHandler;
        public event EventHandler<ClientesDeleteEventArgs> DeleteEventHandler;

        public ClientesService(IUnitOfWork uow, IClientesRepository repository) : base(uow)
        {
            _repository = repository;
        }

        protected virtual void OnCreateEventEvent(ClientesCreateEventArgs e)
        {
            CreateEventHandler?.Invoke(this, e);
        }

        protected virtual void OnUpdateEvent(ClientesUpdateEventArgs e)
        {
            UpdateEventHandler?.Invoke(this, e);
        }

        protected virtual void OnDeleteEvent(ClientesDeleteEventArgs e)
        {
            DeleteEventHandler?.Invoke(this, e);
        }

        public ClienteCreateCommandResult Create(ClienteCreateCommand command)
        {
            var model = command.ToModel();

            var erros = model.CreateValidate();

            if (erros.Count == 0)
            {
                _repository.Create(model);
                Commit();

                OnCreateEventEvent(new ClientesCreateEventArgs { });
            }

            return new ClienteCreateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }

        public ClienteDeleteCommandResult Delete(ClienteDeleteCommand command)
        {
            var erros = new List<string>();

            try
            {
                var model = _repository.GetById(command.Id);

                if (erros.Count == 0)
                {
                    _repository.Delete(model);

                    Commit();

                    OnDeleteEvent(new ClientesDeleteEventArgs { });
                }
            }
            catch (Exception ex)
            {
                erros.Add(ex.Message);
                erros.Add(ex.StackTrace);
            }

            return new ClienteDeleteCommandResult
            {
                Errors = erros
            };
        }

        public ClienteUpdateCommandResult Update(ClienteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model = command.ToModel(model);

            var erros = model.UpdateValidate();

            if (erros.Count == 0)
            {
                _repository.Update(model);
                Commit();

                OnUpdateEvent(new ClientesUpdateEventArgs { });
            }

            return new ClienteUpdateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }

        public ClienteUpdateCommandResult UpdateNome(ClienteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Nome = command.Nome;

            return Update(model);
        }
        public ClienteUpdateCommandResult UpdateCpf(ClienteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Cpf = command.Cpf;

            return Update(model);
        }
        public ClienteUpdateCommandResult UpdateRg(ClienteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Rg = command.Rg;

            return Update(model);
        }
        public ClienteUpdateCommandResult UpdateDataNascimento(ClienteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.DataNascimento = command.DataNascimento;

            return Update(model);
        }
        public ClienteUpdateCommandResult UpdateEmail(ClienteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Email = command.Email;

            return Update(model);
        }
        public ClienteUpdateCommandResult UpdateTelPrincipal(ClienteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.TelPrincipal = command.TelPrincipal;

            return Update(model);
        }
        public ClienteUpdateCommandResult UpdateTelSecundario(ClienteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.TelSecundario = command.TelSecundario;

            return Update(model);
        }
        public ClienteUpdateCommandResult UpdateCep(ClienteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Cep = command.Cep;

            return Update(model);
        }
        public ClienteUpdateCommandResult UpdateLogradouro(ClienteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Logradouro = command.Logradouro;

            return Update(model);
        }
        public ClienteUpdateCommandResult UpdateNumero(ClienteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Numero = command.Numero;

            return Update(model);
        }
        public ClienteUpdateCommandResult UpdateComplemento(ClienteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Complemento = command.Complemento;

            return Update(model);
        }
        public ClienteUpdateCommandResult UpdateBairro(ClienteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Bairro = command.Bairro;

            return Update(model);
        }
        public ClienteUpdateCommandResult UpdateCidade(ClienteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Cidade = command.Cidade;

            return Update(model);
        }
        public ClienteUpdateCommandResult UpdateUf(ClienteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Uf = command.Uf;

            return Update(model);
        }
        public ClienteUpdateCommandResult UpdateDataAceiteRegulamento(ClienteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.DataAceiteRegulamento = command.DataAceiteRegulamento;

            return Update(model);
        }
        public ClienteUpdateCommandResult UpdateAceite(ClienteUpdateCommand command)
        {
            var model = _repository.GetById(command.Id);
            model.Aceite = command.Aceite;

            return Update(model);
        }


        private ClienteUpdateCommandResult Update(Cliente model)
        {
            var erros = model.UpdateValidate();

            if (erros.Count == 0)
            {
                _repository.Update(model);
                Commit();
            }

            return new ClienteUpdateCommandResult
            {
                Errors = erros,
                Model = model
            };
        }

        public List<Cliente> GetAll()
        {
            return _repository.GetAll();
        }

        public Cliente GetById(long id)
        {
            return _repository.GetById(id);
        }

        public List<Cliente> GetAll(int start, int limit, out int total)
        {
            return _repository.GetAll(start, limit, out total);
        }
    }
}
