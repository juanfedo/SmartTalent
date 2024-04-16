using Aplicacion.DTO;
using Aplicacion.Servicios;
using Infraestructura.Autenticacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlimentoController : ControllerBase
    {
        readonly IAlimentoService _alimentoService;

        public AlimentoController(IAlimentoService alimentoService)
        {
            _alimentoService = alimentoService;
        }

        //[Authorize(Policy = IdentityData.AdminUserPolicyName)]
        [HttpGet]
        public async Task<ActionResult<List<AlimentoGetDTO>>> Get(CancellationToken cancellationToken)
        {
            return Ok(await _alimentoService.ObtenerAlimentosAsync(cancellationToken));
        }

        [HttpGet("PorId")]
        public async Task<ActionResult> Get(int alimentoId, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _alimentoService.ObtenerAlimentoPorIdAsync(alimentoId, cancellationToken));
            }
            catch  (Exception ex) 
            {
                return BadRequest($"Error al procesar la solicitud: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post(AlimentoDTO alimentoDTO, CancellationToken cancellationToken)
        {
            try
            {
                await _alimentoService.CrearAlimentoAsync(alimentoDTO, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al procesar la solicitud: {ex.Message}");
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(int alimentoId, AlimentoDTO alimentoDTO, CancellationToken cancellationToken)
        {
            try
            {
                await _alimentoService.ActualizarAlimentoAsync(alimentoId, alimentoDTO, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al procesar la solicitud: {ex.Message}");
            }
        }

        //[Authorize]
        //[RequireClaim(IdentityData.AdminUserClaimName, "True")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int alimentoId, CancellationToken cancellationToken)
        {
            try
            {
                if (await _alimentoService.BorrarAlimentoAsync(alimentoId, cancellationToken))
                {
                    return Ok();
                }
                else
                {
                    return BadRequest("No se elimino ningún registro");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al procesar la solicitud: {ex.Message}");
            }
        }
    }
}
