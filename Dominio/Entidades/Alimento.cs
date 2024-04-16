using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Alimento
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(maximumLength:100)]
        public string Nombre { get; set; } = null!;

        [StringLength(maximumLength: 200)]
        public string? Descripcion { get; set; }

        [Required]
        [Range(0, 1000000, ErrorMessage = "Precio debe estar entre 1 y 1000000")]
        public int Precio { get; set;}

        public HashSet<PedidoDetalle> PedidosDetalle { get; set; } = new HashSet<PedidoDetalle>();

        public HashSet<AlimentoCatalogo> AlimentosCatalogo { get; set; } = new HashSet<AlimentoCatalogo>();
    }
}
