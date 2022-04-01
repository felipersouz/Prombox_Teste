using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Prombox.Domain.Spacs
{
    public class GanhadorSpacs
    {
        public static Expression<Func<Ganhador, bool>> GetById(int id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<Ganhador, bool>> GetBy(int camapanhaId)
        {
            return x => x.CampanhaId == camapanhaId;
        }

        public static Expression<Func<Ganhador, bool>> GetBy(int camapanhaId, long numero)
        {
            return x => x.CampanhaId == camapanhaId && x.NumeroDaSorte.Numero == numero;
        }
    }
}
