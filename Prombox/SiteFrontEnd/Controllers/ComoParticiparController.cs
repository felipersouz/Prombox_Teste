using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteFrontEnd.Controllers
{
    [Route("como-participar")]
    public class ComoParticiparController : Controller
    {
        public IActionResult Index()
        {
            return View("ComoParticipar");
        }
    }
}
