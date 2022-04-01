using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SiteFrontEnd.Controllers
{
    [Route("ganhadores")]
    public class GanhadoresController : Controller
    {
        public IActionResult Index()
        {
            return View("Ganhadores");
        }
    }
}
