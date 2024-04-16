using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class AlimentoCatalogo
    {
        public int Id { get; set; }

        public int AlimentoId { get; set; }

        public Alimento Alimento { get; set; } = null!;

        public int CatalogoId { get; set; }

        public Catalogo Catalogo { get; set; } = null!;

        [Required]
        public int CantidadDisponible { get; set; }

    }
}
