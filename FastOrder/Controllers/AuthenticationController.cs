using FastOrder.Application.Contracts;
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

        //[HttpGet]
        //public async Task<ActionResult<int>> MeAsync()
        //{
        //    // var id = await _authenticationService.SignUp(dto);
        //    return Created("auth/me", id);
        //}
    }
}
