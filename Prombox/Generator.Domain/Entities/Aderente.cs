using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prombox.Generator.Domain.Entities
{
    public class Aderente
    {

        public int Id { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "VARCHAR")]
        public string Nome { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string Cnpj { get; set; }

    }
}
