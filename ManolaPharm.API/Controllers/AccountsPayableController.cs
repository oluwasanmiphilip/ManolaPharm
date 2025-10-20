using ManolaPharm.Application.DTOs.FinanceDtos;
using ManolaPharm.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManolaPharm.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsPayableController : ControllerBase
    {
        private readonly AccountsPayableService _service;

        public AccountsPayableController(AccountsPayableService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound("Accounts payable not found.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AccountsPayableCreateDto dto)
        {
            var success = await _service.CreateAsync(dto);
            if (!success) return BadRequest("Failed to create accounts payable record.");
            return Ok("Accounts payable record created successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, AccountsPayableUpdateDto dto)
        {
            var success = await _service.UpdateAsync(id, dto);
            if (!success) return NotFound("Accounts payable not found.");
            return Ok("Accounts payable record updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound("Accounts payable not found.");
            return NoContent();
        }
    }
}
