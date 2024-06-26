﻿using Aplicacion.DTO;
using Aplicacion.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace Presentacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        readonly IAutenticacionService _autenticacionService;

        public AutenticacionController(IAutenticacionService autenticacionService)
        {
            _autenticacionService = autenticacionService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] AutenticacionDTO request, CancellationToken cancellationToken)
        {
            try
            {
                var token = await _autenticacionService.ValidarUsuarioAsync(request.Login, request.Password, cancellationToken);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al procesar la solicitud: {ex.Message}");
            }
        }
    }
}
