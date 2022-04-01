using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Domain.Entities
{
    public class CampanhaAderente
    {
        public int CampanhaId { get; set; }
        public Campanha Campanha { get; set; }

        public int AderenteId { get; set; }
        public Aderente Aderente { get; set; }
    }
}
