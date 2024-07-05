﻿using DesafioTec.Business.Entities;
using DesafioTec.Business.Interfaces.Repository;

namespace DesafioTec.Data.Repository
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(DesafioTecDb context) : base(context) { }


        public async Task<IEnumerable<Pedido>> ObterPedidosPorCliente(int clienteId)
        {
            return await Buscar(p => p.ClienteId == clienteId);
        }
    }
}