using Aplicacion.DTO;
using AutoMapper;
using Dominio.Entidades;
using Infraestructura.Repositorios;

namespace Aplicacion.Servicios
{
    public class CatalogoService : ICatalogoService
    {
        private readonly ICatalogoRepository _catalogoRepository;
        private readonly IMapper _mapper;

        public CatalogoService(ICatalogoRepository repository, IMapper mapper)
        {
            _catalogoRepository = repository;
            _mapper = mapper;
        }

        public async Task<CatalogoDTO> ObtenerAlimentosPorCatalogoIdAsync(int catalogoId, CancellationToken cancellationToken)
        {
            var catalogo = await _catalogoRepository.ObtenerCatalogoPorIdAsync(catalogoId, cancellationToken);
            var alimentosCatalogo = await _catalogoRepository.ObtenerAlimentosPorCatalogoIdAsync(catalogoId, cancellationToken);

            return new CatalogoDTO()
            {
                Nombre = catalogo.Nombre,
                AlimentosCatalogo = _mapper.Map<List<AlimentoCatalogoDTO>>(alimentosCatalogo)
            };
        }

        public async Task AgregarAlimentosCatalogoAsync(int catalogoId, List<AlimentoCatalogoDTO> alimentoCatalogosDTO, CancellationToken cancellationToken)
        {
            List<AlimentoCatalogo> alimentosCatalogo = new List<AlimentoCatalogo>();
            foreach (AlimentoCatalogoDTO elemento in alimentoCatalogosDTO)
            {
                alimentosCatalogo.Add(new AlimentoCatalogo()
                {
                    AlimentoId = elemento.AlimentoId,
                    CatalogoId = catalogoId,
                    CantidadDisponible = elemento.CantidadDisponible
                });
            }
            await _catalogoRepository.AgregarAlimentosCatalogoAsync(catalogoId, alimentosCatalogo, cancellationToken);
        }

        public async Task<List<CatalogoDTO>> ObtenerCatalogosAsync(CancellationToken cancellationToken)
        {
            var Catalogos = await _catalogoRepository.ObtenerCatalogosAsync(cancellationToken);
            return _mapper.Map<List<CatalogoDTO>>(Catalogos);
        }

        public async Task<CatalogoDTO> ObtenerCatalogoPorIdAsync(int CatalogoId, CancellationToken cancellationToken)
        {
            var Catalogo = await _catalogoRepository.ObtenerCatalogoPorIdAsync(CatalogoId, cancellationToken);
            return _mapper.Map<CatalogoDTO>(Catalogo);
        }

        public async Task CrearCatalogoAsync(CatalogoPostDTO CatalogoDTO, CancellationToken cancellationToken)
        {
            var Catalogo = _mapper.Map<Catalogo>(CatalogoDTO);
            await _catalogoRepository.CrearCatalogoAsync(Catalogo, cancellationToken);
        }

        public async Task<bool> BorrarAlimentoCatalogoAsync(int catalogoId, int alimentoId, CancellationToken cancellationToken) =>
            await _catalogoRepository.BorrarAlimentoCatalogoAsync(catalogoId, alimentoId, cancellationToken);
    }
}
