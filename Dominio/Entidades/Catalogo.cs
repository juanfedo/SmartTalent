using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Catalogo
    {
        public int Id { get; set; }

        [Required]
        public int AlimentoId { get; set; }

        [Required]
        public int CantidadDisponible { get; set; }

        public Alimento Alimento { get; set; } = null!;
    }
}
