using FastOrder.Application.Contracts;
using FastOrder.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FastOrder.Controllers
{
    [Route("clients")]
    public class ClientController : BaseController
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDTO>> FindByIdAsync(long id)
        {
            return await _clientService.FindById(id);
        }

        [HttpPost]
        public async Task<ActionResult<ClientDTO>> PostAsync()
        {
            return await _clientService.Add();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<ClientDTO>> PutAsync(long id)
        {
            return await _clientService.Update(id);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientDTO>> Delete(long id)
        {
            return await _clientService.FindById(id);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDTO>> FindById(long id)
        {
            return await _clientService.FindById(id);
        }
    }
}
