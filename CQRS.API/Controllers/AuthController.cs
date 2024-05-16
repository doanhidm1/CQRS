using CQRS.Application.Identity;
using CQRS.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            var response = await _authService.Login(request);
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<ActionResult<AuthResponse>> Register(RegistrationRequest request)
        {
            var response = await _authService.Register(request);
            return Ok(response);
        }
    }
}
