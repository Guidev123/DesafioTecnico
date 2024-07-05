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
    public class PedidoService : BaseService, IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository,
                             INotificador notificador) : base(notificador)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task Adicionar(Pedido pedido)
        {
            if (!ValidarEntidade(new PedidoValidation(), pedido)) return;

            await _pedidoRepository.Adicionar(pedido);
        }

        public async Task Atualizar(Pedido pedido)
        {
            if (!ValidarEntidade(new PedidoValidation(), pedido)) return;

            await _pedidoRepository.Atualizar(pedido);

        }

        public async Task Remover(int id)
        {
            await _pedidoRepository.Remover(id);    
        }
        public async void Dispose()
        {
            _pedidoRepository?.Dispose();
        }
    }
}
