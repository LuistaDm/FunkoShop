using Microsoft.AspNetCore.Mvc;
using Tp_proyecto_final.Bd;
using Tp_proyecto_final.Helpers;
using Tp_proyecto_final.Models;

namespace Tp_proyecto_final.Controllers
{
    public class CarritoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarritoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var carrito = SessionHelper.GetObjectFromJson<List<ItemView>>(HttpContext.Session, "carrito");

            if (carrito == null)
            {
                carrito = new List<ItemView>();
            }
            return View(carrito);
        }

        public IActionResult Agregar(int id)
        {
            var producto = _context.Productos.Find(id);

            if (producto == null)
            {
                return RedirectToAction("Index", "Tienda");
            }

            var carrito = SessionHelper.GetObjectFromJson<List<ItemView>>(HttpContext.Session, "carrito");

            if (carrito == null)
            {
                carrito = new List<ItemView>();
                carrito.Add(new ItemView
                {
                    Producto = producto,
                    Cantidad = 1
                });
            }
            else
            {
                int index = ExisteProducto(carrito, id);
                if (index == -1)
                {
                    carrito.Add(new ItemView
                    {
                        Producto = producto,
                        Cantidad = 1
                    });
                }
                else
                {
                    carrito[index].Cantidad++;
                }
            }

            SessionHelper.SetObjectAsJson(HttpContext.Session, "carrito", carrito);
            TempData["Contar"] = carrito.Sum(i => i.Cantidad);
            return RedirectToAction("Index", "Tienda");
        }

        public IActionResult Quitar(int id)
        {
            var carrito = SessionHelper.GetObjectFromJson<List<ItemView>>(HttpContext.Session,"carrito");

            if (carrito != null)
            {
                int index = ExisteProducto(carrito, id);

                if (index != -1)
                {
                    carrito.RemoveAt(index);
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "carrito", carrito);
                    TempData["Contar"] = carrito.Sum(i => i.Cantidad);
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult FinalizarCompra()
        {
            int? usuarioId = HttpContext.Session.GetInt32("UsuarioId");

            if (usuarioId == null)
            {
                return RedirectToAction("Login", "Usuario");
            }

            var carrito = SessionHelper.GetObjectFromJson<List<ItemView>>(HttpContext.Session,"carrito");

            if (carrito == null || carrito.Count == 0)
            {
                return RedirectToAction("Index");
            }

            Compra compra = new Compra
            {
                Fecha = DateTime.Now,
                UsuarioId = usuarioId.Value,
                Total = carrito.Sum(i => i.Producto.Precio * i.Cantidad)
            };

            _context.Compras.Add(compra);
            _context.SaveChanges();

            foreach (var item in carrito)
            {
                CompraDetalle detalle = new CompraDetalle
                {
                    CompraId = compra.Id,
                    ProductoId = item.Producto.Id,
                    Cantidad = item.Cantidad,
                    PrecioUnitario = item.Producto.Precio,
                    Subtotal = item.Producto.Precio * item.Cantidad
                };

                _context.CompraDetalles.Add(detalle);
            }

            _context.SaveChanges();
            HttpContext.Session.Remove("carrito");
            TempData["Contar"] = 0;

            return RedirectToAction("CompraRealizada");
        }

        public IActionResult CompraRealizada()
        {
            return View();
        }

        private int ExisteProducto(List<ItemView> carrito, int id)
        {
            for (int i = 0; i < carrito.Count; i++)
            {
                if (carrito[i].Producto.Id == id)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
