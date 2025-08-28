namespace FastOrder.Domain.Repositories.Base
{
    public interface ICrudRepository<TId,TEntity> : IReadRepository<TId,TEntity> where TEntity : class
    {
        TId Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(TId id);
    }
}
