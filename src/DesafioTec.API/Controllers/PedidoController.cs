using AutoMapper;
using DesafioTec.API.DTO;
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
        public async Task<ActionResult> ObterTodosPedidos()
        {
            var result = _mapper.Map<IEnumerable<PedidoDTO>>(await _pedidoRepository.ObterTodos());

            return Ok(result);
        }

        [HttpGet("obter-pedidos-cliente/{id:int}")]
        public async Task<ActionResult> ObterTodosPedidosPorCliente(int id)
        {
            var result = _mapper.Map<IEnumerable<PedidoDTO>>(await _pedidoRepository.ObterPedidosPorCliente(id));

            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult> CriarPedido(PedidoDTO pedidoDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var pedido = _mapper.Map<Pedido>(pedidoDTO);
            await _pedidoService.Adicionar(pedido);

            if (!OperacaoValida()) return CustomResponse(pedido);
            if (!await _uow.Commit()) return CustomResponse(pedido);

            return Ok(pedido);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> EditarPedido(int id, PedidoDTO pedidoDTO)
        {
            if (id != pedidoDTO.PedidoId)
            {
                NotificarErro("O id informado é diferente do que foi passado na query");
                return CustomResponse(pedidoDTO);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _pedidoService.Atualizar(_mapper.Map<Pedido>(pedidoDTO));

            if (!OperacaoValida()) return CustomResponse(pedidoDTO);
            if (!await _uow.Commit()) return CustomResponse(pedidoDTO);

            return CustomResponse(pedidoDTO);
        }

        [HttpDelete("{id:int}")]
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
