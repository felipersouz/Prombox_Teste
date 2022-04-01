using Prombox.Domain.Entities;
using Prombox.Domain.Entities.Enum;
using System;

namespace Prombox.Domain.Commands
{
    public class CampanhasUpdateCommand : Command
    {
        public int Id { get; set; }
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
        public string UrlImagemGanhadores { get; set; }
        public DateTime? DataEnvioNF { get; set; }
        public DateTime? DataVencimento { get; set; }



        public Campanha ToModel(Campanha model)
        {
            model.Id = this.Id;
            model.Nome = this.Nome;
            model.DataInicioCampanha = this.DataInicioCampanha;
            model.DataFinalCampanha = this.DataFinalCampanha;
            model.DataLimiteCadastro = this.DataLimiteCadastro;
            model.DataInicioPeriodoCompras = this.DataInicioPeriodoCompras;
            model.DataFinalPeriodoCompras = this.DataFinalPeriodoCompras;
            model.DataSorteio = this.DataSorteio;
            model.ResumoRegulamento = this.ResumoRegulamento;
            model.CertificadoAutorizacao = this.CertificadoAutorizacao;
            model.EmailSac = this.EmailSac;
            model.TelefoneSac = this.TelefoneSac;
            model.EmpresaId = this.EmpresaId;
            model.TipoCampanha = this.TipoCampanha;
            model.IsMaior18Anos = this.IsMaior18Anos;
            model.IsLimiteGeografico = this.IsLimiteGeografico;
            model.Estado = this.Estado;
            model.Cidade = this.Cidade;
            model.Bairro = this.Bairro;
            model.IsLimiteTrocasNF = this.IsLimiteTrocasNF;
            model.ValorLimiteNF = this.ValorLimiteNF;
            model.QuantidadeLimiteNF = this.QuantidadeLimiteNF;
            model.IsLimiteGeneroSexual = this.IsLimiteGeneroSexual;
            model.GeneroSexual = this.GeneroSexual;
            model.IsBloquearFuncionario = this.IsBloquearFuncionario;
            model.CpfsBloqueados = this.CpfsBloqueados;
            model.RegraParticipacao = this.RegraParticipacao;
            model.CampanhaLayoutId = this.CampanhaLayoutId;
            model.Ativa = this.Ativa;
            model.UrlImagemGanhadores = this.UrlImagemGanhadores;
            model.DataEnvioNF = this.DataEnvioNF;
            model.DataVencimento = this.DataVencimento;

            return model;
        }
    }
}
