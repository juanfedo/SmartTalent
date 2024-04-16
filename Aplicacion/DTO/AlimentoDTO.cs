using System.ComponentModel.DataAnnotations;

namespace Aplicacion.DTO
{
    public class AlimentoDTO
    {
        public string Nombre { get; set; } = null!;

        public string? Descripcion { get; set; }

        public int Precio { get; set; }
    }
}
