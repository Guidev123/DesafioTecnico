using DesafioTec.Business.Interfaces.Persistence;
using DesafioTec.Business.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTec.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DesafioTecDb Db;
        protected readonly DbSet<TEntity> DbSet;
        public Repository(DesafioTecDb db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }
        public async Task<TEntity?> ObterPorId(int id)
        {
            return await DbSet.FindAsync(id);
        }
        public async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }
        public async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }
        public async Task Atualizar(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }
        public async Task Remover(int id)
        {
            var entity = await DbSet.FindAsync(id);
            DbSet.Remove(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
