using Prombox.Domain.Commands;
using Prombox.Domain.Commands.Results;
using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Services
{
    public interface INotasFiscaisService
    {
        NotaFiscalCreateCommandResult Create(NotaFiscalCreateCommand commnad);
        NotaFiscaUpdateCommandResult Update(NotaFiscalUpdateCommand command);
        NotaFiscalDeleteCommandResult Delete(NotaFiscalDeleteCommand command);
        NotaFiscal GetById(long id);
        List<NotaFiscal> GetAll();
        List<NotaFiscal> GetAll(int start, int limit, out int total);
        List<NotaFiscal> GetByUsuarioClienteCampanha(long usuarioId, int campanhaId);
        decimal GetTotalNotasByUsuarioClienteCampanha(long usuarioClienteId, int campanhaId);
        decimal GetSaldo(long usuarioClienteId, int campanhaId);

        NotaFiscaUpdateCommandResult UpdateData(NotaFiscalUpdateCommand command);
        NotaFiscaUpdateCommandResult UpdateCod(NotaFiscalUpdateCommand command);
        NotaFiscaUpdateCommandResult UpdateCnpj(NotaFiscalUpdateCommand command);
        NotaFiscaUpdateCommandResult UpdateValorTotal(NotaFiscalUpdateCommand command);

        event EventHandler<NotasFiscaisCreateEventArgs> CreateEventHandler;
        event EventHandler<NotasFiscaisUpdateEventArgs> UpdateEventHandler;
        event EventHandler<NotasFiscaisDeleteEventArgs> DeleteEventHandler;
    }
}
