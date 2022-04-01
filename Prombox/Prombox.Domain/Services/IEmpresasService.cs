using Prombox.Domain.Commands;
using Prombox.Domain.Commands.Results;
using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Services
{
    public interface IEmpresasService
    {
        EmpresaCreateCommandResult Create(EmpresaCreateCommand commnad);
        EmpresaUpdateCommandResult Update(EmpresaUpdateCommand command);
        EmpresaDeleteCommandResult Delete(EmpresaDeleteCommand command);
        Empresa GetById(int id);
        List<Empresa> GetAll();
        List<Empresa> GetAll(string nome, int start, int limit, out int total);
        
        EmpresaUpdateCommandResult UpdateAtiva(EmpresaUpdateCommand command);
        EmpresaUpdateCommandResult UpdateRazaoSocial(EmpresaUpdateCommand command);
        EmpresaUpdateCommandResult UpdateNomeFantasia(EmpresaUpdateCommand command);
        EmpresaUpdateCommandResult UpdateCnpj(EmpresaUpdateCommand command);
        EmpresaUpdateCommandResult UpdateTelefone(EmpresaUpdateCommand command);
        EmpresaUpdateCommandResult UpdateInscricaoMunicipal(EmpresaUpdateCommand command);
        EmpresaUpdateCommandResult UpdateUrlSite(EmpresaUpdateCommand command);
        EmpresaUpdateCommandResult UpdateCep(EmpresaUpdateCommand command);
        EmpresaUpdateCommandResult UpdateLogradouro(EmpresaUpdateCommand command);
        EmpresaUpdateCommandResult UpdateNumero(EmpresaUpdateCommand command);
        EmpresaUpdateCommandResult UpdateComplemento(EmpresaUpdateCommand command);
        EmpresaUpdateCommandResult UpdateBairro(EmpresaUpdateCommand command);
        EmpresaUpdateCommandResult UpdateCidade(EmpresaUpdateCommand command);
        EmpresaUpdateCommandResult UpdateUf(EmpresaUpdateCommand command);
        EmpresaUpdateCommandResult UpdateObservacoes(EmpresaUpdateCommand command);
        EmpresaUpdateCommandResult UpdateUrlFacebook(EmpresaUpdateCommand command);
        EmpresaUpdateCommandResult UpdateUrlTwitter(EmpresaUpdateCommand command);
        EmpresaUpdateCommandResult UpdateUrlInstagram(EmpresaUpdateCommand command);
        EmpresaUpdateCommandResult UpdateUrlYoutube(EmpresaUpdateCommand command);
        EmpresaUpdateCommandResult UpdateUrlLinkedin(EmpresaUpdateCommand command);
        EmpresaUpdateCommandResult UpdateCnpjFaturamento(EmpresaUpdateCommand command);
        EmpresaUpdateCommandResult UpdatePrecisaOrdemCompra(EmpresaUpdateCommand command);
        EmpresaUpdateCommandResult UpdateRazaoSocialFaturamento(EmpresaUpdateCommand command);

        event EventHandler<EmpresasCreateEventArgs> CreateEventHandler;
        event EventHandler<EmpresasUpdateEventArgs> UpdateEventHandler;
        event EventHandler<EmpresasDeleteEventArgs> DeleteEventHandler;
    }
}
