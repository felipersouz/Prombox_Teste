using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Prombox.Domain.Spacs
{
    public class EmpresasSpacs
    {
        public static Expression<Func<Empresa, bool>> GetById(int id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<Empresa, bool>> ExixtsCnpf(int id, string cnpj)
        {
            return x => x.Id != id && x.Cnpj == cnpj;
        }

        public static Expression<Func<Empresa, bool>> GetByName(string name)
        {
            if (string.IsNullOrEmpty(name)) name = String.Empty;

            return x => x.NomeFantasia.Contains(name) || x.RazaoSocial.Contains(name);
        }
    }
}
