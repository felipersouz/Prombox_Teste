using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Domain.Services
{
    public interface IMailService
    {        
        void NovoUsuarioCliente(string nome, string email, string cpf);
        void SenhaAlterada(string nome, string email, string cpf);
        void NovoUsuario(string nome, string email, string senha);
        void RecuperarSenha(string nome, string email, int code, string codeEncrypt);
        void RecuperarSenhaUsuarioCliente(string nome, string email, string cpf, int code, string codeEncrypt);
        void NovaSenha(string nome, string email, string novaSenha);
    }
}
