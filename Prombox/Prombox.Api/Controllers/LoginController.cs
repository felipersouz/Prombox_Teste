using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Prombox.Domain.Commands;
using Prombox.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prombox.Web.Controllers;
using Prombox.Domain.Entities;
using Prombox.Web.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace Prombox.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class LoginController : BaseController
    {
        private readonly ILoginService _service;
        private readonly IUsuariosService _usuariosService;
        private readonly ICurrentUser _currentUser;
        private readonly IConfiguration _configuration;

        public LoginController(
            ILoginService service,
            IUsuariosService usuariosService,
            ICurrentUser currentUser,
            IConfiguration configuration)
        {
            _service = service;
            _usuariosService = usuariosService;
            _currentUser = currentUser;
            _configuration = configuration;
        }

        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [HttpPost]
        public ActionResult Post([FromBody] LoginCommand command)
        {
            var commandResult = _service.Autenticate(command);

            if (commandResult.Errors.Count > 0)
                return BadRequest(commandResult.Errors);

            var token = (commandResult.Model != null && commandResult.Errors.Count == 0) ? GenerateToken(commandResult.Model) : null;

            return Ok(new { token = token });
        }

        private string GenerateToken(Usuario usuario)
        {
            var signingConfiguration = new SigningConfiguration(_configuration);
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenConfiguration = new TokenConfiguration();
            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                _configuration.GetSection("TokenConfiguration"))
                    .Configure(tokenConfiguration);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", usuario.Id.ToString()),
                    new Claim("nome", usuario.Nome),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim("tipoUsuarioId", ((int)usuario.TipoUsuario).ToString()),
                    new Claim("empresaId", usuario.EmpresaId.HasValue? ((int)usuario.EmpresaId).ToString() : "")
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = signingConfiguration.SigningCredentials,
                Audience = tokenConfiguration.Audience,
                Issuer = tokenConfiguration.Issuer,

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
