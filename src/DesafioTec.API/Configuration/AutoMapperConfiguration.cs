using AutoMapper;
using DesafioTec.API.DTO;
using DesafioTec.API.Request;
using DesafioTec.Business.Entities;

namespace DesafioTec.API.Configuration
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            // CLIENTES 

            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Cliente, ClienteRequest>().ReverseMap();


            //CLIENTES PEDIDOS
            CreateMap<Cliente, ClientePedidoDTO>().ReverseMap();


            // PEDIDOS

            CreateMap<Pedido, PedidoDTO>().ReverseMap();
            CreateMap<Pedido, PedidoRequest>().ReverseMap();

        }
    }
}
