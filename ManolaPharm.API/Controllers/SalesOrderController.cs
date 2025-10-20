using ManolaPharm.Application.DTOs.SalesDtos;
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

        [HttpPost]
        public async Task<IActionResult> Create(SalesOrderCreateDto dto)
        {
            var success = await _service.CreateAsync(dto);
            if (!success) return BadRequest("Failed to create sales order.");
            return Ok("Sales order created successfully.");
        }
    }
}
