using AutoMapper;
using DesafioTec.API.DTO;
using DesafioTec.Business.Entities;
using DesafioTec.Business.Interfaces;
using DesafioTec.Business.Interfaces.Repository;
using DesafioTec.Business.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace DesafioTec.API.Controllers
{
    [Route("api/clientes")]
    public class ClienteController : MainController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;
        public ClienteController(IClienteRepository clienteRepository,
                                 IMapper mapper,
                                 IClienteService clienteService,
                                 INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<ActionResult> ObterTodosClientes()
        {
            var result = _mapper.Map<IEnumerable<ClienteDTO>>(await _clienteRepository.ObterTodos());

            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult> CriarCliente(ClienteDTO clienteDTO)
        {
            if(!ModelState.IsValid) return CustomResponse(ModelState);

            var cliente = _mapper.Map<Cliente>(clienteDTO);
            await _clienteService.Adicionar(cliente);
            
            if(!OperacaoValida()) return CustomResponse(cliente);

            return Ok(cliente);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> EditarCliente(int id, ClienteDTO clienteDTO)
        {
            if (id != clienteDTO.ClienteId)
            {
                NotificarErro("O id informado é diferente do que foi passado na query");
                return CustomResponse(clienteDTO);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _clienteService.Atualizar(_mapper.Map<Cliente>(clienteDTO));

            return CustomResponse(clienteDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ClienteDTO>> ExcluirCliente(int id)
        {
            var cliente = await _clienteRepository.ObterPorId(id);

            if (cliente == null) return NotFound();

            await _clienteService.Remover(id);

            return CustomResponse(cliente);
        }
    }
}
