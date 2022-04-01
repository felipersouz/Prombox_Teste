using System;
using System.Collections.Generic;

namespace Prombox.Domain.Entities
{
    public class Empresa
    {
        public Empresa()
        {
            Contatos = new List<Contato>();
            Aderentes = new List<Aderente>();
            Usuarios = new List<Usuario>();
        }

        public int Id { get; set; }
        public bool Ativa { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string Telefone { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string InscricaoEstadual { get; set; }
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
        public bool? PrecisaOrdemCompra { get; set; }
        public string RazaoSocialFaturamento { get; set; }
        public DateTime? DataEnvioNF { get; set; }
        public DateTime? DataVencimento { get; set; }

        public List<Contato> Contatos { get; set; }
        public List<Aderente> Aderentes { get; set; }
        public List<Usuario> Usuarios { get; set; }

        public dynamic ToJson()
        {
            return new
            {
                this.Id,
                this.Ativa,
                this.RazaoSocial,
                this.NomeFantasia,
                this.Cnpj,
                this.Telefone,
                this.InscricaoMunicipal,
                this.InscricaoEstadual,
                this.UrlSite,
                this.Cep,
                this.Logradouro,
                this.Numero,
                this.Complemento,
                this.Bairro,
                this.Cidade,
                this.Uf,
                this.Observacoes,
                this.UrlFacebook,
                this.UrlTwitter,
                this.UrlInstagram,
                this.UrlYoutube,
                this.UrlLinkedin,
                this.CnpjFaturamento,
                this.PrecisaOrdemCompra,
                this.RazaoSocialFaturamento,
                this.DataEnvioNF,
                this.DataVencimento,
            };
        }

    }
}
