using Microsoft.AspNetCore.Mvc;

namespace ProyectoFinal.Controllers
{
    public class LugaresController : Controller
    {
        public IActionResult Lugares()
        {
            return View(); // Esto cargará la vista "Lugares" desde "Views/Lugares"
        }
    }
}
