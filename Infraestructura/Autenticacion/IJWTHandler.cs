namespace Infraestructura.Autenticacion
{
    public interface IJWTHandler
    {
        string CreateToken(string login, bool esAdministrador);
    }
}
