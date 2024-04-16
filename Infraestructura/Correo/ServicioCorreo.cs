using System.Net;
using System.Net.Mail;

namespace Infraestructura.Correo
{
    public class ServicioCorreo : IServicioCorreo
    {
        public void EnviarCorreo(string correoUsuario, int pedidoId)
        {
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("email", "password"),
                EnableSsl = true,
            };

            smtpClient.Send("facturacion@gmail.com", correoUsuario, "Confirmación Pedido", $"El pedido {pedidoId} ha sido generado exitosamente.");
        }
    }
}
