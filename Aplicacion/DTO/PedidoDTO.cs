namespace Aplicacion.DTO
{
    public  class PedidoDTO: PedidoPostDTO
    {
        public int Id { get; set; }

        public List<PedidoDetalleDTO> PedidosDetalle { get; set; } = new List<PedidoDetalleDTO>();
    }
}
