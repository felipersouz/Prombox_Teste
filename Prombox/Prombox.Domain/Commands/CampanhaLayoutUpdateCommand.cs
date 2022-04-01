using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Commands
{
    public class CampanhaLayoutUpdateCommand : Command
    {
        public int Id { get; set; }
        public int CampanhaId { get; set; }
        public string UrlLogo { get; set; }
        public string UrlCampanha { get; set; }
        public string UrlRegulamento { get; set; }
        public string UrlInstagram { get; set; }
        public string UrlComoParticipar { get; set; }
        public string UrlFacebook { get; set; }
        public string UrlBanner1 { get; set; }
        public string UrlBanner2 { get; set; }
        public string UrlBanner3 { get; set; }
        public string CorFundoSite { get; set; }
        public string CorBotoes { get; set; }
        public string CorCabecalhoRodape { get; set; }

        public bool ExcluirUrlLogo { get; set; }
        public bool ExcluirUrlCampanha { get; set; }
        public bool ExcluirUrlRegulamento { get; set; }
        public bool ExcluirUrlComoParticipar { get; set; }
        public bool ExcluirUrlBanner1 { get; set; }
        public bool ExcluirUrlBanner2 { get; set; }
        public bool ExcluirUrlBanner3 { get; set; }

        public CampanhaLayout ToModel(CampanhaLayout model)
        {
            model.Id = this.Id;
            model.CampanhaId = this.CampanhaId;
            model.UrlLogo = this.UrlLogo;
            model.UrlCampanha = this.UrlCampanha;
            model.UrlRegulamento = this.UrlRegulamento;
            model.UrlInstagram = this.UrlInstagram;
            model.UrlComoParticipar = this.UrlComoParticipar;
            model.UrlFacebook = this.UrlFacebook;
            model.UrlBanner1 = this.UrlBanner1;
            model.UrlBanner2 = this.UrlBanner2;
            model.UrlBanner3 = this.UrlBanner3;
            model.CorFundoSite = this.CorFundoSite;
            model.CorBotoes = this.CorBotoes;
            model.CorCabecalhoRodape = this.CorCabecalhoRodape;

            if (ExcluirUrlLogo) model.UrlLogo = null;
            if (ExcluirUrlCampanha) model.UrlCampanha = null;
            if (ExcluirUrlRegulamento) model.UrlRegulamento = null;
            if (ExcluirUrlComoParticipar) model.UrlComoParticipar = null;
            if (ExcluirUrlBanner1) model.UrlBanner1 = null;
            if (ExcluirUrlBanner2) model.UrlBanner2 = null;
            if (ExcluirUrlBanner3) model.UrlBanner3 = null;

            return model;
        }
    }
}
