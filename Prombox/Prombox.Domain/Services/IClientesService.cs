using Prombox.Domain.Commands;
using Prombox.Domain.Commands.Results;
using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Services
{
    public interface IClientesService
    {
        ClienteCreateCommandResult Create(ClienteCreateCommand commnad);
        ClienteUpdateCommandResult Update(ClienteUpdateCommand command);
        ClienteDeleteCommandResult Delete(ClienteDeleteCommand command);
        Cliente GetById(long id);
        List<Cliente> GetAll();
        List<Cliente> GetAll(int start, int limit, out int total);
        ClienteUpdateCommandResult UpdateNome(ClienteUpdateCommand command);
        ClienteUpdateCommandResult UpdateCpf(ClienteUpdateCommand command);
        ClienteUpdateCommandResult UpdateRg(ClienteUpdateCommand command);
        ClienteUpdateCommandResult UpdateDataNascimento(ClienteUpdateCommand command);
        ClienteUpdateCommandResult UpdateEmail(ClienteUpdateCommand command);
        ClienteUpdateCommandResult UpdateTelPrincipal(ClienteUpdateCommand command);
        ClienteUpdateCommandResult UpdateTelSecundario(ClienteUpdateCommand command);
        ClienteUpdateCommandResult UpdateCep(ClienteUpdateCommand command);
        ClienteUpdateCommandResult UpdateLogradouro(ClienteUpdateCommand command);
        ClienteUpdateCommandResult UpdateNumero(ClienteUpdateCommand command);
        ClienteUpdateCommandResult UpdateComplemento(ClienteUpdateCommand command);
        ClienteUpdateCommandResult UpdateBairro(ClienteUpdateCommand command);
        ClienteUpdateCommandResult UpdateCidade(ClienteUpdateCommand command);
        ClienteUpdateCommandResult UpdateUf(ClienteUpdateCommand command);
        ClienteUpdateCommandResult UpdateDataAceiteRegulamento(ClienteUpdateCommand command);
        ClienteUpdateCommandResult UpdateAceite(ClienteUpdateCommand command);

        event EventHandler<ClientesCreateEventArgs> CreateEventHandler;
        event EventHandler<ClientesUpdateEventArgs> UpdateEventHandler;
        event EventHandler<ClientesDeleteEventArgs> DeleteEventHandler;
    }
}
