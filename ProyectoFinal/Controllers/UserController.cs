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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Nombre, string Contrasena)
        {
            // Validar las credenciales
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Nombre == Nombre && u.Contrasena == Contrasena);

            if (usuario != null)
            {
                // Guardar información en TempData o Session si es necesario
                TempData["Usuario"] = usuario.Nombre; // Almacenar el usuario en TempData
                return RedirectToAction("Lugares", "Lugares"); // Redirigir a la vista Lugares
            }

            ViewBag.Error = "Credenciales incorrectas.";
            return View();
        }
    }
}
