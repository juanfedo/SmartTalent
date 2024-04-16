using Aplicacion.DTO;
using Aplicacion.Servicios;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidoDTO>>> Get(CancellationToken cancellationToken)
        {
            return Ok(await _pedidoService.ObtenerPedidosAsync(cancellationToken));
        }

        [HttpPost]
        public async Task<ActionResult> Post(int usuarioId, int catalogoId, CancellationToken cancellationToken)
        {
            try
            {
                await _pedidoService.CrearPedidoAsync(usuarioId, catalogoId, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al procesar la solicitud: {ex.Message}");
            }
        }

        [HttpPost("AgregarAlimentos")]
        public async Task<ActionResult> Post(int pedidoId, List<PedidoDetalleDTO> pedidoDetalleDTO, CancellationToken cancellationToken)
        {
            try
            {
                await _pedidoService.AgregarPedidoAsync(pedidoId, pedidoDetalleDTO, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al procesar la solicitud: {ex.Message}");
            }
        }

        [HttpPost("EnviarConfirmacion")]
        public async Task<ActionResult> EnviarConfirmacionPedido(int pedidoId, CancellationToken cancellationToken)
        {
            try
            {
                await _pedidoService.EnviarConfirmacionPedidoAsync(pedidoId, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al procesar la solicitud: {ex.Message}");
            }
        }

    }
}
