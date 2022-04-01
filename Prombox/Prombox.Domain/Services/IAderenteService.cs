using Prombox.Domain.Commands;
using Prombox.Domain.Commands.Results;
using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Services
{
    public interface IAderenteService
    {
        AderenteCreateCommandResult Create(AderenteCreateCommand commnad);
        AderenteUpdateCommandResult Update(AderenteUpdateCommand command);
        AderenteDeleteCommandResult Delete(AderenteDeleteCommand command);
        Aderente GetById(int id);
        List<Aderente> GetAll();
        List<Aderente> GetAll(int? empresaId, string nome, int start, int limit, out int total);
        List<Aderente> GetByCampanha(int campanhaId);
        bool IsAssociadoCampanha(string cnpj);

        AderenteUpdateCommandResult UpdateNome(AderenteUpdateCommand command);
        AderenteUpdateCommandResult UpdateCnpj(AderenteUpdateCommand command);
        AderenteUpdateCommandResult UpdateCampanhaId(AderenteUpdateCommand command);


        event EventHandler<AderenteCreateEventArgs> CreateEventHandler;
        event EventHandler<AderenteUpdateEventArgs> UpdateEventHandler;
        event EventHandler<AderenteDeleteEventArgs> DeleteEventHandler;
    }
}
