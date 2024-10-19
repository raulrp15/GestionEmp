using Ejercicio01.Models;
using Ejercicio01.Models.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ejercicio01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var format = "HH:MM";
            ViewBag.Fecha = DateTime.Now.ToString(format);
            if (DateTime.Now.Hour > 6 && DateTime.Now.Hour < 12)
            {
                ViewData["Saludo"] = "Buenos días";
            }
            else if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 21) 
            {
                ViewData["Saludo"] = "Buenas tardes";
            }
            else
            {
                ViewData["Saludo"] = "Buenas noches";
            }

            ClsPersona persona = new ClsPersona();
            persona.Nombre = "Raúl";
            persona.Apellidos = "Romera Pavón";
            persona.Edad = 19;
            return View(persona);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ListadoPersonas()
        {
            ClsListado lista = new();
            return View();
        }
    }
}
