using Dominio.Entidades;

namespace Infraestructura.Repositorios
{
    public interface IUsuarioRepository
    {
        Task ActualizarUsuarioAsync(Usuario usuario, CancellationToken cancellationToken);
        Task<bool> BorrarUsuarioAsync(int usuarioId, CancellationToken cancellationToken);
        Task CrearUsuarioAsync(Usuario usuario, CancellationToken cancellationToken);
        Task<Usuario> ObtenerUsuarioPorIdAsync(int usuarioId, CancellationToken cancellationToken);
        Task<List<Usuario>> ObtenerUsuariosAsync(CancellationToken cancellationToken);
        Task<Usuario> ValidarUsuarioAsync(string login, string password, CancellationToken cancellationToken);
    }
}
