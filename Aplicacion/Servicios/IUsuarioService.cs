using Aplicacion.DTO;

namespace Aplicacion.Servicios
{
    public interface IUsuarioService
    {
        Task ActualizarUsuarioAsync(int usuarioId, UsuarioDTO usuario, CancellationToken cancellationToken);
        Task<bool> BorrarUsuarioAsync(int usuarioId, CancellationToken cancellationToken);
        Task CrearUsuarioAsync(UsuarioDTO usuario, CancellationToken cancellationToken);
        Task<UsuarioGetDTO> ObtenerUsuarioPorIdAsync(int usuarioId, CancellationToken cancellationToken);
        Task<List<UsuarioGetDTO>> ObtenerUsuariosAsync(CancellationToken cancellationToken);
    }
}
