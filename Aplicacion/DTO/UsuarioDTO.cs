using System.ComponentModel.DataAnnotations;

namespace Aplicacion.DTO
{
    public class UsuarioDTO
    {
        [Required]
        [StringLength(maximumLength: 100)]
        public string Login { get; set; } = null!;

        [Required]
        [StringLength(maximumLength: 100)]
        public string Password { get; set; } = null!;

        [Required]
        public bool EsAdministrador { get; set; }
    }
}
