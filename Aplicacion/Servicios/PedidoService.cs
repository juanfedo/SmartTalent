using Aplicacion.DTO;
using AutoMapper;
using Dominio.Entidades;
using Infraestructura.Repositorios;

namespace Aplicacion.Servicios
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public PedidoService(IPedidoRepository repository, IMapper mapper)
        {
            _pedidoRepository = repository;
            _mapper = mapper;
        }

        public async Task EnviarConfirmacionPedidoAsync(int pedidoId, CancellationToken cancellationToken) =>
            await _pedidoRepository.EnviarConfirmacionPedidoAsync(pedidoId, cancellationToken);

        public async Task<List<PedidoDTO>> ObtenerPedidosAsync(CancellationToken cancellationToken)
        {
            var Pedidos = await _pedidoRepository.ObtenerPedidosAsync(cancellationToken);
            return _mapper.Map<List<PedidoDTO>>(Pedidos);
        }

        public async Task CrearPedidoAsync(int usuarioId, int catalogoId, CancellationToken cancellationToken) =>
            await _pedidoRepository.CrearPedidoAsync(usuarioId, catalogoId, cancellationToken);

        public async Task AgregarPedidoAsync(int pedidoId, List<PedidoDetalleDTO> alimentoPedidos, CancellationToken cancellationToken)
        {
            List<PedidoDetalle> pedidoDetalles = new List<PedidoDetalle>();
            foreach (PedidoDetalleDTO elemento in alimentoPedidos)
            {
                pedidoDetalles.Add(new PedidoDetalle()
                {
                    AlimentoId = elemento.AlimentoId,
                    Cantidad = elemento.Cantidad,
                    PedidoId = pedidoId,
                });
            }

            await _pedidoRepository.AgregarPedidoAsync(pedidoId, pedidoDetalles, cancellationToken);
        }
    }
}
