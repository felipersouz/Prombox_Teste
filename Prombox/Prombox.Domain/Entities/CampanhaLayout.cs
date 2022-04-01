using Prombox.Domain.Commands;

namespace Prombox.Domain.Entities
{
    public class CampanhaLayout
    {
        public int Id { get; set; }
        public int CampanhaId { get; set; }
        public Campanha Campanha { get; set; }
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

        public dynamic ToJson()
        {
            return new
            {
                Id,
                CampanhaId,
                UrlLogo,
                UrlCampanha,
                UrlRegulamento,
                UrlInstagram,
                UrlComoParticipar,
                UrlFacebook,
                UrlBanner1,
                UrlBanner2,
                UrlBanner3,
                CorFundoSite,
                CorBotoes,
                CorCabecalhoRodape,
            };
        }

        public CampanhaLayoutUpdateCommand ToCampanhasLayoutUpdateCommand()
        {
            return new CampanhaLayoutUpdateCommand
            {
                Id = this.Id,
                CampanhaId = this.CampanhaId,
                UrlLogo = this.UrlLogo,
                UrlCampanha = this.UrlCampanha,
                UrlRegulamento = this.UrlRegulamento,
                UrlInstagram = this.UrlInstagram,
                UrlComoParticipar = this.UrlComoParticipar,
                UrlFacebook = this.UrlFacebook,
                UrlBanner1 = this.UrlBanner1,
                UrlBanner2 = this.UrlBanner2,
                UrlBanner3 = this.UrlBanner3,
                CorFundoSite = this.CorFundoSite,
                CorBotoes = this.CorBotoes,
                CorCabecalhoRodape = this.CorCabecalhoRodape
            };
        }

    }
}
