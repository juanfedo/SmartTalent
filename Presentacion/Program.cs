using Aplicacion.Servicios;
using Infraestructura.Contexto;
using Infraestructura.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace Presentacion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(opciones => opciones.UseSqlServer("name=LocalConnection"), ServiceLifetime.Scoped);
            //builder.Services.AddDbContext<ApplicationDbContext>(opciones => opciones.UseSqlServer("name=LocalConnection"));
            builder.Services.AddAutoMapper(typeof(Aplicacion.Utilidades.AutoMapperProfiles));

            builder.Services.AddScoped<IAlimentoService, AlimentoService>();
            builder.Services.AddScoped<IAlimentoRepository, AlimentoRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
