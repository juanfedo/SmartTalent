using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Catalogo
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; } = null!;

        public List<AlimentoCatalogo> AlimentosCatalogo { get; set; } = new List<AlimentoCatalogo>();
    }
}
