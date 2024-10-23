using Ejercicio04.Models;
using Ejercicio04.Models.DAL;
using Ejercicio04.Models.ENT;
using Ejercicio04.Models.VM;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace Ejercicio04.Controllers
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
            return View();
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

        public IActionResult EditarPersona()
        {
            Random random = new Random();
            ClsPersona persona = new ClsPersona();
            persona = ClsListado.GetPersonas()[random.Next(ClsListado.GetPersonas().Count)];
            ClsEditarPersonaVM lista = new ClsEditarPersonaVM();
            lista.Nombre = persona.Nombre;
            lista.Apellidos = persona.Apellidos;
            lista.Edad = persona.Edad;
            lista.IdDepartamento = persona.IdDepartamento;

            return View(lista);
        }
    }
}
