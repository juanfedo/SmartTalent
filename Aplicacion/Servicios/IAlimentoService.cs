using Aplicacion.DTO;
using Dominio.Entidades;

namespace Aplicacion.Servicios
{
    public interface IAlimentoService
    {
        Task ActualizarAlimentoAsync(AlimentoDTO alimento, CancellationToken cancellationToken);
        Task<bool> BorrarAlimentoAsync(int alimentoId, CancellationToken cancellationToken);
        Task CrearAlimentoAsync(AlimentoDTO alimento, CancellationToken cancellationToken);
        Task<AlimentoDTO> ObtenerAlimentoPorIdAsync(int alimentoId, CancellationToken cancellationToken);
        Task<List<AlimentoDTO>> ObtenerAlimentosAsync(CancellationToken cancellationToken);
    }
}