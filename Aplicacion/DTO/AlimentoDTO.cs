using System.ComponentModel.DataAnnotations;

namespace Aplicacion.DTO
{
    public class AlimentoDTO
    {
        public string Nombre { get; set; } = null!;

        [StringLength(maximumLength: 200)]
        public string? Descripcion { get; set; }

        [Required]
        public int Precio { get; set; }
    }
}
