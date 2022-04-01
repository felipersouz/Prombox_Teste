using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Domain.Commands
{
    public class UpdateAderenteCommand
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
