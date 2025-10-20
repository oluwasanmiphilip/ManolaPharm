using ManolaPharm.Application.DTOs.SalesDtos;
using ManolaPharm.Application.DTOs.SalesDtos.ManolaPharm.Application.DTOs.SalesDtos;
using ManolaPharm.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManolaPharm.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesOrderController : ControllerBase
    {
        private readonly SalesOrderService _service;

        public SalesOrderController(SalesOrderService service)
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
            if (result == null) return NotFound("Sales order not found.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SalesOrderCreateDto dto)
        {
            var success = await _service.CreateAsync(dto);
            if (!success) return BadRequest("Failed to create sales order.");
            return Ok("Sales order created successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, SalesOrderUpdateDto dto)
        {
            var success = await _service.UpdateAsync(id, dto);
            if (!success) return NotFound("Sales order not found.");
            return Ok("Sales order updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound("Sales order not found.");
            return NoContent();
        }
    }
}
