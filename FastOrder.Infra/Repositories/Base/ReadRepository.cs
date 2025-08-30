using FastOrder.Domain.Repositories.Base;
using FastOrder.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace FastOrder.Infra.Repositories.Base
{
    public abstract class ReadRepository<TId, TEntity> : IReadRepository<TId, TEntity> where TEntity : class
    {
        protected readonly MainContext Context;

        protected ReadRepository(MainContext context)
        {
            Context = context;
        }

        public Task<List<TEntity>> FindAll()
        {
            return Context.Set<TEntity>().ToListAsync();
        }

        public Task<TEntity?> FindById(TId id)
        {
            return Context.FindAsync<TEntity>(id).AsTask();
        }
    }
}
