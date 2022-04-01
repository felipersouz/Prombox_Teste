using Prombox.Domain.Entities;
using Prombox.Domain.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Commands
{
    public class CampanhasCreateCommand : Command
    {
        public string Nome { get; set; }
        public DateTime DataInicioCampanha { get; set; }
        public DateTime DataFinalCampanha { get; set; }
        public DateTime DataLimiteCadastro { get; set; }
        public DateTime DataInicioPeriodoCompras { get; set; }
        public DateTime DataFinalPeriodoCompras { get; set; }
        public DateTime DataSorteio { get; set; }
        public string ResumoRegulamento { get; set; }
        public string CertificadoAutorizacao { get; set; }
        public string EmailSac { get; set; }
        public string TelefoneSac { get; set; }
        public int EmpresaId { get; set; }
        public ETipoCampanha TipoCampanha { get; set; }
        public bool IsMaior18Anos { get; set; }
        public bool IsLimiteGeografico { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public bool IsLimiteTrocasNF { get; set; }
        public decimal? ValorLimiteNF { get; set; }
        public int? QuantidadeLimiteNF { get; set; }
        public bool IsLimiteGeneroSexual { get; set; }
        public string GeneroSexual { get; set; }
        public bool IsBloquearFuncionario { get; set; }
        public string CpfsBloqueados { get; set; }
        public ERegraParticipacao RegraParticipacao { get; set; }
        public int? CampanhaLayoutId { get; set; }
        public bool Ativa { get; set; }

        public Campanha ToModel()
        {
            var model = new Campanha
            {
                Nome = this.Nome,
                DataInicioCampanha = this.DataInicioCampanha,
                DataFinalCampanha = this.DataFinalCampanha,
                DataLimiteCadastro = this.DataLimiteCadastro,
                DataInicioPeriodoCompras = this.DataInicioPeriodoCompras,
                DataFinalPeriodoCompras = this.DataFinalPeriodoCompras,
                DataSorteio = this.DataSorteio,
                ResumoRegulamento = this.ResumoRegulamento,
                CertificadoAutorizacao = this.CertificadoAutorizacao,
                EmailSac = this.EmailSac,
                TelefoneSac = this.TelefoneSac,
                EmpresaId = this.EmpresaId,
                TipoCampanha = this.TipoCampanha,
                IsMaior18Anos = this.IsMaior18Anos,
                IsLimiteGeografico = this.IsLimiteGeografico,
                Estado = this.Estado,
                Cidade = this.Cidade,
                Bairro = this.Bairro,
                IsLimiteTrocasNF = this.IsLimiteTrocasNF,
                ValorLimiteNF = this.ValorLimiteNF,
                QuantidadeLimiteNF = this.QuantidadeLimiteNF,
                IsLimiteGeneroSexual = this.IsLimiteGeneroSexual,
                GeneroSexual = this.GeneroSexual,
                IsBloquearFuncionario = this.IsBloquearFuncionario,
                CpfsBloqueados = this.CpfsBloqueados,
                RegraParticipacao = this.RegraParticipacao,
                CampanhaLayoutId = this.CampanhaLayoutId,
                Ativa = this.Ativa
            };

            return model;
        }
    }
}
