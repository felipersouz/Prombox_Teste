using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Domain.Commands
{
    public class GanhadoresDeleteCommand : Command
    {
        public int Id { get; set; }
    }
}

