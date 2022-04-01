using Prombox.Domain.Commands;
using Prombox.Domain.Commands.Results;
using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Services
{
    public interface ICampanhasLayoutService
    {
        CampanhaLayoutCreateCommandResult Create(CampanhaLayoutCreateCommand commnad);
        CampanhaLayoutUpdateCommandResult Update(CampanhaLayoutUpdateCommand command);
        CampanhaLayoutDeleteCommandResult Delete(CampanhaLayoutDeleteCommand command);
        CampanhaLayout GetById(int id);
        CampanhaLayout GetByCampanhaId(int campanhaId);
        List<CampanhaLayout> GetAll();
        List<CampanhaLayout> GetAll(int start, int limit, out int total);

        CampanhaLayoutUpdateCommandResult UpdateCampanhaId(CampanhaLayoutUpdateCommand command);
        CampanhaLayoutUpdateCommandResult UpdateUrlLogo(CampanhaLayoutUpdateCommand command);
        CampanhaLayoutUpdateCommandResult UpdateUrlCampanha(CampanhaLayoutUpdateCommand command);
        CampanhaLayoutUpdateCommandResult UpdateUrlRegulamento(CampanhaLayoutUpdateCommand command);
        CampanhaLayoutUpdateCommandResult UpdateUrlInstagram(CampanhaLayoutUpdateCommand command);
        CampanhaLayoutUpdateCommandResult UpdateUrlComoParticipar(CampanhaLayoutUpdateCommand command);
        CampanhaLayoutUpdateCommandResult UpdateUrlFacebook(CampanhaLayoutUpdateCommand command);
        CampanhaLayoutUpdateCommandResult UpdateUrlBanner1(CampanhaLayoutUpdateCommand command);
        CampanhaLayoutUpdateCommandResult UpdateUrlBanner2(CampanhaLayoutUpdateCommand command);
        CampanhaLayoutUpdateCommandResult UpdateUrlBanner3(CampanhaLayoutUpdateCommand command);
        CampanhaLayoutUpdateCommandResult UpdateCorFundoSite(CampanhaLayoutUpdateCommand command);
        CampanhaLayoutUpdateCommandResult UpdateCorBotoes(CampanhaLayoutUpdateCommand command);
        CampanhaLayoutUpdateCommandResult UpdateCorCabecalhoRodape(CampanhaLayoutUpdateCommand command);


        event EventHandler<CampanhasLayoutCreateEventArgs> CreateEventHandler;
        event EventHandler<CampanhasLayoutUpdateEventArgs> UpdateEventHandler;
        event EventHandler<CampanhasLayoutDeleteEventArgs> DeleteEventHandler;
    }
}
