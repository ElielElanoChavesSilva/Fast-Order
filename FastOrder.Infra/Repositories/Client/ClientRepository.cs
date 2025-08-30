using FastOrder.Domain.Entities;
using FastOrder.Domain.Repositories;
using FastOrder.Infra.Context;
using FastOrder.Infra.Repositories.Base;

namespace FastOrder.Infra.Repositories.Client
{
    public class ClientRepository : CrudRepository<long , ClientEntity>, IClientRepository
    {
        public ClientRepository(MainContext context) : base(context)
        {
        }
    }
}
