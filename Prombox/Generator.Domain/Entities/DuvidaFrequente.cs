using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Generator.Domain.Entities
{
    public class DuvidaFrequente
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        [Column(TypeName = "VARCHAR")]
        public string Pergunta { get; set; }

        [MaxLength(2000)]
        [Column(TypeName = "VARCHAR")]
        public string Resposta { get; set; }

        public int Ordem { get; set; }

        public int? CampanhaId { get; set; } // Opcional pois se não tiver promoção associada podemos definir que é template
        public Campanha Campanha { get; set; }

    }
}
