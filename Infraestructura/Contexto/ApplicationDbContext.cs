using Microsoft.EntityFrameworkCore;
using Dominio.Entidades;
using Infraestructura.Parametrizacion;

namespace Infraestructura.Contexto
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);
            DatosIniciales.Seed(modelBuilder);
        }

        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Alimento> Alimentos => Set<Alimento>();
        public DbSet<Catalogo> Catalogos => Set<Catalogo>();
        public DbSet<Pedido> Pedidos => Set<Pedido>();
        public DbSet<PedidoDetalle> PedidosDetalle => Set<PedidoDetalle>();
        public DbSet<AlimentoCatalogo> AlimentoCatalogos => Set<AlimentoCatalogo>();

    }
}
