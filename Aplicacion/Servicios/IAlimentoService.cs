using Aplicacion.DTO;
using Dominio.Entidades;

namespace Aplicacion.Servicios
{
    public interface IAlimentoService
    {
        Task ActualizarAlimentoAsync(int alimentoId, AlimentoDTO alimento, CancellationToken cancellationToken);
        Task<bool> BorrarAlimentoAsync(int alimentoId, CancellationToken cancellationToken);
        Task CrearAlimentoAsync(AlimentoDTO alimento, CancellationToken cancellationToken);
        Task<AlimentoGetDTO> ObtenerAlimentoPorIdAsync(int alimentoId, CancellationToken cancellationToken);
        Task<List<AlimentoGetDTO>> ObtenerAlimentosAsync(CancellationToken cancellationToken);
    }
}