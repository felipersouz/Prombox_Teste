using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Prombox.Domain.Spacs
{
    public class DuvidasFrequentesSpacs
    {
        public static Expression<Func<DuvidaFrequente, bool>> GetById(int id)
        {
            return x => x.Id == id;
        }


        

        public static Expression<Func<DuvidaFrequente, bool>> GetByCampanha(int campanhaId)
        {
            return x => x.CampanhaId == campanhaId;
        }

        public static Expression<Func<DuvidaFrequente, bool>> GetBy(int? empresaId, int? campanhaId, string name)
        {
            if (string.IsNullOrEmpty(name)) name = String.Empty;

            return x =>
                    (empresaId == null || x.EmpresaId == empresaId) &&
                    (campanhaId == null || x.CampanhaId == campanhaId) &&
                    (name == "" || x.Pergunta.Contains(name));
        }

        public static Expression<Func<DuvidaFrequente, bool>> GetDefault()
        {
            return x => !x.EmpresaId.HasValue && !x.CampanhaId.HasValue;
        }
    }
}
