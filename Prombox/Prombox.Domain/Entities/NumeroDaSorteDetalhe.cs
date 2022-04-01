using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Domain.Entities
{
    public class NumeroDaSorteDetalhe
    {        
        public long Id { get; set; }
        public long NumeroDaSorteId { get; set; }
        public decimal ValorUtilizado { get; set; }
        public long NotaFiscalId { get; set; }
        public NumeroDaSorte NumeroDaSorte { get; set; }
        public NotaFiscal NotaFiscal { get; set; }

        public dynamic ToJson()
        {
            return new
            {
                Id,
                NumeroDaSorteId,
                ValorUtilizado,
                NotaFiscalId,
                NumeroDaSorte = NumeroDaSorte?.ToJson(),
                NotaFiscal = NotaFiscal?.ToJson()
            };
        }
    }
}
