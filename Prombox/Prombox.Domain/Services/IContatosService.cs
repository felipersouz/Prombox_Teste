using Prombox.Domain.Commands;
using Prombox.Domain.Commands.Results;
using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Prombox.Domain.Services
{
    public interface IContatosService
    {
        ContatosCreateCommandResult Create(ContatosCreateCommand commnad);
        ContatosUpdateCommandResult Update(ContatosUpdateCommand command);
        ContatosDeleteCommandResult Delete(ContatosDeleteCommand command);
        Contato GetById(int id);
        List<Contato> GetAll();
        List<Contato> GetAll(int? empresaId, string nome, int start, int limit, out int total);

        event EventHandler<ContatosCreateEventArgs> CreateEventHandler;
        event EventHandler<ContatosUpdateEventArgs> UpdateEventHandler;
        event EventHandler<ContatosDeleteEventArgs> DeleteEventHandler;
    }
}
