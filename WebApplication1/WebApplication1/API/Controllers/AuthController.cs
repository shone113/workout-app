using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Infrastructure.Data;
using WebApplication1.DTO;
using WebApplication1.Infrastructure.Auth;
using WebApplication1.Core.Domain;
using WebApplication1.Core.Interfaces;

namespace WebApplication1.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(LoginDTO dto)
        {
            var result = await _authService.RegisterAsync(dto);

            if (result == null)
                return BadRequest("Korisničko ime je zauzeto.");

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var result = await _authService.LoginAsync(dto);

            if (result == null)
                return Unauthorized("Pogrešno korisničko ime ili lozinka.");

            return Ok(result);
        }

    }
}
