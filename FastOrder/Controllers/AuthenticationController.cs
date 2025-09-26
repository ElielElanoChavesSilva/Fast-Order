using FastOrder.Application.Contracts;
using FastOrder.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace FastOrder.Controllers
{
    [Route("auth")]
    public class AuthenticationController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(
            IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<ActionResult<int>> SignUpAsync(ClientDTO dto)
        {
            var id = await _authenticationService.SignUp(dto);
            return Created("auth/me", id);
        }
    }
}
