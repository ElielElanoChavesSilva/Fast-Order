using FastOrder.Application.DTOs;
using FastOrder.Domain.Entities;

namespace FastOrder.Application.Mappers
{
    public static class ClientMapper
    {
        public static ClientDTO ToDTO(ClientEntity entity)
        {
            return new ClientDTO(entity.Id, entity.Name, entity.Email, entity.DocumentNumber);
        }

        public static IEnumerable<ClientDTO> ToListDTO(IEnumerable<ClientEntity> entities)
        {
            return entities.Select(x => new ClientDTO(x.Id, x.Name, x.Email, x.DocumentNumber));
        }

        public static ClientEntity ToEntity(ClientDTO dto)
        {
            return new ClientEntity
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                DocumentNumber = dto.DocumentNumber
            };
        }
        ///<summary>
        ///Converte uma lista de ClientDTO para um IEnumerable de ClientyEntity
        ///</summary>
        /// <param name="lista de DTO"></param>>
        public static IEnumerable<ClientEntity> ToListEntity(IEnumerable<ClientDTO> dtos)
        {
            return dtos.Select(x => new ClientEntity
            {
                Name = x.Name,
                Email = x.Email,
                DocumentNumber = x.DocumentNumber
            });
        }
    }
}
