using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Scopes
{
    public static class UsuariosClientesScope
    {
        public static List<string> CreateValidate(this UsuarioCliente model)
        {
            var errors = new List<string>();


            return errors;
        }

        public static List<string> UpdateValidate(this UsuarioCliente model)
        {
            var errors = new List<string>();


            return errors;
        }
    }
}
