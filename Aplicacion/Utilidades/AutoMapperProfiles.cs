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
            CreateMap<Usuario, UsuarioGetDTO>();
            CreateMap<UsuarioGetDTO, Usuario>();
            CreateMap<Alimento, AlimentoGetDTO>();
            CreateMap<AlimentoGetDTO, Alimento>();
            CreateMap<CatalogoDTO, Catalogo>();
            CreateMap<Catalogo, CatalogoDTO>();
            CreateMap<CatalogoPostDTO, Catalogo>();
            CreateMap<AlimentoCatalogoDTO, AlimentoCatalogo>();
            CreateMap<AlimentoCatalogo, AlimentoCatalogoDTO>();
            CreateMap<Pedido, PedidoDTO>();
            CreateMap<PedidoDTO, Pedido>();
            CreateMap<PedidoPostDTO, Pedido>();
            CreateMap<PedidoDetalle, PedidoDetalleDTO>();
            CreateMap<PedidoDetalleDTO, PedidoDetalle>();
        }
    }
}
