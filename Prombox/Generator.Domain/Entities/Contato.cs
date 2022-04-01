using Prombox.Generator.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Generator.Domain.Entities
{
    public class Contato
    {
        public int Id { get; set; }
        public ETipoContato TipoContato { get; set; }
        [MaxLength(60)]
        [Column(TypeName = "VARCHAR")]
        public string Nome { get; set; }
        [MaxLength(30)]
        [Column(TypeName = "VARCHAR")]
        public string Cargo { get; set; }
        [MaxLength(70)]
        [Column(TypeName = "VARCHAR")]
        public string Email { get; set; }
        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string Celular { get; set; }
        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string Telefone { get; set; }
        [MaxLength(1000)]
        [Column(TypeName = "VARCHAR")]
        public string Observacoes { get; set; }
        public bool Ativo { get; set; }
    }
}
