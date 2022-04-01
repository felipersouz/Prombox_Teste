using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Prombox.Domain.Spacs
{
    public class NotasFiscaisSpacs
    {
        public static Expression<Func<NotaFiscal, bool>> GetById(long id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<NotaFiscal, bool>> GetByUsuarioClienteCampanha(long usuarioClienteId, int campanhaId)
        {
            return x => x.UsuarioClienteId == usuarioClienteId && x.CampanhaId == campanhaId;
        }
        public static Expression<Func<NotaFiscal, bool>> GetAllWithSaldo(long usuarioClienteId, int campanhaId)
        {
            return x => x.UsuarioClienteId == usuarioClienteId && x.CampanhaId == campanhaId && x.Saldo > 0;
        }

        public static Expression<Func<NotaFiscal, bool>> GetByUsuarioClienteCampanhaCodigoNota(long usuarioClienteId, int campanhaId, string codigoNota)
        {
            return x => x.UsuarioClienteId == usuarioClienteId && x.CampanhaId == campanhaId && x.Cod == codigoNota;
        }
    }
}
