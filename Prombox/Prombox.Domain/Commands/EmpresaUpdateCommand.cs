using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Commands
{
    public class EmpresaUpdateCommand : Command
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativa { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string UrlSite { get; set; }
        public string Cep { get; set; }
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
        public string CnpjFaturamento { get; set; }
        public bool PrecisaOrdemCompra { get; set; }
        public string RazaoSocialFaturamento { get; set; }

        public Empresa ToModel(Empresa model)
        {
            model.Id = this.Id;
            model.Ativa = this.Ativa;
            model.RazaoSocial = this.RazaoSocial;
            model.NomeFantasia = this.NomeFantasia;
            model.Cnpj = this.Cnpj;
            model.Telefone = this.Telefone;
            model.InscricaoMunicipal = this.InscricaoMunicipal;
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

            return model;
        }
    }
}
