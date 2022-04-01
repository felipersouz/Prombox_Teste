using Prombox.Domain.Commands;
using Prombox.Domain.Commands.Results;
using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Services
{
    public interface ICampanhasService
    {
        CampanhaCreateCommandResult Create(CampanhasCreateCommand commnad);
        CampanhaUpdateCommandResult Update(CampanhasUpdateCommand command);
        CampanhaDeleteCommandResult Delete(CampanhaDeleteCommand command);
        CommandResult UpdateAderentes(UpdateAderentesCommand command);
        Campanha GetById(int id);
        List<Campanha> GetAll(int empresaId);
        List<Campanha> GetAll(int? empresaId, string nome, int start, int limit, out int total);

        CampanhaUpdateCommandResult UpdateDataInicioCampanha(CampanhasUpdateCommand command);
        CampanhaUpdateCommandResult UpdateDataFinalCampanha(CampanhasUpdateCommand command);
        CampanhaUpdateCommandResult UpdateDataLimiteCadastro(CampanhasUpdateCommand command);
        CampanhaUpdateCommandResult UpdateDataInicioPeriodoCompras(CampanhasUpdateCommand command);
        CampanhaUpdateCommandResult UpdateDataFinalPeriodoCompras(CampanhasUpdateCommand command);
        CampanhaUpdateCommandResult UpdateDataSorteio(CampanhasUpdateCommand command);
        CampanhaUpdateCommandResult UpdateResumoRegulamento(CampanhasUpdateCommand command);
        CampanhaUpdateCommandResult UpdateCertificadoAutorizacao(CampanhasUpdateCommand command);
        CampanhaUpdateCommandResult UpdateEmailSac(CampanhasUpdateCommand command);
        CampanhaUpdateCommandResult UpdateTelefoneSac(CampanhasUpdateCommand command);
        CampanhaUpdateCommandResult UpdateEmpresaId(CampanhasUpdateCommand command);
        CampanhaUpdateCommandResult UpdateTipoCampanha(CampanhasUpdateCommand command);
        CampanhaUpdateCommandResult UpdateIsMaior18Anos(CampanhasUpdateCommand command);
        CampanhaUpdateCommandResult UpdateIsLimiteGeografico(CampanhasUpdateCommand command);
        CampanhaUpdateCommandResult UpdateEstado(CampanhasUpdateCommand command);
        CampanhaUpdateCommandResult UpdateCidade(CampanhasUpdateCommand command);
        CampanhaUpdateCommandResult UpdateBairro(CampanhasUpdateCommand command);
        CampanhaUpdateCommandResult UpdateIsLimiteTrocasNf(CampanhasUpdateCommand command);
        CampanhaUpdateCommandResult UpdateValorLimiteNf(CampanhasUpdateCommand command);
        CampanhaUpdateCommandResult UpdateQuantidadeLimiteNf(CampanhasUpdateCommand command);
        CampanhaUpdateCommandResult UpdateIsLimiteGeneroSexual(CampanhasUpdateCommand command);
        CampanhaUpdateCommandResult UpdateGeneroSexual(CampanhasUpdateCommand command);
        CampanhaUpdateCommandResult UpdateIsBloquearFuncionario(CampanhasUpdateCommand command);
        CampanhaUpdateCommandResult UpdateRegraParticipacao(CampanhasUpdateCommand command);
        CampanhaUpdateCommandResult UpdateUrlImagemGanhadores(CampanhasUpdateCommand command);

        event EventHandler<CampanhasCreateEventArgs> CreateEventHandler;
        event EventHandler<CampanhasUpdateEventArgs> UpdateEventHandler;
        event EventHandler<CampanhasDeleteEventArgs> DeleteEventHandler;
    }
}
