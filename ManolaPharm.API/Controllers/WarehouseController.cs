using ManolaPharm.Application.DTOs.WarehouseDtos;
using ManolaPharm.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManolaPharm.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WarehouseController : ControllerBase
    {
        private readonly WarehouseService _service;

        public WarehouseController(WarehouseService service)
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
            if (result == null) return NotFound(new { message = "Warehouse not found." });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(WarehouseCreateDto dto)
        {
            var success = await _service.CreateAsync(dto);
            if (!success) return BadRequest(new { message = "Failed to create warehouse." });
            return Ok(new { message = "Warehouse created successfully." });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, WarehouseUpdateDto dto)
        {
            var success = await _service.UpdateAsync(id, dto);
            if (!success) return NotFound(new { message = "Warehouse not found." });
            return Ok(new { message = "Warehouse updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound(new { message = "Warehouse not found." });
            return NoContent();
        }
    }
}
