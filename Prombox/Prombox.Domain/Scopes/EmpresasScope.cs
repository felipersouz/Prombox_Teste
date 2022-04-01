using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Scopes
{
    public static class EmpresasScope
    {
        public static List<string> CreateValidate(this Empresa model)
        {
            var errors = new List<string>();

            if (String.IsNullOrEmpty(model.NomeFantasia)) errors.Add("Nome fantasia é requerido.");
            if (!String.IsNullOrEmpty(model.NomeFantasia) && model.NomeFantasia.Length > 60) errors.Add("Nome fantasia é inválido.");

            if (String.IsNullOrEmpty(model.RazaoSocial)) errors.Add("Razão social é requerido.");
            if (!String.IsNullOrEmpty(model.RazaoSocial) && model.RazaoSocial.Length > 60) errors.Add("Razão social é inválido.");

            if (!String.IsNullOrEmpty(model.Cnpj) && model.Cnpj.Length > 18) errors.Add("CNPJ é inválido.");
            if (!String.IsNullOrEmpty(model.InscricaoMunicipal) && model.InscricaoMunicipal.Length > 20) errors.Add("Inscrição municipal é inválido.");
            if (!String.IsNullOrEmpty(model.InscricaoEstadual) && model.InscricaoEstadual.Length > 20) errors.Add("Inscrição estadual é inválido.");
            if (!String.IsNullOrEmpty(model.Telefone) && model.Telefone.Length > 20) errors.Add("Telefone é inválido.");
            if (!String.IsNullOrEmpty(model.UrlSite) && model.UrlSite.Length > 255) errors.Add("Site é inválido.");
            if (!String.IsNullOrEmpty(model.Logradouro) && model.Logradouro.Length > 60) errors.Add("Logradouro é inválido.");
            if (!String.IsNullOrEmpty(model.Numero) && model.Numero.Length > 20) errors.Add("Número é inválido.");
            if (!String.IsNullOrEmpty(model.Complemento) && model.Complemento.Length > 60) errors.Add("Complemento é inválido.");
            if (!String.IsNullOrEmpty(model.Bairro) && model.Bairro.Length > 60) errors.Add("Bairro é inválido.");
            if (!String.IsNullOrEmpty(model.Cidade) && model.Cidade.Length > 60) errors.Add("Cidade é inválida.");
            if (!String.IsNullOrEmpty(model.Uf) && model.Uf.Length > 2) errors.Add("UF é inválido.");
            if (!String.IsNullOrEmpty(model.Observacoes) && model.Observacoes.Length > 255) errors.Add("Observações é inválido.");
            if (!String.IsNullOrEmpty(model.UrlFacebook) && model.UrlFacebook.Length > 1000) errors.Add("Facebook é inválido.");
            if (!String.IsNullOrEmpty(model.UrlTwitter) && model.UrlTwitter.Length > 255) errors.Add("Twitter é inválido.");
            if (!String.IsNullOrEmpty(model.UrlYoutube) && model.UrlYoutube.Length > 255) errors.Add("Youtube é inválido.");
            if (!String.IsNullOrEmpty(model.UrlInstagram) && model.UrlInstagram.Length > 255) errors.Add("Instagram é inválido.");
            if (!String.IsNullOrEmpty(model.UrlLinkedin) && model.UrlLinkedin.Length > 255) errors.Add("Linkedin é inválido.");

            if (!String.IsNullOrEmpty(model.CnpjFaturamento) && model.CnpjFaturamento.Length > 18) errors.Add("CNPJ para faturamento é inválido.");
            if (!String.IsNullOrEmpty(model.RazaoSocialFaturamento) && model.RazaoSocialFaturamento.Length > 60) errors.Add("Razão social para faturamento é inválido.");

            return errors;
        }

        public static List<string> UpdateValidate(this Empresa model)
        {
            var errors = model.CreateValidate();
            return errors;
        }
    }
}
