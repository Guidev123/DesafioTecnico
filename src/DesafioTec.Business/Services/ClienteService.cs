using DesafioTec.Business.Entities;
using DesafioTec.Business.Entities.Validations;
using DesafioTec.Business.Interfaces;
using DesafioTec.Business.Interfaces.Repository;
using DesafioTec.Business.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTec.Business.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository,
                              INotificador notificador) : base(notificador)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task Adicionar(Cliente cliente)
        {
            if (!ValidarEntidade(new ClienteValidation(), cliente)) return;

            if(_clienteRepository.Buscar(c => c.Email == cliente.Email).Result.Any())
            {
                Notificar("Já existe um cliente com este email");
                return;
            }

            await _clienteRepository.Adicionar(cliente);
        }

        public async Task Atualizar(Cliente cliente)
        {
            if (!ValidarEntidade(new ClienteValidation(), cliente)) return;

            if (_clienteRepository.Buscar(c => c.Email == cliente.Email && c.ClienteId != cliente.ClienteId).Result.Any())
            {
                Notificar("Já existe um cliente com este email");
                return;
            }

            await _clienteRepository.Atualizar(cliente);
        }


        public async Task Remover(int id)
        {
            await _clienteRepository.Remover(id);
        }
        public void Dispose()
        {
            _clienteRepository?.Dispose();
        }
    }
}
