using Aplicacion.Servicios;
using Infraestructura.Autenticacion;
using Infraestructura.Contexto;
using Infraestructura.Correo;
using Infraestructura.Repositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

namespace Presentacion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var config = builder.Configuration;
            builder.Services.AddControllers().
                AddJsonOptions(opciones => opciones.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "SmartTalent", Version = "v1" });
                option.AddSecurityDefinition(
                    "Bearer",
                    new OpenApiSecurityScheme
                    {
                        In = ParameterLocation.Header,
                        Description = "Por favor ingrese un token valido",
                        Name = "Authorization",
                        Type = SecuritySchemeType.Http,
                        BearerFormat = "JWT",
                        Scheme = "Bearer"
                    }
                );
                option.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] { }
                        }
                    });
            });
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

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy(IdentityData.AdminUserPolicyName, p =>
                    p.RequireClaim(IdentityData.AdminUserClaimName, "True"));
            });

            builder.Services.AddScoped<IJWTHandler>(x => ActivatorUtilities.CreateInstance<JWTHandler>(x, secretKey));
            builder.Services.AddScoped<IAutenticacionService, AutenticacionService>();
            builder.Services.AddScoped<IAlimentoService, AlimentoService>();
            builder.Services.AddScoped<IAlimentoRepository, AlimentoRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddScoped<ICatalogoRepository, CatalogoRepository>();
            builder.Services.AddScoped<ICatalogoService, CatalogoService>();
            builder.Services.AddScoped<IServicioCorreo, ServicioCorreo>();
            builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
            builder.Services.AddScoped<IPedidoService, PedidoService>();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
