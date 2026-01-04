using FastOrder.Domain.Repositories.Base;
using FastOrder.Infra.Context;

namespace FastOrder.Infra.Repositories.Base
{
    public class CrudRepository<TId, TEntity>(MainContext context) :
        ReadRepository<TId, TEntity>(context), ICrudRepository<TId, TEntity> where TEntity : class
    {

        public Task<TEntity> Add(TEntity entity)
        {
            context.AddAsync(entity);
            context.SaveChanges();
            return Task.FromResult(entity);
        }

        public void Update(TEntity entity)
        {
            context.Update(entity);
            context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public void Delete(TId id)
        {
            context.SaveChanges();
        }
    }
}
