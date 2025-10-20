using ManolaPharm.Application.DTOs.FinanceDtos;
using ManolaPharm.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManolaPharm.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsReceivableController : ControllerBase
    {
        private readonly AccountsReceivableService _service;

        public AccountsReceivableController(AccountsReceivableService service)
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
            if (result == null) return NotFound("Accounts receivable not found.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AccountsReceivableCreateDto dto)
        {
            var success = await _service.CreateAsync(dto);
            if (!success) return BadRequest("Failed to create accounts receivable record.");
            return Ok("Accounts receivable record created successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, AccountsReceivableUpdateDto dto)
        {
            var success = await _service.UpdateAsync(id, dto);
            if (!success) return NotFound("Accounts receivable not found.");
            return Ok("Accounts receivable record updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound("Accounts receivable not found.");
            return NoContent();
        }
    }
}
