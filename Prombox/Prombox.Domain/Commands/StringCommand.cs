using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Domain.Commands
{
    public class StringCommand : Command
    {
        public string Value { get; set; }
    }
}
