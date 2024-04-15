using System.ComponentModel.DataAnnotations;

namespace Aplicacion.DTO
{
    public class AlimentoDTO
    {
        public string Nombre { get; set; } = null!;

        [StringLength(maximumLength: 200)]
        public string? Descripcion { get; set; }

        [Required]
        [Range(0, 1000000, ErrorMessage = "Precio debe estar entre 1 y 1000000")]
        public int Precio { get; set; }
    }
}
