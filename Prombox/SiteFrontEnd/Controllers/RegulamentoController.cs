 using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteFrontEnd.Controllers
{
    [Route("regulamento")]
    public class RegulamentoController : Controller
    {
        public IActionResult Index()
        {
            return View("Regulamento");
        }
    }
}
