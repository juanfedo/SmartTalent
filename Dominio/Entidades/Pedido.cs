using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        
        [Required]
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; } = null!;

        public HashSet<PedidoDetalle> PedidosDetalle { get; set; } = new HashSet<PedidoDetalle>();
    }
}
