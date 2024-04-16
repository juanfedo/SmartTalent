using Aplicacion.DTO;

namespace Aplicacion.Servicios
{
    public interface IAutenticacionService
    {
        Task<UsuarioDTO> ValidarUsuarioAsync(string login, string password, CancellationToken cancellationToken);
    }
}
