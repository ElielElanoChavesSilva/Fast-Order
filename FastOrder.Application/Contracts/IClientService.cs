using FastOrder.Application.DTOs;

namespace FastOrder.Application.Contracts
{
    public interface IClientService
    {
        Task<ClientDTO> FindById(long id);
        Task<IEnumerable<ClientDTO>>FindAllAsync();
        Task Delete (long id);
        Task Add(ClientDTO dto);
        Task Put(ClientDTO dto);
    }
}
