namespace Infraestructura.Correo
{
    public interface IServicioCorreo
    {
        void EnviarCorreo(string correoUsuario, int pedidoId);
    }
}