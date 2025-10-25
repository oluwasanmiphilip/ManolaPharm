using ManolaPharm.Application.DTOs.Finance;
using ManolaPharm.Application.DTOs.FinanceDtos;
using ManolaPharm.Application.Services.Finance;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ManolaPharm.API.Controllers.Finance
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepreciationController : ControllerBase
    {
        private readonly DepreciationService _service;

        public DepreciationController(DepreciationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var data = await _service.GetByIdAsync(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDepreciationDto dto)
        {
            await _service.CreateAsync(dto);
            return Ok(new { Message = "Depreciation record created successfully." });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateDepreciationDto dto)
        {
            await _service.UpdateAsync(dto);
            return Ok(new { Message = "Depreciation record updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok(new { Message = "Depreciation record deleted successfully." });
        }
    }
}
