using Aplicacion.DTO;
using Dominio.Entidades;

namespace Aplicacion.Servicios
{
    public interface IPedidoService
    {
        Task AgregarPedidoAsync(int pedidoId, List<PedidoDetalleDTO> alimentoPedidos, CancellationToken cancellationToken);
        Task CrearPedidoAsync(int usuarioId, int catalogoId, CancellationToken cancellationToken);
        Task<List<PedidoDTO>> ObtenerPedidosAsync(CancellationToken cancellationToken);
        Task EnviarConfirmacionPedidoAsync(int pedidoId, CancellationToken cancellationToken);
    }
}