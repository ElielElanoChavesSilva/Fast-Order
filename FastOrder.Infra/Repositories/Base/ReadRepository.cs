using FastOrder.Domain.Repositories.Base;
using FastOrder.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace FastOrder.Infra.Repositories.Base
{
    public abstract class ReadRepository<TId, TEntity>(MainContext context) : IReadRepository<TId, TEntity> where TEntity : class
    {
        public virtual Task<List<TEntity>> FindAll()
        {
            return context.Set<TEntity>().ToListAsync();
        }

        public virtual Task<TEntity?> FindById(TId id)
        {
            return context.FindAsync<TEntity>(id).AsTask();
        }

        public async Task<bool> Exists(TId id) => await FindById(id) is not null;
    }
}
