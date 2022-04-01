using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Repositories
{
    public interface INotasFiscaisRepository
    {
        void Create(NotaFiscal model);
        void Update(NotaFiscal model);
        void Delete(NotaFiscal model);
        NotaFiscal GetById(long id);
        decimal GetSaldo(long usuarioClienteId, int campanhaId);
        List<NotaFiscal> GetAll();
        List<NotaFiscal> GetAll(int start, int limit, out int total);
        List<NotaFiscal> GetByUsuarioClienteCampanha(long usuarioId, int campanhaId);
        List<NotaFiscal> GetAllWithSaldo(long usuarioClienteId, int campanhaId);
        decimal GetTotalNotasByUsuarioClienteCampanha(long usuarioClienteId, int campanhaId);
        List<NotaFiscal> GetByUsuarioClienteCampanhaCodigoNota(long usuarioClienteId, int campanhaId, string codigoNota);


    }
}
