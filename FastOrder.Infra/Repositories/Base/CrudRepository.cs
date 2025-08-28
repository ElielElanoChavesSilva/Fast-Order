using FastOrder.Domain.Repositories.Base;

namespace FastOrder.Infra.Repositories.Base
{
    public class CrudRepository<TId,TEntity> : ReadRepository<TId, TEntity>, ICrudRepository<TId, TEntity> where TEntity : class
    {
        public TId Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TId id)
        {
            throw new NotImplementedException();
        }
    }
}
