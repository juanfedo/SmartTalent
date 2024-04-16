using Dominio.Entidades;

namespace Infraestructura.Repositorios
{
    public interface IPedidoRepository
    {
        Task AgregarPedidoAsync(int pedidoId, List<PedidoDetalle> alimentoPedidos, CancellationToken cancellationToken);
        Task CrearPedidoAsync(int usuarioId, int catalogoId, CancellationToken cancellationToken);
        Task<List<Pedido>> ObtenerPedidosAsync(CancellationToken cancellationToken);
        Task EnviarConfirmacionPedidoAsync(int pedidoId, CancellationToken cancellationToken);
    }
}