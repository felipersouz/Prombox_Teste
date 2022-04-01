using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prombox.Generator.Domain.Entities
{
    public class Cliente
    {
        
        public long Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        [Column(TypeName = "VARCHAR")]
        public string Nome { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string Cpf { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string Rg { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime DataNascimento { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "VARCHAR")]
        public string Email { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string TelPrincipal { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string TelSecundario { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string Cep { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "VARCHAR")]
        public string Logradouro { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string Numero { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string Complemento { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string Bairro { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string Cidade { get; set; }

        [MaxLength(2)]
        [Column(TypeName = "VARCHAR")]
        public string Uf { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime? DataAceiteRegulamento { get; set; }

        public bool Aceite { get; set; }
    }
}
