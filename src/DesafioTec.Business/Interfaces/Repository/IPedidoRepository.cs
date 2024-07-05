using DesafioTec.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTec.Business.Interfaces.Repository
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
        Task<IEnumerable<Pedido>> ObterPedidosPorCliente(int clienteId); // RETORNA TODOS OS PEDIDOS DE UM CLIENTE
    }
}
