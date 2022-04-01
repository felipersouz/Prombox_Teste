using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Commands.Results
{
    public class DuvidaFrequenteUpdateCommandResult : CommandResult
    {
        public DuvidaFrequente Model { get; set; }

        public override dynamic ToJson()
        {
            if (Model != null)
                return Model.ToJson();

            return base.ToJson();
        }
    }
}
