using AutoMapper;
using DesafioTec.Business.Interfaces;
using DesafioTec.Business.Interfaces.Repository;
using DesafioTec.Business.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTec.API.Controllers
{
    [Route("api/pedidos")]
    public class PedidoController : MainController
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoService _pedidoService;
        private readonly IMapper _mapper;
        public PedidoController(IPedidoRepository pedidoRepository,
                                 IMapper mapper,
                                 IPedidoService pedidoService, INotificador notificador) : base(notificador)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
            _pedidoService = pedidoService;
        }
    }
}
