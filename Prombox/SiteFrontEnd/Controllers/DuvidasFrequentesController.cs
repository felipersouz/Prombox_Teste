using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Prombox.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteFrontEnd.Controllers
{
    [Route("duvidas-frequentes")]
    public class DuvidasFrequentesController : Controller
    {
        private readonly IDuvidasFrequentesService _service;
        private readonly IConfiguration _configuration;

        public DuvidasFrequentesController(
        IDuvidasFrequentesService service,
        IConfiguration configuration)
        {
            _service = service;
            _configuration = configuration;
        }


        public IActionResult Index()
        {
            //Capturo a empresa da configuração
            var campanhaId = int.Parse(_configuration["CampanhaId"]);

            var items = _service.GetByCampanha(campanhaId);

            ViewBag.items = items;

            return View("DuvidasFrequentes");
        }
    }
}