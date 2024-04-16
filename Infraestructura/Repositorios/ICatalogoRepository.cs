using Dominio.Entidades;

namespace Infraestructura.Repositorios
{
    public interface ICatalogoRepository
    {
        Task CrearCatalogoAsync(Catalogo Catalogo, CancellationToken cancellationToken);
        Task<Catalogo> ObtenerCatalogoPorIdAsync(int CatalogoId, CancellationToken cancellationToken);
        Task<List<Catalogo>> ObtenerCatalogosAsync(CancellationToken cancellationToken);
        Task<List<AlimentoCatalogo>> ObtenerAlimentosPorCatalogoIdAsync(int CatalogoId, CancellationToken cancellationToken);
        Task AgregarAlimentosCatalogoAsync(int catalogoId, List<AlimentoCatalogo> alimentoCatalogos, CancellationToken cancellationToken);
        Task<bool> BorrarAlimentoCatalogoAsync(int catalogoId, int alimentoId, CancellationToken cancellationToken);
    }
}