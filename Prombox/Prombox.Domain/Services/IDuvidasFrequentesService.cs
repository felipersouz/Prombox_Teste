using Prombox.Domain.Commands;
using Prombox.Domain.Commands.Results;
using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Services
{
    public interface IDuvidasFrequentesService
    {
        DuvidaFrequenteCreateCommandResult Create(DuvidaFrequenteCreateCommand commnad);
        DuvidaFrequenteUpdateCommandResult Update(DuvidaFrequenteUpdateCommand command);
        DuvidaFrequenteDeleteCommandResult Delete(DuvidaFrequenteDeleteCommand command);
        DuvidaFrequente GetById(int id);
        List<DuvidaFrequente> GetByCampanha(int campanhaId);
        List<DuvidaFrequente> GetAll();
        List<DuvidaFrequente> GetAll(int? empresaId, int? campanhaId, string pergunta, int start, int limit, out int total);

        DuvidaFrequenteUpdateCommandResult UpdatePergunta(DuvidaFrequenteUpdateCommand command);
        DuvidaFrequenteUpdateCommandResult UpdateResposta(DuvidaFrequenteUpdateCommand command);
        DuvidaFrequenteUpdateCommandResult UpdateOrdem(DuvidaFrequenteUpdateCommand command);
        DuvidaFrequenteUpdateCommandResult UpdateCampanhaId(DuvidaFrequenteUpdateCommand command);


        event EventHandler<DuvidasFrequentesCreateEventArgs> CreateEventHandler;
        event EventHandler<DuvidasFrequentesUpdateEventArgs> UpdateEventHandler;
        event EventHandler<DuvidasFrequentesDeleteEventArgs> DeleteEventHandler;
    }
}
