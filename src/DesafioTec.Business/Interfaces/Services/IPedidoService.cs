using DesafioTec.Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTec.Business.Interfaces.Services
{
    public interface IPedidoService : IDisposable
    {
        Task Adicionar(Pedido pedido);
        Task Atualizar(Pedido pedido);
        Task Remover(int id);
        Task RemoverPorCliente(int id);
    }
}
