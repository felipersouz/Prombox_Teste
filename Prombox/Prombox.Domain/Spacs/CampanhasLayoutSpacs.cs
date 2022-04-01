using Prombox.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Prombox.Domain.Spacs
{
    public class CampanhasLayoutSpacs
    {
        public static Expression<Func<CampanhaLayout, bool>> GetById(int id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<CampanhaLayout, bool>> GetByCampanhaId(int campanhaId)
        {
            return x => x.CampanhaId == campanhaId;
        }
    }
}
