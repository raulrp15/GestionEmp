using Microsoft.AspNetCore.Mvc;

namespace Ejercicio02.Controllers
{
    public class ListadoController : Controller
    {
        public IActionResult ListadoProductos()
        {
            return View();
        }
    }
}
