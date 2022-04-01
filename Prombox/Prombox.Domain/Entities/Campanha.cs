using Prombox.Domain.Commands;
using Prombox.Domain.Entities.Enum;
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prombox.Domain.Entities
{
    public class Campanha
    {
        public Campanha()
        {
            CampanhaAderentes = new List<CampanhaAderente>();
            DuvidasFrequentes = new List<DuvidaFrequente>();
            NotasFiscais = new List<NotaFiscal>();
            Ganhadores = new List<Ganhador>();
        }
        public int Id { get; set; }

        #region [ Etapa 1]
        public string Nome { get; set; }
        public DateTime DataInicioCampanha { get; set; }
        public DateTime DataFinalCampanha { get; set; }
        public DateTime DataLimiteCadastro { get; set; }
        public DateTime DataInicioPeriodoCompras { get; set; }
        public DateTime DataFinalPeriodoCompras { get; set; }
        public DateTime DataSorteio { get; set; }
        public string CertificadoAutorizacao { get; set; }
        #endregion
        public string ResumoRegulamento { get; set; }
        public string EmailSac { get; set; }
        public string TelefoneSac { get; set; }
        public int EmpresaId { get; set; }
        public virtual Empresa Empresa { get; set; }
        public ETipoCampanha TipoCampanha { get; set; }
        public bool IsMaior18Anos { get; set; }
        public bool IsLimiteGeografico { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public bool IsLimiteTrocasNF { get; set; }
        public decimal? ValorLimiteNF { get; set; }
        public decimal ValorParaNumeroDaSorte { get; set; }
        public int? QuantidadeLimiteNF { get; set; }
        public bool IsLimiteGeneroSexual { get; set; }
        public string GeneroSexual { get; set; }
        public bool IsBloquearFuncionario { get; set; }
        public string CpfsBloqueados { get; set; }
        public ERegraParticipacao? RegraParticipacao { get; set; }
        public DateTime? DataEnvioNF { get; set; }
        public DateTime? DataVencimento { get; set; }
        public CampanhaLayout CampanhaLayout { get; set; }
        public int? CampanhaLayoutId { get; set; }
        public bool Ativa { get; set; }
        public virtual List<CampanhaAderente> CampanhaAderentes { get; set; }
        public virtual List<DuvidaFrequente> DuvidasFrequentes { get; set; }
        public List<Ganhador> Ganhadores { get; set; }
        public string UrlImagemGanhadores { get; set; }
        public List<NotaFiscal> NotasFiscais { get; set; }

        public IList<ClienteCampanha> ClientesCampanhas { get; set; }
        public dynamic ToJson()
        {
            return new
            {
                // Etapa 1
                Id,
                EmpresaId,
                Empresa = Empresa != null ? new
                {
                    Id = Empresa.Id,
                    NomeFantasia = Empresa.NomeFantasia
                } : null,
                TipoCampanha,
                Nome,
                DataInicioCampanha = DataInicioCampanha.ToString("yyyy-MM-dd"),
                DataFinalCampanha = DataFinalCampanha.ToString("yyyy-MM-dd"),
                DataLimiteCadastro = DataLimiteCadastro.ToString("yyyy-MM-dd"),
                DataInicioPeriodoCompras = DataInicioPeriodoCompras.ToString("yyyy-MM-dd"),
                DataFinalPeriodoCompras = DataFinalPeriodoCompras.ToString("yyyy-MM-dd"),
                DataSorteio = DataSorteio.ToString("yyyy-MM-dd"),
                CertificadoAutorizacao,
                // Etapa 3
                IsMaior18Anos,
                IsLimiteGeografico,
                Estado,
                Cidade,
                Bairro,
                IsLimiteTrocasNF,
                ValorLimiteNF,
                QuantidadeLimiteNF,
                IsLimiteGeneroSexual,
                IsBloquearFuncionario,
                CpfsBloqueados,
                RegraParticipacao,
                Ativa,
                UrlImagemGanhadores,
                aderentes = CampanhaAderentes.Select(x => x.AderenteId).ToList()
            };
        }

        public CampanhasUpdateCommand ToCampanhasUpdateCommand()
        {
            return new CampanhasUpdateCommand
            {
                Id = this.Id,
                Nome = this.Nome,
                DataInicioCampanha = this.DataInicioCampanha,
                DataFinalCampanha = this.DataFinalCampanha,
                DataLimiteCadastro = this.DataLimiteCadastro,
                DataInicioPeriodoCompras = this.DataInicioPeriodoCompras,
                DataFinalPeriodoCompras = this.DataFinalPeriodoCompras,
                DataSorteio = this.DataSorteio,
                CertificadoAutorizacao = this.CertificadoAutorizacao,
                ResumoRegulamento = this.ResumoRegulamento,
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
                RegraParticipacao = this.RegraParticipacao.HasValue ? this.RegraParticipacao.Value : ERegraParticipacao.Ambos,
                //DataEnvioNF = this.DataEnvioNF.HasValue ? this.DataEnvioNF.Value : DateTime.Now,
                //DataVencimento = this.DataVencimento.HasValue ? this.DataVencimento.Value : DateTime.Now,
                CampanhaLayoutId = this.CampanhaLayoutId,
                Ativa = this.Ativa,
                UrlImagemGanhadores = this.UrlImagemGanhadores
            };
        }

    }
}
