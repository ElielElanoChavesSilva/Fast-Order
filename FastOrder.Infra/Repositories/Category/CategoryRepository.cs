using FastOrder.Domain.Entities;
using FastOrder.Domain.Repositories;
using FastOrder.Infra.Context;
using FastOrder.Infra.Repositories.Base;

namespace FastOrder.Infra.Repositories.Category
{
    public class CategoryRepository(MainContext context) : CrudRepository<long, CategoryEntity>(context),ICategoryRepository
    {
    }
}
