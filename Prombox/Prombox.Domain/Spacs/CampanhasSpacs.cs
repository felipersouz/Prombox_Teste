using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Prombox.Domain.Spacs
{
    public class CampanhasSpacs
    {
        public static Expression<Func<Campanha, bool>> GetById(int id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<Campanha, bool>> GetByEmpresaId(int empresaId)
        {
            return x => x.EmpresaId == empresaId;
        }

        public static Expression<Func<Campanha, bool>> GetBy(int? empresaId, string nome)
        {
            if (String.IsNullOrEmpty(nome))
                nome = "";

            return x =>
                (empresaId == null || x.EmpresaId == empresaId.Value) &&
                (nome == "" || x.Nome.Contains(nome));
        }
    }
}
