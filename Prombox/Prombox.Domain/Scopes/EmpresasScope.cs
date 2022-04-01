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

            if (String.IsNullOrEmpty(model.NomeFantasia)) errors.Add("Nome fantasia � requerido.");
            if (!String.IsNullOrEmpty(model.NomeFantasia) && model.NomeFantasia.Length > 60) errors.Add("Nome fantasia � inv�lido.");

            if (String.IsNullOrEmpty(model.RazaoSocial)) errors.Add("Raz�o social � requerido.");
            if (!String.IsNullOrEmpty(model.RazaoSocial) && model.RazaoSocial.Length > 60) errors.Add("Raz�o social � inv�lido.");

            if (!String.IsNullOrEmpty(model.Cnpj) && model.Cnpj.Length > 18) errors.Add("CNPJ � inv�lido.");
            if (!String.IsNullOrEmpty(model.InscricaoMunicipal) && model.InscricaoMunicipal.Length > 20) errors.Add("Inscri��o municipal � inv�lido.");
            if (!String.IsNullOrEmpty(model.InscricaoEstadual) && model.InscricaoEstadual.Length > 20) errors.Add("Inscri��o estadual � inv�lido.");
            if (!String.IsNullOrEmpty(model.Telefone) && model.Telefone.Length > 20) errors.Add("Telefone � inv�lido.");
            if (!String.IsNullOrEmpty(model.UrlSite) && model.UrlSite.Length > 255) errors.Add("Site � inv�lido.");
            if (!String.IsNullOrEmpty(model.Logradouro) && model.Logradouro.Length > 60) errors.Add("Logradouro � inv�lido.");
            if (!String.IsNullOrEmpty(model.Numero) && model.Numero.Length > 20) errors.Add("N�mero � inv�lido.");
            if (!String.IsNullOrEmpty(model.Complemento) && model.Complemento.Length > 60) errors.Add("Complemento � inv�lido.");
            if (!String.IsNullOrEmpty(model.Bairro) && model.Bairro.Length > 60) errors.Add("Bairro � inv�lido.");
            if (!String.IsNullOrEmpty(model.Cidade) && model.Cidade.Length > 60) errors.Add("Cidade � inv�lida.");
            if (!String.IsNullOrEmpty(model.Uf) && model.Uf.Length > 2) errors.Add("UF � inv�lido.");
            if (!String.IsNullOrEmpty(model.Observacoes) && model.Observacoes.Length > 255) errors.Add("Observa��es � inv�lido.");
            if (!String.IsNullOrEmpty(model.UrlFacebook) && model.UrlFacebook.Length > 1000) errors.Add("Facebook � inv�lido.");
            if (!String.IsNullOrEmpty(model.UrlTwitter) && model.UrlTwitter.Length > 255) errors.Add("Twitter � inv�lido.");
            if (!String.IsNullOrEmpty(model.UrlYoutube) && model.UrlYoutube.Length > 255) errors.Add("Youtube � inv�lido.");
            if (!String.IsNullOrEmpty(model.UrlInstagram) && model.UrlInstagram.Length > 255) errors.Add("Instagram � inv�lido.");
            if (!String.IsNullOrEmpty(model.UrlLinkedin) && model.UrlLinkedin.Length > 255) errors.Add("Linkedin � inv�lido.");

            if (!String.IsNullOrEmpty(model.CnpjFaturamento) && model.CnpjFaturamento.Length > 18) errors.Add("CNPJ para faturamento � inv�lido.");
            if (!String.IsNullOrEmpty(model.RazaoSocialFaturamento) && model.RazaoSocialFaturamento.Length > 60) errors.Add("Raz�o social para faturamento � inv�lido.");

            return errors;
        }

        public static List<string> UpdateValidate(this Empresa model)
        {
            var errors = model.CreateValidate();
            return errors;
        }
    }
}
