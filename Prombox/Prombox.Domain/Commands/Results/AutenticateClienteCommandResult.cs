using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Domain.Commands.Results
{
    public class AutenticateClienteCommandResult : CommandResult
    {
        public UsuarioCliente Model { get; set; }
    }
}
