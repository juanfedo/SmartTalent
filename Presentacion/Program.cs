using Aplicacion.Servicios;
using Infraestructura.Contexto;
using Infraestructura.Repositorios;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Infraestructura.Autenticacion;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace Presentacion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var config = builder.Configuration;
            // Add services to the container.

            builder.Services.AddControllers().
                AddJsonOptions(opciones => opciones.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>(opciones => opciones.UseSqlServer("name=LocalConnection"), ServiceLifetime.Scoped);
            builder.Services.AddAutoMapper(typeof(Aplicacion.Utilidades.AutoMapperProfiles));

            var secretKey = config["JwtSettings:Key"]!;
            var keyBytes = Encoding.UTF8.GetBytes(secretKey ?? string.Empty);

            builder.Services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(config =>
            {
                config.RequireHttpsMetadata = false;
                config.SaveToken = true;
                config.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

           /* builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy(IdentityData.AdminUserPolicyName, p =>
                    p.RequireClaim(IdentityData.AdminUserClaimName, "True"));
            }); */

            builder.Services.AddScoped<IJWTHandler>(x => ActivatorUtilities.CreateInstance<JWTHandler>(x, secretKey));
            builder.Services.AddScoped<IAutenticacionService, AutenticacionService>();
            builder.Services.AddScoped<IAlimentoService, AlimentoService>();
            builder.Services.AddScoped<IAlimentoRepository, AlimentoRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddScoped<ICatalogoRepository, CatalogoRepository>();
            builder.Services.AddScoped<ICatalogoService, CatalogoService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
