using AutoMapper;
using DesafioTec.API.DTO;
using DesafioTec.API.Request;
using DesafioTec.Business.Entities;
using DesafioTec.Business.Interfaces;
using DesafioTec.Business.Interfaces.Persistence;
using DesafioTec.Business.Interfaces.Repository;
using DesafioTec.Business.Interfaces.Services;
using DesafioTec.Business.Services;
using DesafioTec.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTec.API.Controllers
{
    [Route("api/pedidos")]
    public class PedidoController : MainController
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoService _pedidoService;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public PedidoController(IPedidoRepository pedidoRepository,
                                 IMapper mapper,
                                 IPedidoService pedidoService, INotificador notificador, IUnitOfWork uow) : base(notificador)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
            _pedidoService = pedidoService;
            _uow = uow;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PedidoDTO))]
        public async Task<ActionResult> ObterTodosPedidos()
        {
            var result = _mapper.Map<IEnumerable<PedidoDTO>>(await _pedidoRepository.ObterTodos());

            return CustomResponse(result);
        }


        [HttpGet("obter-pedidos-cliente/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PedidoDTO))]
        public async Task<ActionResult> ObterTodosPedidosPorCliente(int id)
        {
            var result = _mapper.Map<IEnumerable<PedidoDTO>>(await _pedidoRepository.ObterPedidosPorCliente(id));

            return CustomResponse(result);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PedidoDTO))]
        public async Task<ActionResult> CriarPedido(PedidoRequest pedidoRequest)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var pedido = _mapper.Map<Pedido>(pedidoRequest);
            await _pedidoService.Adicionar(pedido);


            if (!OperacaoValida()) return CustomResponse(pedido);
            if (!await _uow.Commit()) return CustomResponse(pedido);

            var result = _mapper.Map<PedidoDTO>(pedido);
            result.PedidoId = pedido.PedidoId;

            return CustomResponse(result);
        }


        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PedidoDTO))]
        public async Task<ActionResult> EditarPedido(int id, PedidoRequest pedidoRequest)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            pedidoRequest.PedidoId = id;
            var pedido = _mapper.Map<Pedido>(pedidoRequest);
            await _pedidoService.Atualizar(pedido);


            if (!OperacaoValida()) return CustomResponse(pedidoRequest);
            if (!await _uow.Commit()) return CustomResponse(pedidoRequest);

            var result = _mapper.Map<PedidoDTO>(pedido);
            result.ClienteId = pedido.ClienteId;

            return CustomResponse(pedidoRequest);
        }


        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PedidoDTO))]
        public async Task<ActionResult<PedidoDTO>> ExcluirPedido(int id)
        {
            var pedido = await _pedidoRepository.ObterPorId(id);

            if (pedido == null) return NotFound();

            await _pedidoService.Remover(id);
            if (!await _uow.Commit()) return CustomResponse(pedido);

            return CustomResponse(pedido);
        }
    }
}
