using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Commands
{
    public class ContatosDeleteCommand : Command
    {
        public int Id { get; set; }
    }
}
