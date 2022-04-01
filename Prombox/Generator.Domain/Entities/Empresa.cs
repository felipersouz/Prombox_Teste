using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Generator.Domain.Entities
{
    public class Empresa
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Column(TypeName = "VARCHAR")]

        public string Nome { get; set; }
        public bool Ativa { get;  set; }
        
        [MaxLength(60)]
        [Column(TypeName = "VARCHAR")]
        public string RazaoSocial { get; set; }
        [MaxLength(60)]
        [Column(TypeName = "VARCHAR")]
        public string NomeFantasia { get; set; }
        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string Cnpj { get; set; }
        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string Telefone { get; set; }
        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string InscricaoMunicipal { get; set; }
        [MaxLength(255)]
        [Column(TypeName = "VARCHAR")]
        public string UrlSite { get; set; }
        [MaxLength(9)]
        [Column(TypeName = "VARCHAR")]
        public string Cep { get; set; }
        [MaxLength(60)]
        [Column(TypeName = "VARCHAR")]
        public string Logradouro { get; set; }
        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string Numero { get; set; }
        [MaxLength(60)]
        [Column(TypeName = "VARCHAR")]
        public string Complemento { get; set; }
        [MaxLength(60)]
        [Column(TypeName = "VARCHAR")]
        public string Bairro { get; set; }
        [MaxLength(60)]
        [Column(TypeName = "VARCHAR")]
        public string Cidade { get; set; }
        [MaxLength(2)]
        [Column(TypeName = "VARCHAR")]
        public string Uf { get; set; }
        [MaxLength(255)]
        [Column(TypeName = "VARCHAR")]
        public string Observacoes { get; set; }
        [MaxLength(1000)]
        [Column(TypeName = "VARCHAR")]
        public string UrlFacebook { get; set; }
        [MaxLength(255)]
        [Column(TypeName = "VARCHAR")]
        public string UrlTwitter { get; set; }
        [MaxLength(255)]
        [Column(TypeName = "VARCHAR")]
        public string UrlInstagram { get; set; }
        [MaxLength(255)]
        [Column(TypeName = "VARCHAR")]
        public string UrlYoutube { get; set; }
        [MaxLength(255)]
        [Column(TypeName = "VARCHAR")]
        public string UrlLinkedin { get; set; }

        // Financeiro
        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string CnpjFaturamento { get; set; }
        public bool PrecisaOrdemCompra { get; set; }
        [MaxLength(60)]
        [Column(TypeName = "VARCHAR")]
        public string RazaoSocialFaturamento { get; set; }
        [Column(TypeName = "DATETIME")]
        public DateTime DataEnvioNF { get; set; }
        [Column(TypeName = "DATETIME")]
        public DateTime DataVencimento { get; set; }

    }
}
