using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Commands.Results
{
    public class UsuarioClienteCreateCommandResult : CommandResult
    {
        public UsuarioCliente Model { get; set; }
        public string UrlRedirect { get; set; }

        public override dynamic ToJson()
        {
            return new
            {
                Model,
                UrlRedirect,
                Errors
            };
        }

    }
}
