using Aplicacion.DTO;
using AutoMapper;
using Dominio.Entidades;

namespace Aplicacion.Utilidades
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Alimento, AlimentoDTO>();
            CreateMap<AlimentoDTO, Alimento>();
            CreateMap<UsuarioDTO, Usuario>();
            CreateMap<Usuario, UsuarioDTO>();
        }
    }
}
