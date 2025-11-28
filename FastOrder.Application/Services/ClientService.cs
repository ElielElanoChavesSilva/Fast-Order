using FastOrder.Application.Contracts;
using FastOrder.Application.DTOs;
using FastOrder.Application.Mappers;
using FastOrder.Domain.Repositories;

namespace FastOrder.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<ClientDTO> FindById(long id)
        {
            var entity = await _clientRepository.FindById(id) ??
                         throw new Exception("Entidade não encontrada");

            return ClientMapper.ToDTO(entity);
        }

        public async Task<IEnumerable<ClientDTO>> FindAllAsync()
        {
            var entities = await _clientRepository.FindAll();
            return ClientMapper.ToListDTO(entities);
        }

        public Task Delete(long id)
        {
            throw new NotImplementedException();
        }

        public async Task Add(ClientDTO dto)
        {
            var entity = ClientMapper.ToEntity(dto);
            await _clientRepository.Add(entity);
        }

        public Task Put(ClientDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
