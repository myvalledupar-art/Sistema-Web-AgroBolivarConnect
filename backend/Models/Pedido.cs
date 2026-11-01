using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Pedido
    {
        [Key]
        public int IdPedido { get; set; }

        public DateTime Fecha { get; set; }

        public decimal Total { get; set; }

        public string Estado { get; set; } = string.Empty;

        public int IdComprador { get; set; }
    }
}