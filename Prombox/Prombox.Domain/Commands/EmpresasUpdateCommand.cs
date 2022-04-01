using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Commands
{
    public class EmpresasUpdateCommand : Command
    {
        public int Id { get; set; }
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

        public Empresa ToModel(Empresa model)
        {
            model.Id = this.Id;
            model.Ativa = this.Ativa;
            model.RazaoSocial = this.RazaoSocial;
            model.NomeFantasia = this.NomeFantasia;
            model.Cnpj = this.Cnpj;
            model.Telefone = this.Telefone;
            model.InscricaoMunicipal = this.InscricaoMunicipal;
            model.InscricaoEstadual = this.InscricaoEstadual;
            model.UrlSite = this.UrlSite;
            model.Cep = this.Cep;
            model.Logradouro = this.Logradouro;
            model.Numero = this.Numero;
            model.Complemento = this.Complemento;
            model.Bairro = this.Bairro;
            model.Cidade = this.Cidade;
            model.Uf = this.Uf;
            model.Observacoes = this.Observacoes;
            model.UrlFacebook = this.UrlFacebook;
            model.UrlTwitter = this.UrlTwitter;
            model.UrlInstagram = this.UrlInstagram;
            model.UrlYoutube = this.UrlYoutube;
            model.UrlLinkedin = this.UrlLinkedin;
            model.CnpjFaturamento = this.CnpjFaturamento;
            model.PrecisaOrdemCompra = this.PrecisaOrdemCompra;
            model.RazaoSocialFaturamento = this.RazaoSocialFaturamento;
            model.DataEnvioNF = this.DataEnvioNF;
            model.DataVencimento = this.DataVencimento;

            return model;
        }
    }
}
