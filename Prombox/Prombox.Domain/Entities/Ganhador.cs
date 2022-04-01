using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Domain.Entities
{
    public class Ganhador
    {
        public int Id { get; set; }
        public int Colocacao { get; set; } // 1o, 2o, etc
        public long NumeroDaSorteId { get; set; }
        public NumeroDaSorte NumeroDaSorte { get; set; }
        public Campanha Campanha { get; set; }
        public int CampanhaId { get; set; }

        public dynamic ToJson()
        {
            var value = new
            {
                Id,
                Colocacao,
                NumeroDaSorteId,
                NumeroDaSorte = NumeroDaSorte != null ? new
                {
                    NumeroDaSorte.Numero,
                    Cliente = NumeroDaSorte.Cliente != null ? new
                    {
                        Id = NumeroDaSorte.Cliente.Id,
                        Nome = NumeroDaSorte.Cliente.Nome,
                        DataNascimento = NumeroDaSorte.Cliente.DataNascimento.ToString("yyyy-MM-dd"),
                        Email = NumeroDaSorte.Cliente.Email
                    } : null
                } : null,
                CampanhaId
            };

            return value;
        }
    }
}
