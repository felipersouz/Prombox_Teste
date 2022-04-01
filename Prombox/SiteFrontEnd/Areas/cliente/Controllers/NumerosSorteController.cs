using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
    [Route("cliente/meus-numeros-da-sorte")]
    public class NumerosSorteController : Controller
    {
        private readonly INumeroDaSorteService _service;
        private readonly INotasFiscaisService _notasFiscaisService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<NumerosSorteController> _logger;


        public NumerosSorteController(
            ILogger<NumerosSorteController> logger,
            INumeroDaSorteService service,
            IConfiguration configuration,
            INotasFiscaisService notasFiscaisService)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR");
            _notasFiscaisService = notasFiscaisService;
            _service = service;
            _configuration = configuration;
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Pego o usuário logado
            bool isAutenticado = HttpContext.Session.GetInt32("IsAutenticado") == 1;

            if (!isAutenticado)
                return RedirectToAction("Index", "Login");

            long usuarioClienteId = long.Parse(HttpContext.Session.GetString("UsuarioClienteId"));

            //Capturo a empresa da configuração
            var campanhaId = int.Parse(_configuration["CampanhaId"]);

            var result = _service.GetMines(usuarioClienteId, campanhaId);
            ViewBag.TotalSaldo = _notasFiscaisService.GetSaldo(usuarioClienteId, campanhaId);

            return View("MeusNumeros", result);
        }
    }
}
