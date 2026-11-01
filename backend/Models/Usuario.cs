using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Correo { get; set; } = string.Empty;

        public string Contrasena { get; set; } = string.Empty;

        public string Rol { get; set; } = string.Empty;
    }
}