using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PPB.Application.Interfaces.Identity;
using PPB.Application.Models.Identity;

namespace PPB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest registrationRequest)
        {
            var registerCheck = await _authService.Register(registrationRequest);
            return Ok(registerCheck);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest authRequest)
        {
            var loginCheck = await _authService.Login(authRequest);
            return Ok(loginCheck);
        }

        //[HttpGet("logout")]
        //public IActionResult Logout() { }
    }
}
