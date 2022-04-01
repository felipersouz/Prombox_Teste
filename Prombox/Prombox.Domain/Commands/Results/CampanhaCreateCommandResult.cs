using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Commands.Results
{
    public class CampanhaCreateCommandResult : CommandResult
    {
        public Campanha Model { get; set; }

        public override dynamic ToJson()
        {
            return Model != null ? Model.ToJson() : base.ToJson();
        }

    }
}
