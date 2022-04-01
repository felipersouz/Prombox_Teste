using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Commands
{
    public class CampanhaDeleteCommand : Command
    {
        public int Id { get; set; }
    }
}
