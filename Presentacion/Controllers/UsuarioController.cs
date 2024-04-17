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
    public class UsuarioController : ControllerBase
    {
        readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioGetDTO>>> Get(CancellationToken cancellationToken)
        {
            return await _usuarioService.ObtenerUsuariosAsync(cancellationToken);
        }

        [HttpGet("PorId")]
        public async Task<ActionResult> Get(int UsuarioId, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _usuarioService.ObtenerUsuarioPorIdAsync(UsuarioId, cancellationToken));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al procesar la solicitud: {ex.Message}");
            }
        }

        [Authorize(Policy = IdentityData.AdminUserPolicyName)]
        [HttpPost]
        public async Task<ActionResult> Post(UsuarioDTO UsuarioDTO, CancellationToken cancellationToken)
        {
            try
            {
                await _usuarioService.CrearUsuarioAsync(UsuarioDTO, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al procesar la solicitud: {ex.Message}");
            }
        }

        [Authorize(Policy = IdentityData.AdminUserPolicyName)]
        [HttpPut]
        public async Task<ActionResult> Put(int usuarioId, UsuarioDTO UsuarioDTO, CancellationToken cancellationToken)
        {
            try
            {
                await _usuarioService.ActualizarUsuarioAsync(usuarioId, UsuarioDTO, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al procesar la solicitud: {ex.Message}");
            }
        }

        [Authorize(Policy = IdentityData.AdminUserPolicyName)]
        [HttpDelete]
        public async Task<ActionResult> Delete(int UsuarioId, CancellationToken cancellationToken)
        {
            try
            {
                if (await _usuarioService.BorrarUsuarioAsync(UsuarioId, cancellationToken))
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
