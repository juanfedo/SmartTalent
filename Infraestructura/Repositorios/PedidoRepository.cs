using Dominio.Entidades;
using Infraestructura.Contexto;
using Infraestructura.Correo;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorios
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IServicioCorreo _correo;

        public PedidoRepository(ApplicationDbContext context, IServicioCorreo correo)
        {
            _context = context;
            _correo = correo;
        }

        public async Task EnviarConfirmacionPedidoAsync(int pedidoId, CancellationToken cancellationToken)
        {
            var pedido = await _context.Pedidos.FirstOrDefaultAsync(p => p.Id == pedidoId, cancellationToken);
            if (pedido == null )
            {
                throw new Exception($"El pedido {pedidoId} no se encuentra en la base de datos");
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == pedido.UsuarioId, cancellationToken);
            if (usuario == null)
            {
                throw new Exception("Usuario no encontrado en la base de datos");
            }

            _correo.EnviarCorreo(usuario.Correo, pedidoId);
        }

        public async Task<List<Pedido>> ObtenerPedidosAsync(CancellationToken cancellationToken)
        {
            var resultado = await _context.Pedidos.Include(p => p.PedidosDetalle).ToListAsync(cancellationToken: cancellationToken);
            return resultado;
        }

        public async Task CrearPedidoAsync(int usuarioId, int catalogoId, CancellationToken cancellationToken)
        {
            _context.Add(new Pedido()
            {
                UsuarioId = usuarioId,
                CatalogoId = catalogoId,
            });
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task AgregarPedidoAsync(int pedidoId, List<PedidoDetalle> alimentoPedidos, CancellationToken cancellationToken)
        {
            var pedido = await _context.Pedidos.FirstOrDefaultAsync(x => x.Id == pedidoId, cancellationToken: cancellationToken);

            if (pedido == null)
            {
                throw new Exception($"No existe el Pedido para el id {pedidoId}");
            }

            foreach (PedidoDetalle elemento in alimentoPedidos)
            {
                var alimentoCatalogo = await _context.AlimentoCatalogos.FirstOrDefaultAsync(x => x.CatalogoId == pedido.CatalogoId && x.AlimentoId == elemento.AlimentoId);

                if (alimentoCatalogo == null)
                {
                    throw new Exception($"No existe el alimento {elemento.AlimentoId}");
                }

                if (alimentoCatalogo.CantidadDisponible > 0 && (alimentoCatalogo.CantidadDisponible - elemento.Cantidad) >= 0)
                {
                    pedido.PedidosDetalle.Add(elemento);
                    alimentoCatalogo.CantidadDisponible -= elemento.Cantidad;
                }
                else
                {
                    throw new Exception($"No hay cantidad suficiente del alimento {elemento.AlimentoId} en el pedido {elemento.PedidoId}");
                }
            }

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
