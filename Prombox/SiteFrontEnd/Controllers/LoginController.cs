using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Prombox.Domain.Commands;
using Prombox.Domain.Entities;
using Prombox.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteFrontEnd.Controllers
{
    
    public class LoginController : Controller
    {
        private readonly IUsuariosClientesService _service;
        private readonly IConfiguration _configuration;

        public LoginController(IUsuariosClientesService service,
            IConfiguration configuration)
        {
            this._service = service;
            this._configuration = configuration;
        }

        [Route("login")]
        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpGet]
        [Route("login/logout")]
        public IActionResult Logout()
        {                        
            HttpContext.Session.Remove("IsAutenticado");
            HttpContext.Session.Remove("UsuarioClienteId");
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] LoginCommand command)
        {
            try
            {
                HttpContext.Session.Remove("IsAutenticado");

                command.EmpresaId = int.Parse(_configuration["EmpresaId"]);


                var commandResult = _service.Autenticate(command);

                if (commandResult.Errors.Count > 0)
                    return BadRequest(commandResult.ToJson());
                else
                {
                    // Atualiza a Session
                    HttpContext.Session.SetInt32("IsAutenticado", 1);                    
                    HttpContext.Session.SetString("UsuarioClienteId", commandResult.Model.Id.ToString());
                    return Ok(commandResult.ToJson());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        [Route("login/recuperar-senha")]
        public IActionResult PostRecuperarSenha([FromBody] RecuperarSenhaCommand command)
        {
            try
            {               
                var errors = _service.RecuperarSenha(command);

                if (errors.Count > 0)
                    return BadRequest(errors);
                else
                    return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        [Route("esqueci-minha-senha")]
        public IActionResult EsqueceuSenha()
        {
            return View("EsqueceuSenha");
        }

        [HttpPost]
        [Route("login/esqueci-minha-senha")]
        public IActionResult PostEsqueceuSenha([FromBody] EsqueciSenhaCommand2 command)
        {
            try
            {
                HttpContext.Session.Remove("IsAutenticado");                
                command.CampanhaId = int.Parse(_configuration["CampanhaId"]);

                UsuarioCliente usuarioCliente = null;

                var errors = _service.EsqueceuSenha(command, out usuarioCliente);

                if (errors.Count > 0)
                    return BadRequest(errors);
                else
                {
                    //// Mascara o Email do candango
                    //var emailPart = usuarioCliente.Email.Split("@");

                    //string parte1 = emailPart[0].Substring(0, 2) + "***@";
                    //string parte2 = emailPart[1].Substring(0, 2) + "***";
                    //string parte3 = emailPart[1].Substring(emailPart[1].IndexOf("."));

                    dynamic objRetorno = new
                    {
                        email = usuarioCliente.Email //parte1 + parte2 + parte3
                    };

                    return Ok(objRetorno);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        
        [HttpGet]
        [Route("recuperar-senha")]
        public IActionResult RecuperarSenha()
        {
            return View("RecuperarSenha");
        }

        [HttpGet]
        [Route("codigo-autenticacao/{codeEncrypt?}")]
        public IActionResult CodigoAutenticacao(string codeEncrypt="")
        {
            return View("CodigoAutenticacao");
        }
    }
}
