using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Commands.Results
{
    public class CommandResult
    {
        public List<string> Errors { get; set; }

        public CommandResult()
        {
            Errors = new List<string>();
        }

        public virtual dynamic ToJson()
        {
            return new { Errors };
        }
    }
}
