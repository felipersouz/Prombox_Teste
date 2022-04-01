using Prombox.Domain.Commands;
using Prombox.Domain.Commands.Results;
using Prombox.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Domain.Services
{
    public interface IUsuariosService
    {
        List<string> AlterarSenha(AlterarSenhaCommand command);
        List<string> RecuperarSenha(RecuperarSenhaCommand command);
        List<string> EsqueciSenha(EsqueciSenhaCommand command);
        UsuarioCreateCommandResult Create(UsuarioCreateCommand command);
        UsuarioDeleteCommandResult Delete(UsuarioDeleteCommand command);
        UsuarioUpdateCommandResult Update(UsuarioUpdateCommand command);
        Usuario GetById(long id);
        List<Usuario> GetAll(string nome, int start, int limit, out int total);
    }
}
