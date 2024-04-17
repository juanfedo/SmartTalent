namespace Aplicacion.Servicios
{
    public interface IAutenticacionService
    {
        Task<string> ValidarUsuarioAsync(string login, string password, CancellationToken cancellationToken);
    }
}
