using Microsoft.AspNetCore.Mvc;
using Tp_proyecto_final.Bd;

namespace Tp_proyecto_final.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            var producto = _context.Productos.Find(id);

            if (producto == null)
            {
                return RedirectToAction("Index", "Tienda");
            }

            return View(producto);
        }
    }
}
