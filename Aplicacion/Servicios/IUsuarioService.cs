using Aplicacion.DTO;

namespace Aplicacion.Servicios
{
    public interface IUsuarioService
    {
        Task ActualizarUsuarioAsync(int usuarioId, UsuarioDTO usuario, CancellationToken cancellationToken);
        Task<bool> BorrarUsuarioAsync(int usuarioId, CancellationToken cancellationToken);
        Task CrearUsuarioAsync(UsuarioDTO usuario, CancellationToken cancellationToken);
        Task<UsuarioDTO> ObtenerUsuarioPorIdAsync(int usuarioId, CancellationToken cancellationToken);
        Task<List<UsuarioDTO>> ObtenerUsuariosAsync(CancellationToken cancellationToken);
    }
}
