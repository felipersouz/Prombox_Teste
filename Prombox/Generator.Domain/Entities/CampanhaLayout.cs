using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Generator.Domain.Entities
{    
    public class CampanhaLayout
    {

        public int CampanhaId { get; set; }

        public int Id { get; set; }

        [MaxLength(512)]
        [Column(TypeName = "VARCHAR")]
        public string UrlLogo { get; set; }

        [MaxLength(200)]
        [Column(TypeName = "VARCHAR")]
        public string UrlCampanha { get; set; }

        [MaxLength(200)]
        [Column(TypeName = "VARCHAR")]
        public string UrlRegulamento { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "VARCHAR")]
        public string UrlInstagram { get; set; }

        [MaxLength(512)]
        [Column(TypeName = "VARCHAR")]
        public string UrlComoParticipar { get; set; }

        [MaxLength(500)]
        [Column(TypeName = "VARCHAR")]
        public string UrlFacebook { get; set; }


        [MaxLength(512)]
        [Column(TypeName = "VARCHAR")]
        public string UrlBanner1 { get; set; }

        [MaxLength(512)]
        [Column(TypeName = "VARCHAR")]
        public string UrlBanner2 { get; set; }

        [MaxLength(512)]
        [Column(TypeName = "VARCHAR")]
        public string UrlBanner3 { get; set; }

        [MaxLength(30)]
        [Column(TypeName = "VARCHAR")]
        public string CorFundoSite { get; set; }

        [MaxLength(30)]
        [Column(TypeName = "VARCHAR")]
        public string CorBotoes { get; set; }

        [MaxLength(30)]
        [Column(TypeName = "VARCHAR")]
        public string CorCabecalhoRodape { get; set; }

    }
}
