using Aplicacion.DTO;
using Aplicacion.Servicios;
using Infraestructura.Autenticacion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        readonly IJWTHandler _handler;
        readonly IAutenticacionService _autenticacionService;

        public AutenticacionController(IJWTHandler handler, IAutenticacionService autenticacionService)
        {
            _handler = handler;
            _autenticacionService = autenticacionService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] AutenticacionDTO request, CancellationToken cancellationToken)
        {
            var result = await _autenticacionService.ValidarUsuarioAsync(request.Login, request.Password, cancellationToken);

            if (result != null)
            {
                string token = _handler.CreateToken(result.Login, result.EsAdministrador);

                return StatusCode(StatusCodes.Status200OK, new { token });
            }

            return StatusCode(StatusCodes.Status401Unauthorized, new { token = string.Empty });
        }
    }
}
