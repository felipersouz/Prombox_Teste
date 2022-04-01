using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Prombox.Domain.Commands;
using Prombox.Domain.Entities;
using Prombox.Domain.Services;
using Prombox.Service.Services;

namespace SiteFrontEnd.Controllers
{
    [Route("cadastre-se")]
    public class CadastreSeController : Controller
    {
        private const int PAGE_SIZE = 50;
        private readonly IUsuariosClientesService _service;
        private readonly IConfiguration _configuration;

        public CadastreSeController(
            IUsuariosClientesService service,
            IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            // Se o usuário ja esitver logado joga pra Home
            if (this.HttpContext.Session.GetInt32("IsAutenticado").Equals(1))
                return RedirectToAction("Index", "Home");

            return View("CadastreSe");
        }

        [Route("ValidaSimples")]
        public IActionResult ValidaSimples()
        {
            return View("ValidaSimples");
        }

        [HttpPost]
        [Route("check-cpf-cadastrado")]
        public IActionResult CheckCpfCadastrado([FromBody] StringCommand command)
        {
            if (command.Value == null)
                return BadRequest();

            //Capturo a empresa da configuração
            var empresaId = int.Parse(_configuration["EmpresaId"]);
          
            return Ok(_service.CheckCpfCadastrado(command.Value, empresaId));
        }

        [HttpPost]
        public IActionResult Cadastro([FromBody] UsuarioClienteCreateCommand command)
        {

            if (command == null || string.IsNullOrEmpty(command.Nome))
                return BadRequest();

            //Capturo a empresa da configuração
            var empresaId = int.Parse(_configuration["EmpresaId"]);            
            command.EmpresaId = empresaId;            
                        
            var result = _service.Create(command);

            if (result.Errors.Count == 0)
            {
                HttpContext.Session.SetInt32("IsAutenticado", 1);
                HttpContext.Session.SetString("UsuarioClienteId", result.Model.Id.ToString());
                result.Model = null;

                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

    }
}
