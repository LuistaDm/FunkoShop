using Microsoft.AspNetCore.Mvc;
using Tp_proyecto_final.Bd;

namespace Tp_proyecto_final.Controllers
{
    public class TiendaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TiendaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string buscar)
        {
            var productos = from Producto in _context.Productos
                            select Producto;

            if (!string.IsNullOrEmpty(buscar))
            {
                productos = productos.Where(p =>
                    p.Nombre.Contains(buscar) ||
                    p.Categoria.Contains(buscar));
            }

            ViewBag.Buscar = buscar;

            return View(productos.ToList());
        }
    }
}
