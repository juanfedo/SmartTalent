using Aplicacion.DTO;
using AutoMapper;
using Infraestructura.Repositorios;

namespace Aplicacion.Servicios
{
    public class AutenticacionService : IAutenticacionService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public AutenticacionService(IUsuarioRepository repository, IMapper mapper)
        {
            _usuarioRepository = repository;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> ValidarUsuarioAsync(string login, string password, CancellationToken cancellationToken)
        {
            var Autenticacion = await _usuarioRepository.ValidarUsuarioAsync(login, password, cancellationToken);
            return _mapper.Map<UsuarioDTO>(Autenticacion);
        }

    }
}
