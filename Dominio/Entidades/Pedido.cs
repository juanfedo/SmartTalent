using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        
        [Required]
        public int UsuarioId { get; set; }

        [Required]
        public int CatalogoId { get; set; }

        public Catalogo Catalogo { get; set; } = null!;

        public Usuario Usuario { get; set; } = null!;

        public List<PedidoDetalle> PedidosDetalle { get; set; } = new List<PedidoDetalle>();
    }
}
