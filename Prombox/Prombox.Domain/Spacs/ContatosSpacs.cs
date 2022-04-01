using Prombox.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Prombox.Domain.Spacs
{
    public class ContatosSpacs
    {
        public static Expression<Func<Contato, bool>> GetById(int id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<Contato, bool>> GetBy(int? empresaId, string name)
        {
            if (string.IsNullOrEmpty(name)) name = String.Empty;

            return x =>
               (empresaId == null || x.EmpresaId == empresaId) &&
               (name == "" || x.Nome.Contains(name));
        }
    }
}
