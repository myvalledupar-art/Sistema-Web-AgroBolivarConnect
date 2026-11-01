using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Categoria { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public int IdAgricultor { get; set; }
    }
}