using ManolaPharm.Application.DTOs.PurchasingDtos;
using ManolaPharm.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManolaPharm.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseOrderController : ControllerBase
    {
        private readonly PurchaseOrderService _service;

        public PurchaseOrderController(PurchaseOrderService service)
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
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PurchaseOrderCreateDto dto)
        {
            var success = await _service.CreateAsync(dto);
            if (!success) return BadRequest("Failed to create purchase order.");
            return Ok("Purchase order created successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> Update(PurchaseOrderUpdateDto dto)
        {
            var success = await _service.UpdateAsync(dto);
            if (!success) return NotFound("Purchase order not found.");
            return Ok("Purchase order updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound("Purchase order not found.");
            return Ok("Purchase order deleted successfully.");
        }
    }
}
