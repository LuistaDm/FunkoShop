namespace Tp_proyecto_final.Models
{
    public class Compra
    {
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public List<CompraDetalle> Detalles { get; set; } = new List<CompraDetalle>();
    }
}
