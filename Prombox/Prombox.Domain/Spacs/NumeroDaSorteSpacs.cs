using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Prombox.Domain.Spacs
{
    public class NumeroDaSorteSpacs
    {
        public static Expression<Func<NumeroDaSorte, bool>> GetById(long id)
        {
            return x => x.Id == id;
        }
        public static Expression<Func<NumeroDaSorte, bool>> GetMines(long clienteId, int campanhaId)
        {
            return x => x.ClienteId == clienteId && x.CampanhaId == campanhaId;
        }

        public static Expression<Func<NumeroDaSorte, bool>> GetBy(long numero, int campanhaId)
        {
            return x => x.Numero == numero && x.CampanhaId == campanhaId;
        }
    }
}
