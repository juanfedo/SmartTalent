using Aplicacion.DTO;
using AutoMapper;
using Dominio.Entidades;
using Infraestructura.Contexto;
using Infraestructura.Repositorios;

namespace Aplicacion.Servicios
{
    public class AlimentoService : IAlimentoService
    {
        private readonly IAlimentoRepository _alimentoRepository;
        private readonly IMapper _mapper;

        public AlimentoService(IAlimentoRepository repository, IMapper mapper)
        {
            _alimentoRepository = repository;
            _mapper = mapper;
        }

        public async Task<List<AlimentoDTO>> ObtenerAlimentosAsync(CancellationToken cancellationToken)
        { 
            var alimentos = await _alimentoRepository.ObtenerAlimentosAsync(cancellationToken);
            return _mapper.Map<List<AlimentoDTO>>(alimentos);
        }

        public async Task<AlimentoDTO> ObtenerAlimentoPorIdAsync(int alimentoId, CancellationToken cancellationToken)
        {
            var alimento = await _alimentoRepository.ObtenerAlimentoPorIdAsync(alimentoId, cancellationToken);
            return _mapper.Map<AlimentoDTO>(alimento);
        }

        public async Task CrearAlimentoAsync(AlimentoDTO alimentoDTO, CancellationToken cancellationToken)
        {
            var alimento = _mapper.Map<Alimento>(alimentoDTO);
            await _alimentoRepository.CrearAlimentoAsync(alimento, cancellationToken);
        }

        public async Task ActualizarAlimentoAsync(AlimentoDTO alimento, CancellationToken cancellationToken)
        {
            var alimentoRecuperado = await _alimentoRepository.ObtenerAlimentoPorIdAsync(alimento.Id, cancellationToken);
            if (alimentoRecuperado != null)
            {
                var alimentoDTO = _mapper.Map<Alimento>(alimento);
                await _alimentoRepository.ActualizarAlimentoAsync(alimentoDTO, cancellationToken);
            }
        }

        public async Task<bool> BorrarAlimentoAsync(int alimentoId, CancellationToken cancellationToken) =>
            await _alimentoRepository.BorrarAlimentoAsync(alimentoId, cancellationToken);
    }
}
