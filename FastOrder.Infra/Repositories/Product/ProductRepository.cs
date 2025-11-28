using FastOrder.Domain.Entities;
using FastOrder.Domain.Repositories;
using FastOrder.Infra.Context;
using FastOrder.Infra.Repositories.Base;

namespace FastOrder.Infra.Repositories.Product
{
    public class ProductRepository(MainContext context) : CrudRepository<long, ProductEntity>(context),IProductRepository
    {
    }
}
