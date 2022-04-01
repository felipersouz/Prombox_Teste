using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Prombox.Domain.Commands;
using Prombox.Domain.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SiteFrontEnd.Controllers
{
    [Area("cliente")]
    
    public class CadastroController : Controller
    {
        private readonly IUsuariosClientesService _service;
        private readonly IConfiguration _configuration;

        public CadastroController(
            IUsuariosClientesService service,
            IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("cliente/dados-pessoais")]
        public IActionResult Index()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

            // Pego o usuário logado
            bool isAutenticado = HttpContext.Session.GetInt32("IsAutenticado") == 1;

            if (!isAutenticado)
                return RedirectToAction("Index", "Login");

            long usuarioClienteId = long.Parse(HttpContext.Session.GetString("UsuarioClienteId"));

            var item = _service.GetById(usuarioClienteId);

            return View("Cadastro", item);
        }

        [HttpPost]
        [Route("cliente/dados-pessoais")]
        public IActionResult Cadastro([FromBody] UsuarioClienteUpdateCommand command)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

            if (command == null || string.IsNullOrEmpty(command.Nome))
                return BadRequest();

            // Pego o usuário logado
            bool isAutenticado = HttpContext.Session.GetInt32("IsAutenticado") == 1;
            command.EmpresaId = int.Parse(_configuration["EmpresaId"]);


            if (!isAutenticado)
                return Forbid();

            long usuarioClienteId = long.Parse(HttpContext.Session.GetString("UsuarioClienteId"));
            command.Id = usuarioClienteId;

            var result = _service.Update(command);

            if (result.Errors.Count == 0)
            {
                HttpContext.Session.SetInt32("IsAutenticado", 1);
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost]
        [Route("cliente/alterar-senha")]
        public IActionResult AlterarSenha([FromBody] AlterarSenhaCommand command)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

            if (command == null || string.IsNullOrEmpty(command.SenhaAtual))
                return BadRequest();

            // Pego o usuário logado
            bool isAutenticado = HttpContext.Session.GetInt32("IsAutenticado") == 1;

            if (!isAutenticado)
                return RedirectToAction("Index", "Login");

            long usuarioClienteId = long.Parse(HttpContext.Session.GetString("UsuarioClienteId"));


            var result = _service.AlterarSenha(command, usuarioClienteId);

            if (result.Errors.Count == 0)
            {                
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

    }
}
