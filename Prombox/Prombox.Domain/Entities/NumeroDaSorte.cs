using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Domain.Entities
{
    public class NumeroDaSorte
    {
        public NumeroDaSorte()
        {
            this.Detalhes = new List<NumeroDaSorteDetalhe>();
        }

        public long Id { get; set; }
        public long Numero { get; set; }
        public Campanha Campanha { get; set; }
        public int CampanhaId { get; set; }
        public Cliente Cliente { get; set; }
        public long? ClienteId { get; set; }
        public DateTime? DataHoraAssociacao { get; set; }
        public bool Ativo { get; set; }
        public List<NumeroDaSorteDetalhe> Detalhes { get; set; }
        public int Serie { get; set; }

        public dynamic ToJson()
        {
            return new
            {
                Id,
                Numero,
                Campanha = Campanha?.ToJson(),
                CampanhaId,
                Cliente = Cliente?.ToJson(),
                ClienteId,
                DataHoraAssociacao,
                Ativo,
                Detalhes = Detalhes?.Select(x=> x.ToJson()),
                Serie
            };
        }
    }
}
