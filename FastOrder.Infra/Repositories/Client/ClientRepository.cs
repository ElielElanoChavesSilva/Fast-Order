using FastOrder.Domain.Entities;
using FastOrder.Domain.Repositories;
using FastOrder.Infra.Context;
using FastOrder.Infra.Repositories.Base;

namespace FastOrder.Infra.Repositories.Client
{
    public class ClientRepository(MainContext context) : CrudRepository<long , ClientEntity>(context), IClientRepository
    {
     
    }
}
