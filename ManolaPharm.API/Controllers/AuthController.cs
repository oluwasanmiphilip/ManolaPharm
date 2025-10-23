using Microsoft.AspNetCore.Mvc;
using ManolaPharm.Application.Services;
using ManolaPharm.Application.DTOs.AuthDtos;
using System.Threading.Tasks;

namespace ManolaPharm.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _auth;

        public AuthController(AuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _auth.AuthenticateAsync(dto);
            if (result == null)
                return Unauthorized("Invalid credentials.");

            return Ok(result);
        }
    }
}
