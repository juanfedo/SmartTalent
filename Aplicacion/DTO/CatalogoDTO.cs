namespace Aplicacion.DTO
{
    public class CatalogoDTO
    {
        public string Nombre { get; set; } = null!;
        public List<AlimentoCatalogoDTO> AlimentosCatalogo { get; set; } = new List<AlimentoCatalogoDTO>();
    }
}
