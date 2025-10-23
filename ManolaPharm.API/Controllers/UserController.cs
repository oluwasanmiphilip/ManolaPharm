using Microsoft.AspNetCore.Mvc;
using ManolaPharm.Application.Services;
using ManolaPharm.Application.DTOs.UserDtos;
using ManolaPharm.Application.DTOs.AuthDtos;
using System;
using System.Threading.Tasks;

namespace ManolaPharm.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly AuthService _authService;

        public UserController(UserService userService, AuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        // ================================
        // User CRUD Endpoints
        // ================================

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _userService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound("User not found.");
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateDto dto)
        {
            var result = await _userService.CreateAsync(dto);
            return result ? Ok("User created successfully.") : BadRequest("Failed to create user.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userService.DeleteAsync(id);
            return result ? Ok("User deleted successfully.") : NotFound("User not found.");
        }

        // ================================
        // Login / JWT Endpoint
        // ================================

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var authResult = await _authService.AuthenticateAsync(dto);
            if (authResult == null)
                return Unauthorized("Invalid credentials or inactive user.");

            return Ok(authResult);
        }
    }
}
