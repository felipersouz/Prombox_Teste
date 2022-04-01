using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Commands.Results
{
    public class ContatosUpdateCommandResult : CommandResult
    {
        public Contato Model { get; set; }

        public override dynamic ToJson()
        {
            if (Model != null)
                return Model.ToJson();

            return base.ToJson();
        }
    }
}
