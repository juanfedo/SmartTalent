using System.ComponentModel.DataAnnotations;

namespace Aplicacion.DTO
{
    public class UsuarioDTO
    {
        public string Login { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public bool EsAdministrador { get; set; }
    }
}
