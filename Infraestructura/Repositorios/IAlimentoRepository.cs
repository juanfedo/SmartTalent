using Dominio.Entidades;

namespace Infraestructura.Repositorios
{
    public interface IAlimentoRepository
    {
        Task ActualizarAlimentoAsync(Alimento alimento, CancellationToken cancellationToken);
        Task<bool> BorrarAlimentoAsync(int alimentoId, CancellationToken cancellationToken);
        Task CrearAlimentoAsync(Alimento alimento, CancellationToken cancellationToken);
        Task<Alimento> ObtenerAlimentoPorIdAsync(int alimentoId, CancellationToken cancellationToken);
        Task<List<Alimento>> ObtenerAlimentosAsync(CancellationToken cancellationToken);
    }
}