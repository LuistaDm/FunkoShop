using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Tp_proyecto_final.Bd;
using Tp_proyecto_final.Models;

namespace Tp_proyecto_final.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        private void CargarProductosIniciales()
        {
            if (!_context.Productos.Any())
            {
                var productos = new List<Producto>
        {
            new Producto
            {
                Nombre = "Stormtrooper Lightsaber",
                Categoria = "Star Wars",
                Descripcion = "Figura coleccionable de Stormtrooper con sable de luz.",
                Precio = 1799,
                Imagen = "star-wars/trooper-1.webp",
                Stock = 10
            },
            new Producto
            {
                Nombre = "Baby Yoda",
                Categoria = "Star Wars",
                Descripcion = "Figura coleccionable de Baby Yoda - The Mandalorian.",
                Precio = 1799,
                Imagen = "star-wars/baby-yoda-1.webp",
                Stock = 8
            },
            new Producto
            {
                Nombre = "Pidgeotto",
                Categoria = "Pokémon",
                Descripcion = "Figura coleccionable de Pidgeotto.",
                Precio = 1799,
                Imagen = "pokemon/pidgeotto-1.webp",
                Stock = 12
            },
            new Producto
            {
                Nombre = "Vulpix",
                Categoria = "Pokémon",
                Descripcion = "Figura coleccionable de Vulpix.",
                Precio = 1799,
                Imagen = "pokemon/vulpix-1.webp",
                Stock = 9
            },
            new Producto
            {
                Nombre = "Luna Lovegood Lion Mask",
                Categoria = "Harry Potter",
                Descripcion = "Figura coleccionable de Luna Lovegood con máscara de león.",
                Precio = 1799,
                Imagen = "harry-potter/luna-1.webp",
                Stock = 7
            },
            new Producto
            {
                Nombre = "Snape Patronus",
                Categoria = "Harry Potter",
                Descripcion = "Figura coleccionable de Snape Patronus.",
                Precio = 1799,
                Imagen = "harry-potter/snape-patronus-1.webp",
                Stock = 6
            }
        };
                _context.Productos.AddRange(productos);
                _context.SaveChanges();
            }
        }

        public IActionResult Index()
        {
            CargarProductosIniciales();
            return View();
        }
        public IActionResult Producto()
        {
            return View();
        }
        public IActionResult Tienda()
        {
            var productos = _context.Productos.ToList();

            return View(productos);
        }
        public IActionResult Nosotros()
        {
            return View();
        }
    }
}
