using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Prombox.Domain.Spacs
{
    public class ClientesSpacs
    {
        public static Expression<Func<Cliente, bool>> GetById(long id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<Cliente, bool>> GetByCpfEmpresa(string cpf, int empresaId)
        {
            return x => x.Cpf == cpf && x.EmpresaId == empresaId;
        }

        public static Expression<Func<Cliente, bool>> GetByCpfOrEmail(string cpf, string email)
        {
            return x => x.Cpf == cpf || x.Email == email;
        }

        public static Expression<Func<Cliente, bool>> GetByEmail(string email)
        {
            return x => x.Email == email;
        }
    }
}
