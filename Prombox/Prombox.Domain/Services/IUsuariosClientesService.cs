using Prombox.Domain.Commands;
using Prombox.Domain.Commands.Results;
using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prombox.Domain.Services
{
    public interface IUsuariosClientesService
    {
        UsuarioClienteCreateCommandResult Create(UsuarioClienteCreateCommand commnad);
        UsuarioClienteUpdateCommandResult Update(UsuarioClienteUpdateCommand command);
        UsuarioClienteDeleteCommandResult Delete(UsuarioClienteDeleteCommand command);
        CommandResult AlterarSenha(AlterarSenhaCommand command, long usuarioClienteId);
        UsuarioCliente GetById(long id);
        //void TestaEmail();
        List<UsuarioCliente> GetAll();
        List<UsuarioCliente> GetAll(int start, int limit, out int total);
        UsuarioClienteUpdateCommandResult UpdateIsExcluido(UsuarioClienteUpdateCommand command);
        UsuarioClienteUpdateCommandResult UpdateUsuarioExclusao(UsuarioClienteUpdateCommand command);
        UsuarioClienteUpdateCommandResult UpdateDataHoraExclusao(UsuarioClienteUpdateCommand command);
        UsuarioClienteUpdateCommandResult UpdateEmail(UsuarioClienteUpdateCommand command);
        UsuarioClienteUpdateCommandResult UpdateHash(UsuarioClienteUpdateCommand command);
        UsuarioClienteUpdateCommandResult UpdatePepper(UsuarioClienteUpdateCommand command);
        bool CheckCpfCadastrado(string cpf, int empresaId);
        List<string> EsqueceuSenha(EsqueciSenhaCommand2 command, out UsuarioCliente usuarioCliente);

        List<string> RecuperarSenha(RecuperarSenhaCommand command);


        //UsuarioClienteUpdateCommandResult UpdateDataCadastro(UsuarioClienteUpdateCommand command);
        //UsuarioClienteUpdateCommandResult UpdateDataPrimeiroAcesso(UsuarioClienteUpdateCommand command);
        //UsuarioClienteUpdateCommandResult UpdateUltimaAlteracaoSenha(UsuarioClienteUpdateCommand command);

        UsuarioClienteUpdateCommandResult UpdateAtivo(UsuarioClienteUpdateCommand command);
        //UsuarioClienteUpdateCommandResult UpdateCodigoRecuperacaoSenha(UsuarioClienteUpdateCommand command);
        UsuarioClienteUpdateCommandResult UpdateBloqueadoAte(UsuarioClienteUpdateCommand command);
        AutenticateClienteCommandResult Autenticate(LoginCommand command);

        event EventHandler<UsuariosClientesCreateEventArgs> CreateEventHandler;
        event EventHandler<UsuariosClientesUpdateEventArgs> UpdateEventHandler;
        event EventHandler<UsuariosClientesDeleteEventArgs> DeleteEventHandler;
    }
}
