using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Generator.Domain.Entities
{
    public class NotaFiscal
    {
        public long Id { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime Data { get; set; }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string Cod { get; set; }

        [MaxLength(18)]
        [Column(TypeName = "VARCHAR")]
        public string Cnpj { get; set; }
        public double ValorTotal { get; set; }
    }
}
