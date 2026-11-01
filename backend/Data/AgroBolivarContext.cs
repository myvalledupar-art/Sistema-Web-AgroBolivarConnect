using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class AgroBolivarContext : DbContext
    {
        public AgroBolivarContext(DbContextOptions<AgroBolivarContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Agricultor> Agricultores { get; set; }

        public DbSet<Comprador> Compradores { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<DetallePedido> DetallePedidos { get; set; }
    }
}


