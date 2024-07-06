using AutoMapper;
using DesafioTec.API.DTO;
using DesafioTec.Business.Entities;

namespace DesafioTec.API.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Pedido, PedidoDTO>().ReverseMap();
            CreateMap<ClientePedidoDTO, ClienteDTO>().ReverseMap();

            CreateMap<ClientePedidoDTO, Cliente>();
            CreateMap<ClientePedidoDTO, Pedido>();

        }
    }
}
