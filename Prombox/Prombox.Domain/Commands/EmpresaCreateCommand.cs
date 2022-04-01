using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Commands
{
    public class EmpresaCreateCommand : Command
    {
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
                RazaoSocialFaturamento = this.RazaoSocialFaturamento
            };

            return model;
        }
    }
}
