using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Domain.Entities
{
    public class ClienteCampanha
    {
        public long ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public int CampanhaId { get; set; }
        public Campanha Campanha { get; set; }        
        //public decimal Saldo { get; set; }
    }
}
