using FastOrder.Domain.Entities;
using FastOrder.Domain.Repositories.Base;

namespace FastOrder.Domain.Repositories
{
    public interface IProductRepository : ICrudRepository<long, ProductEntity>
    {
    }
}
