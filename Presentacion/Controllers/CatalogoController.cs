using Aplicacion.DTO;
using Aplicacion.Servicios;
using Infraestructura.Autenticacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentacion.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        readonly ICatalogoService _catalogoService;

        public CatalogoController(ICatalogoService catalogoService)
        {
            _catalogoService = catalogoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AlimentoGetDTO>>> Get(CancellationToken cancellationToken)
        {
            return Ok(await _catalogoService.ObtenerCatalogosAsync(cancellationToken));
        }

        [HttpGet("PorId")]
        public async Task<ActionResult<CatalogoDTO>> Get(int catalogoId, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _catalogoService.ObtenerAlimentosPorCatalogoIdAsync(catalogoId, cancellationToken));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al procesar la solicitud: {ex.Message}");
            }
        }

        [Authorize(Policy = IdentityData.AdminUserPolicyName)]
        [HttpPost]
        public async Task<ActionResult> Post(CatalogoPostDTO catalogoDTO, CancellationToken cancellationToken)
        {
            try
            {
                await _catalogoService.CrearCatalogoAsync(catalogoDTO, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al procesar la solicitud: {ex.Message}");
            }
        }

        [Authorize(Policy = IdentityData.AdminUserPolicyName)]
        [HttpPost("AgregarAlimentos")]
        public async Task<ActionResult> Post(int catalogoId, List<AlimentoCatalogoDTO> alimentoCatalogosDTO, CancellationToken cancellationToken)
        {
            try
            {
                await _catalogoService.AgregarAlimentosCatalogoAsync(catalogoId, alimentoCatalogosDTO, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al procesar la solicitud: {ex.Message}");
            }
        }

        [Authorize(Policy = IdentityData.AdminUserPolicyName)]
        [HttpDelete("BorrarAlimento")]
        public async Task<ActionResult> Delete(int catalogoId, int alimentoId, CancellationToken cancellationToken)
        {
            try
            {
                if (await _catalogoService.BorrarAlimentoCatalogoAsync(catalogoId, alimentoId, cancellationToken))
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
