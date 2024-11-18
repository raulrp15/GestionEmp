using CapaDAL.Conexion;
using EjercicioAzure.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EjercicioAzure.Controllers
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

        [HttpPost]
        public IActionResult Conexion()
        {
            ClsConexion conexion = new ClsConexion();

            try
            {
                conexion.ConectarBD();
                ViewBag.EstadoConexion = "Conectado";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                ViewBag.EstadoConexion = "Error";
            }
            finally
            {
                conexion.DesconectarBD();
            }
            

            return View("Index");
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
