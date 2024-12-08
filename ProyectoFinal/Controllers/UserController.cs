using ProyectoFinal.Models;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Data;


namespace ProyectoFinal.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterUser(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

                TempData["Mensaje"] = "Usuario registrado exitosamente.";
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Todos los campos son obligatorios.";
            return View(usuario);
        }
    }
}
