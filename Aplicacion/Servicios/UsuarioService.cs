using Aplicacion.DTO;
using AutoMapper;
using Dominio.Entidades;
using Infraestructura.Repositorios;

namespace Aplicacion.Servicios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
        {
            _usuarioRepository = repository;
            _mapper = mapper;
        }

        public async Task ActualizarUsuarioAsync(int usuarioId, UsuarioDTO usuario, CancellationToken cancellationToken)
        {
            var UsuarioRecuperado = await _usuarioRepository.ObtenerUsuarioPorIdAsync(usuarioId, cancellationToken);
            if (UsuarioRecuperado != null)
            {
                var usuarioDb = _mapper.Map<Usuario>(usuario);
                usuarioDb.Id = usuarioId;
                await _usuarioRepository.ActualizarUsuarioAsync(usuarioDb, cancellationToken);
            }
        }

        public async Task<bool> BorrarUsuarioAsync(int usuarioId, CancellationToken cancellationToken) =>
            await _usuarioRepository.BorrarUsuarioAsync(usuarioId, cancellationToken);

        public async Task CrearUsuarioAsync(UsuarioDTO usuario, CancellationToken cancellationToken)
        {
            var Usuario = _mapper.Map<Usuario>(usuario);
            await _usuarioRepository.CrearUsuarioAsync(Usuario, cancellationToken);
        }

        public async Task<UsuarioDTO> ObtenerUsuarioPorIdAsync(int usuarioId, CancellationToken cancellationToken)
        {
            var Usuario = await _usuarioRepository.ObtenerUsuarioPorIdAsync(usuarioId, cancellationToken);
            return _mapper.Map<UsuarioDTO>(Usuario);
        }

        public async Task<List<UsuarioDTO>> ObtenerUsuariosAsync(CancellationToken cancellationToken)
        {
            var Usuarios = await _usuarioRepository.ObtenerUsuariosAsync(cancellationToken);
            return _mapper.Map<List<UsuarioDTO>>(Usuarios);
        }
    }
}
