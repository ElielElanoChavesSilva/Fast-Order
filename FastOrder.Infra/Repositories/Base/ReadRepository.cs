using FastOrder.Domain.Repositories.Base;
using FastOrder.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace FastOrder.Infra.Repositories.Base
{
    public abstract class ReadRepository<TId, TEntity> : IReadRepository<TId, TEntity> where TEntity : class
    {
        private readonly MainContext _context;

        protected ReadRepository(MainContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<TEntity>> FindAll()
        {
            return _context.Set<TEntity>().ToListAsync();
        }

        public Task<TEntity> FindById(TId id)
        {
            throw new NotImplementedException();
        }
    }
}
