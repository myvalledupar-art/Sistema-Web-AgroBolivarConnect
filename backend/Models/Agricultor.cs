using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Agricultor
    {
        [Key]
        public int IdAgricultor { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Cedula { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        public string Municipio { get; set; } = string.Empty;

        public string Finca { get; set; } = string.Empty;
    }
}

