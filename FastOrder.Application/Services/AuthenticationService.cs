using FastOrder.Application.Contracts;
using FastOrder.Application.DTOs;
using FastOrder.Domain.Repositories;

namespace FastOrder.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IClientRepository _clientRepository;

        public AuthenticationService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<long> SignUp(ClientDTO clientDto)
        {
            var entity = await _clientRepository.Add(new ()
            {
                Email = clientDto.Email,
                DocumentNumber = clientDto.DocumentNumber,
                Name = clientDto.Name
            });

            return entity.Id;
        }
    }
}
