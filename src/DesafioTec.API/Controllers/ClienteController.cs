using AutoMapper;
using DesafioTec.API.DTO;
using DesafioTec.API.Request;
using DesafioTec.Business.Entities;
using DesafioTec.Business.Interfaces;
using DesafioTec.Business.Interfaces.Persistence;
using DesafioTec.Business.Interfaces.Repository;
using DesafioTec.Business.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTec.API.Controllers
{
    [Route("api/clientes")]
    public class ClienteController : MainController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IPedidoService _pedidoService;
        private readonly IClienteService _clienteService;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public ClienteController(IClienteRepository clienteRepository,
                                 IMapper mapper,
                                 IClienteService clienteService,
                                 INotificador notificador,
                                 IUnitOfWork uow,
                                 IPedidoService pedidoService) : base(notificador)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _clienteService = clienteService;
            _uow = uow;
            _pedidoService = pedidoService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ClienteDTO>))]
        public async Task<ActionResult> ObterTodosClientes()
        {
            var result = _mapper.Map<IEnumerable<ClienteDTO>>(await _clienteRepository.ObterTodos());

            return CustomResponse(result);
        }


        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClienteDTO))]
        public async Task<ActionResult> ObterClientePorId(int id)
        {
            var result = _mapper.Map<ClienteDTO>(await _clienteRepository.ObterPorId(id));
            
            if (result == null)
            {
                NotificarErro("Cliente inexistente");
                return CustomResponse();
            }

            return CustomResponse(result);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ClienteDTO))]
        public async Task<ActionResult> CriarCliente(ClienteRequest clienteRequest)
        {
            if(!ModelState.IsValid) return CustomResponse(ModelState);

            var cliente = _mapper.Map<Cliente>(clienteRequest);
            await _clienteService.Adicionar(cliente);


            if (!OperacaoValida()) return CustomResponse();
            if (!await _uow.Commit()) return CustomResponse(clienteRequest);

            var result = _mapper.Map<ClienteDTO>(cliente);
            result.ClienteId = cliente.ClienteId;

            return CustomResponse(result);
        }


        [HttpPost("criar-cliente-pedido")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ClientePedidoDTO))]
        public async Task<ActionResult> CriarClientePedido(ClientePedidoDTO clienteDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var cliente = _mapper.Map<Cliente>(clienteDTO);
            await _clienteService.Adicionar(cliente);

            if (!OperacaoValida()) return CustomResponse(cliente);
            if (!await _uow.Commit()) return CustomResponse(clienteDTO);

            return CustomResponse(cliente);
        }


        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClienteDTO))]
        public async Task<ActionResult> EditarCliente(int id, ClienteRequest clienteDTO)
        {
            clienteDTO.ClienteId = id;
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _clienteService.Atualizar(_mapper.Map<Cliente>(clienteDTO));

            if (!OperacaoValida()) return CustomResponse(clienteDTO);
            if (!await _uow.Commit()) return CustomResponse(clienteDTO);

            return CustomResponse(clienteDTO);
        }



        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ClienteDTO))]
        public async Task<ActionResult<ClienteDTO>> ExcluirClientePedido(int id)
        {
            var cliente = await _clienteRepository.ObterPorId(id);

            if (cliente == null) return NotFound();

            await _pedidoService.RemoverPorCliente(id);
            await _clienteService.Remover(id);

            if (!await _uow.Commit()) return CustomResponse(cliente);

            return CustomResponse(cliente);
        }
    }
}
