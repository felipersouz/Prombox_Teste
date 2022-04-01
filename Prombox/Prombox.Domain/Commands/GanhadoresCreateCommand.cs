using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Domain.Commands
{
    public class GanhadoresCreateCommand
    {
        public int CampanhaId { get; set; }
        public long Numero { get; set; }
        public int Colocacao { get; set; }
    }
}
