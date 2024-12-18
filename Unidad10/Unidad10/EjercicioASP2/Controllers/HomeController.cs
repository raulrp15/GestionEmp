using Capa_DAL;
using CapaENT;
using EjercicioASP2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EjercicioASP2.Controllers
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

        public IActionResult Detalles()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Conectar()
        {
            List<ClsPersona> list = ClsListadoDAL.GetListadoPersonasDAL();
            return View("Index", list);
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
    }
}
