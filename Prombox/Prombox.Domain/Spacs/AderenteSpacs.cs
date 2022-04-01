using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Prombox.Domain.Spacs
{
    public class AderenteSpacs
    {
        public static Expression<Func<Aderente, bool>> GetById(int id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<Aderente, bool>> GetBy(int? empresaId, string name)
        {
            if (string.IsNullOrEmpty(name)) name = String.Empty;

            return x =>
            (empresaId == null || x.EmpresaId == empresaId) &&
            (name == "" || x.Nome.Contains(name));
        }
    }
}
