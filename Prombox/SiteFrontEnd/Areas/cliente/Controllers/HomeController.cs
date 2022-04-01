using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteFrontEnd.Areas.Cliente.Controllers
{
    [Area("cliente")]
    public class HomeController : Controller
    { 
        public IActionResult Index()
        {
            // Pego o usuário logado
            bool isAutenticado = HttpContext.Session.GetInt32("IsAutenticado") == 1;
            if (!isAutenticado)
                return RedirectToAction("Index", "Login");

            return View("Home");
            
        }
    }
}
