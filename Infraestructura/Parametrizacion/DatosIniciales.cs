using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Parametrizacion
{
    public class DatosIniciales
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            var admin = new Usuario() { 
                Id = 1,
                Login = "admin", 
                Password = "admin", 
                EsAdministrador = true 
            };

            var usuario = new Usuario() { 
                Id = 2,
                Login = "user", 
                Password = "user", 
                EsAdministrador = false 
            };

            modelBuilder.Entity<Usuario>().HasData(admin, usuario);
        }
    }
}
