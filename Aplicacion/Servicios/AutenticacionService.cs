using Aplicacion.DTO;
using AutoMapper;
using Infraestructura.Autenticacion;
using Infraestructura.Repositorios;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacion.Servicios
{
    public class AutenticacionService : IAutenticacionService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        readonly IJWTHandler _handler;

        public AutenticacionService(IJWTHandler handler, IUsuarioRepository repository, IMapper mapper)
        {
            _handler = handler;
            _usuarioRepository = repository;
            _mapper = mapper;
        }

        public async Task<string> ValidarUsuarioAsync(string login, string password, CancellationToken cancellationToken)
        {
            string token = string.Empty;
            var usuario = await _usuarioRepository.ValidarUsuarioAsync(login, password, cancellationToken);
            if (usuario != null)
            {
                token = _handler.CreateToken(usuario.Login, usuario.EsAdministrador);
            }
            return token;
        }
    }
}
