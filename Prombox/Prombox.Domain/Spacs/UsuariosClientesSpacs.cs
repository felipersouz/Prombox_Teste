using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Prombox.Domain.Spacs
{
    public class UsuariosClientesSpacs
    {
        public static Expression<Func<UsuarioCliente, bool>> GetById(long id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<UsuarioCliente, bool>> GetByClienteId(long clienteId)
        {
            return x => x.ClienteId == clienteId;
        }
    }
}
