using Aplicacion.DTO;

namespace Aplicacion.Servicios
{
    public interface ICatalogoService
    {
        Task ActualizarCatalogoAsync(int CatalogoId, CatalogoDTO Catalogo, CancellationToken cancellationToken);
        Task<bool> BorrarCatalogoAsync(int CatalogoId, CancellationToken cancellationToken);
        Task CrearCatalogoAsync(CatalogoPostDTO CatalogoDTO, CancellationToken cancellationToken);
        Task<CatalogoDTO> ObtenerAlimentosPorCatalogoIdAsync(int catalogoId, CancellationToken cancellationToken);
        Task<CatalogoDTO> ObtenerCatalogoPorIdAsync(int CatalogoId, CancellationToken cancellationToken);
        Task<List<CatalogoDTO>> ObtenerCatalogosAsync(CancellationToken cancellationToken);
        Task AgregarAlimentosCatalogoAsync(int catalogoId, List<AlimentoCatalogoDTO> alimentoCatalogosDTO, CancellationToken cancellationToken);
        Task<bool> BorrarAlimentoCatalogoAsync(int catalogoId, int alimentoId, CancellationToken cancellationToken);
    }
}