using Microsoft.AspNetCore.Mvc;
using Tp_proyecto_final.Bd;
using Tp_proyecto_final.Models;

namespace Tp_proyecto_final.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

                HttpContext.Session.SetInt32("UsuarioId", usuario.Id);
                HttpContext.Session.SetString("UsuarioNombre", usuario.Nombre);

                return RedirectToAction("Index", "Tienda");
            }

            return View(usuario);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Password == password);

            if (usuario != null)
            {
                HttpContext.Session.SetInt32("UsuarioId", usuario.Id);
                HttpContext.Session.SetString("UsuarioNombre", usuario.Nombre);
                return RedirectToAction("Index", "Tienda");
            }

            ViewBag.Error = "Email o contraseña incorrectos";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UsuarioId");
            HttpContext.Session.Remove("UsuarioNombre");

            return RedirectToAction("Index", "Home");
        }
    }
}
