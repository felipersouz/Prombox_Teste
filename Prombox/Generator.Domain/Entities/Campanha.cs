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
    public class Campanha
    {
        public int Id { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime DataInicioCampanha { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime DataFinalCampanha { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime DataLimiteCadastro { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime DataInicioPeriodoCompras { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime DataFinalPeriodoCompras { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime DataSorteio { get; set; }
        
        [Column(TypeName = "VARCHAR")]
        public string ResumoRegulamento { get; set; }

        [MaxLength(200)]
        [Column(TypeName = "VARCHAR")]
        public string CertificadoAutorizacao { get; set; }

        [MaxLength(70)]
        [Column(TypeName = "VARCHAR")]
        public string EmailSac { get; set; }

        [MaxLength(20)]
        [Column(TypeName = "VARCHAR")]
        public string TelefoneSac { get; set; }

        public int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual List<Aderente> Aderentes { get; set; }
        public virtual List<DuvidaFrequente> DuvidasFrequentes { get; set; }
        public ETipoCampanha TipoCampanha { get; set; }


        public bool IsMaior18Anos { get; set; }
        public bool IsLimiteGeografico { get; set; }
        [MaxLength(2)]
        [Column(TypeName = "VARCHAR")]
        public string Estado { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string Cidade { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "VARCHAR")]
        public string Bairro { get; set; }

        public bool IsLimiteTrocasNF { get; set; }

        public decimal? ValorLimiteNF { get; set; }
        public int? QuantidadeLimiteNF { get; set; }               

        public bool IsLimiteGeneroSexual { get; set; }

        [MaxLength(2)]
        [Column(TypeName = "VARCHAR")]
        public string GeneroSexual { get; set; }

        public bool IsBloquearFuncionario { get; set; }
        
        [Column(TypeName = "TEXT")]
        public string CpfsBloqueados { get; set; }

        public ERegraParticipacao RegraParticipacao { get; set; }


        public virtual CampanhaLayout CampanhaLayout { get; set; }

    }
}
