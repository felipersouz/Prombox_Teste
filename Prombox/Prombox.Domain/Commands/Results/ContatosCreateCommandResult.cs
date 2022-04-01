using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Commands.Results
{
    public class ContatosCreateCommandResult : CommandResult
    {
        public Contato Model { get; set; }

        public override dynamic ToJson()
        {
            return Model != null ? Model.ToJson() : base.ToJson();
        }

    }
}
