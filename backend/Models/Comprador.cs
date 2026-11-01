using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Comprador
    {
        [Key]
        public int IdComprador { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Empresa { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;
    }
}