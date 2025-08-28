namespace FastOrder.Domain.Repositories.Base
{
    public interface IReadRepository<TId, TEntity> where TEntity : class
    {
        Task<List<TEntity>> FindAll();
        Task<TEntity?> FindById(TId id);
    }
}
