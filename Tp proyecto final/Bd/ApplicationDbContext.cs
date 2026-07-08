using Microsoft.EntityFrameworkCore;
using Tp_proyecto_final.Models;

namespace Tp_proyecto_final.Bd
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; } 
        public DbSet<Usuario> Usuarios { get; set; } 
        public DbSet<Compra> Compras { get; set; } 
        public DbSet<CompraDetalle> CompraDetalles { get; set; } 

    }
}
