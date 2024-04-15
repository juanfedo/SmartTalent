using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Usuario
    {
        public int Id {  get; set; }

        [Required]
        [StringLength(maximumLength: 100)]
        public string Login { get; set; } = null!;

        [Required]
        [StringLength(maximumLength: 100)]
        public string Password { get; set; } = null!;

        [Required]
        public bool EsAdministrador { get; set; }

        public HashSet<Pedido> Pedidos { get; set; } = new HashSet<Pedido>();
    }
}
