using System.ComponentModel.DataAnnotations;

namespace Tp_proyecto_final.Models
{
    public class Producto
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
            
        [Required]
        public string Categoria { get; set; }
        public string Descripcion {  get; set; }
        public decimal Precio { get; set; }
        public string Imagen {  get; set; }
        public int Stock { get; set; }
    }
}
