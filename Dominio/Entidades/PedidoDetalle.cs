using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class PedidoDetalle
    {
        public int Id { get; set; }

        [Required]
        public int AlimentoId { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public int PedidoId { get; set; }

        public Alimento Alimento { get; set; } = null!;

        public Pedido Pedido { get; set; } = null!;
    }
}
