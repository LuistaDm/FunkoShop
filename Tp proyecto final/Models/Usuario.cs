using System.ComponentModel.DataAnnotations;

namespace Tp_proyecto_final.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "Ingrese un nombre. ")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese un apellido. ")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Ingrese un email. ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ingrese una contraseña. ")]
        public string Password { get; set; }
        public List<Compra> Compras { get; set; } = new List<Compra>();
    }
}
