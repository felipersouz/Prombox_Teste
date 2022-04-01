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

namespace SiteFrontEnd.Areas.cliente.Controllers
{
    [Area("cliente")]    
    
    public class NotasController : Controller
    {
        private readonly INotasFiscaisService _service;
        private readonly IConfiguration _configuration;


        public NotasController(
            INotasFiscaisService service,
            IConfiguration configuration)
        {

            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");

            _service = service;
            _configuration = configuration;
        }

        [Route("cliente/notas")]
        // Notas Enviadas / Minhas Notas        
        public IActionResult Index()
        {
            // Pego o usuário logado
            bool isAutenticado = HttpContext.Session.GetInt32("IsAutenticado") == 1;

            if (!isAutenticado)
                return RedirectToAction("Index", "Login");

            long usuarioClienteId = long.Parse(HttpContext.Session.GetString("UsuarioClienteId"));

            //Capturo a empresa da configuração
            int campanhaId = int.Parse(_configuration["CampanhaId"]);

            ViewBag.TotalNotas = _service.GetTotalNotasByUsuarioClienteCampanha(usuarioClienteId, campanhaId);

            var result = _service.GetByUsuarioClienteCampanha(usuarioClienteId, campanhaId);            

            return View("Listar", result);
        }

        [Route("cliente/notas/cadastrar")]
        public IActionResult Cadastrar()
        {
            // Pego o usuário logado
            bool isAutenticado = HttpContext.Session.GetInt32("IsAutenticado") == 1;

            if (!isAutenticado)
               return RedirectToAction("Index", "Login");

            return View("Cadastrar");
        }

        [HttpPost]
        [Route("cliente/notas/inserir")]
        public ActionResult Post([FromBody] NotaFiscalCreateCommand command)
        {
            if (command == null)
                return BadRequest();

            // Pego o usuário logado
            bool isAutenticado = HttpContext.Session.GetInt32("IsAutenticado") == 1;

            if (!isAutenticado)
                RedirectToAction("Index", "Login");


            long usuarioClienteId = long.Parse(HttpContext.Session.GetString("UsuarioClienteId"));

            //Capturo a empresa da configuração
            int campanhaId = int.Parse(_configuration["CampanhaId"]);

            command.CampanhaId = campanhaId;
            command.UsuarioClienteId = usuarioClienteId;

            string[] dt = command.Data.Split("/");

            var diaNota = new DateTime(int.Parse(dt[2]), int.Parse(dt[1]), int.Parse(dt[0]));
            command.DT = diaNota;
            var result = _service.Create(command);

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
