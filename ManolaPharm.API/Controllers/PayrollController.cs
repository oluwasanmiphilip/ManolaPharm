using ManolaPharm.Application.DTOs.HRDtos;
using ManolaPharm.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManolaPharm.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PayrollController : ControllerBase
    {
        private readonly PayrollService _service;

        public PayrollController(PayrollService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound("Payroll record not found.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PayrollCreateDto dto)
        {
            var success = await _service.CreateAsync(dto);
            if (!success) return BadRequest("Failed to create payroll record.");
            return Ok("Payroll record created successfully.");
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, PayrollUpdateDto dto)
        {
            var success = await _service.UpdateAsync(id, dto);
            if (!success) return NotFound("Payroll record not found or could not be updated.");
            return Ok("Payroll record updated successfully.");
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound("Payroll record not found or could not be deleted.");
            return Ok("Payroll record deleted successfully.");
        }
    }
}
