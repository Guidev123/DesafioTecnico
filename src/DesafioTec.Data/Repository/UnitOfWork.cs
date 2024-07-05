using DesafioTec.Business.Interfaces.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTec.Data.Repository
{
    public class UnitOfWork(DesafioTecDb _context) : IUnitOfWork
    {
        public async Task<bool> Commit()
        {
            var ret = await _context.SaveChangesAsync();
            if (ret > 0) return true;
            return false;
        }

        public async Task<bool> Rollback()
        {
            return await Task.FromResult(true);
        }
    }
}
