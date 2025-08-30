using FastOrder.Domain.Repositories.Base;
using FastOrder.Infra.Context;

namespace FastOrder.Infra.Repositories.Base
{
    public class CrudRepository<TId, TEntity> : ReadRepository<TId, TEntity>, ICrudRepository<TId, TEntity> where TEntity : class
    {
        protected CrudRepository(MainContext context) : base(context)
        {
        }

        public Task<TEntity> Add(TEntity entity)
        {
               var response =  Context.AddAsync(entity).AsTask();
               Context.SaveChanges();
               return Task.FromResult(response.Result.Entity);
        }

        public void Update(TEntity entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
        }

        public void Delete(TId id)
        {
            Context.SaveChanges();
        }
    }
}
