using Microsoft.EntityFrameworkCore;
using Dominio.Entidades;

namespace Infraestructura.Contexto
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Alimento> Alimentos => Set<Alimento>();
        public DbSet<Catalogo> Catalogos => Set<Catalogo>();
        public DbSet<Pedido> Pedidos => Set<Pedido>();
        public DbSet<PedidoDetalle> PedidosDetalle => Set<PedidoDetalle>();

    }
}
