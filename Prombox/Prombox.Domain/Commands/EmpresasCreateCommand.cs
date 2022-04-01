using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Commands
{
    public class EmpresasCreateCommand : Command
    {
        public bool Ativa { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        private string cnpj;
        public string Cnpj
        {
            get { return !string.IsNullOrEmpty(cnpj) ? cnpj.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "") : null; }
            set { cnpj = value; }
        }
        private string telefone;
        public string Telefone
        {
             get { return !String.IsNullOrEmpty(telefone) ? telefone.Replace(".", "").Replace("(", "").Replace(")", "").Replace(" ", "") : null; }
            set { telefone = value; }
        }
        public string InscricaoMunicipal { get; set; }
        public string InscricaoEstadual { get; set; }
        public string UrlSite { get; set; }
        private string cep;
        public string Cep
        {
             get { return !string.IsNullOrEmpty(cep) ? cep.Replace("-", "").Replace(" ", "") : null; }
            set { cep = value; }
        }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Observacoes { get; set; }
        public string UrlFacebook { get; set; }
        public string UrlTwitter { get; set; }
        public string UrlInstagram { get; set; }
        public string UrlYoutube { get; set; }
        public string UrlLinkedin { get; set; }
        private string cnpjFaturamento;
        public string CnpjFaturamento
        {
           get { return !string.IsNullOrEmpty(cnpjFaturamento) ? cnpjFaturamento.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "") : null; }
            set { cnpjFaturamento = value; }
        }
        public bool PrecisaOrdemCompra { get; set; }
        public string RazaoSocialFaturamento { get; set; }
        public DateTime? DataEnvioNF { get; set; }
        public DateTime? DataVencimento { get; set; }

        public Empresa ToModel()
        {
            var model = new Empresa
            {
                Ativa = this.Ativa,
                RazaoSocial = this.RazaoSocial,
                NomeFantasia = this.NomeFantasia,
                Cnpj = this.Cnpj,
                Telefone = this.Telefone,
                InscricaoMunicipal = this.InscricaoMunicipal,
                InscricaoEstadual = this.InscricaoEstadual,
                UrlSite = this.UrlSite,
                Cep = this.Cep,
                Logradouro = this.Logradouro,
                Numero = this.Numero,
                Complemento = this.Complemento,
                Bairro = this.Bairro,
                Cidade = this.Cidade,
                Uf = this.Uf,
                Observacoes = this.Observacoes,
                UrlFacebook = this.UrlFacebook,
                UrlTwitter = this.UrlTwitter,
                UrlInstagram = this.UrlInstagram,
                UrlYoutube = this.UrlYoutube,
                UrlLinkedin = this.UrlLinkedin,
                CnpjFaturamento = this.CnpjFaturamento,
                PrecisaOrdemCompra = this.PrecisaOrdemCompra,
                RazaoSocialFaturamento = this.RazaoSocialFaturamento,
                DataEnvioNF = this.DataEnvioNF,
                DataVencimento = this.DataVencimento
            };

            return model;
        }
    }
}
