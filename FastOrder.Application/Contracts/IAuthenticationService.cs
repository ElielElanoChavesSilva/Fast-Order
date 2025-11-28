using FastOrder.Application.DTOs;

namespace FastOrder.Application.Contracts
{
    public interface IAuthenticationService
    {
        Task<long> SignUp(ClientDTO clientDto);
    }
}
