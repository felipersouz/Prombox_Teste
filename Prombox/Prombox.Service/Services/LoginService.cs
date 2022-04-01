using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Prombox.Domain.Commands;
using Prombox.Domain.Commands.Results;
using Prombox.Domain.Entities;
using Prombox.Domain.Repositories;
using Prombox.Domain.Services;
using Prombox.Infra.Transaction;
using PromboxUtil.Cryptography;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Prombox.Service.Services
{
    public class LoginService : BaseService, ILoginService
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioRepository _repository;

        public LoginService(IUnitOfWork uow, IConfiguration configuration, IUsuarioRepository repository) : base(uow)
        {
            _configuration = configuration;
            _repository = repository;
        }

        public AutenticateCommandResult Autenticate(LoginCommand command)
        {
            var errors = new List<string>();
            var usuario = _repository.GetByEmail(command.Login);

            if (usuario == null)
                errors.Add("E-mail ou senha inválidos.");
            else
            {
                var encrypted = Criptografia.CalcularMD5Hash(command.Senha);

                if (usuario.Senha != encrypted)
                    errors.Add("E-mail ou senha inválidos.");
            }

            if (errors.Count == 0)
            {
                if (!usuario.Ativo) errors.Add("Usuário com status inativo.");
            }

            return new AutenticateCommandResult
            {
                Errors = errors,
                Model = usuario
            };
        }

       
    }
}
