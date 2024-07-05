using DesafioTec.Business.Entities;
using DesafioTec.Business.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTec.Data
{
    public class DesafioTecDb : DbContext, IUnitOfWork 
    {
        public DesafioTecDb(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Cliente> Clientes { get; set; } = null!;
        public DbSet<Pedido> Pedidos { get; set; } = null!;


        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
