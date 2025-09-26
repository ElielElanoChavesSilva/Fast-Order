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
        public async Task<CreatedResult> PostAsync(ClientDTO dto)
        {
            await _clientService.Add(dto);
            return Created();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(long id, ClientDTO dto)
        {
            await _clientService.Put(dto);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            await _clientService.Delete(id);
            return NoContent();
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> FindAllAsync()
        {
            return Ok(await _clientService.FindAllAsync());
        }
    }
}
