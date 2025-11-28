using FastOrder.Domain.Entities;
using FastOrder.Domain.Repositories;
using FastOrder.Infra.Context;
using FastOrder.Infra.Repositories.Base;

namespace FastOrder.Infra.Repositories.ItemOrder
{
    public class ItemOrderRepository(MainContext context) : CrudRepository<long, ItemOrderEntity>(context),IItemOrderRepository
    {
    }
}
