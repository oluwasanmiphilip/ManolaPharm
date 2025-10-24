using ManolaPharm.Application.DTOs.Finance.TrialBalanceDtos;
using ManolaPharm.Application.Services.Finance;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ManolaPharm.API.Controllers.Finance
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrialBalanceController : ControllerBase
    {
        private readonly TrialBalanceService _service;

        public TrialBalanceController(TrialBalanceService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var tb = await _service.GetByIdAsync(id);
            if (tb == null) return NotFound();
            return Ok(tb);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TrialBalanceCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return result ? Ok("Trial balance created successfully.") : BadRequest("Failed to create record.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TrialBalanceUpdateDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            return result ? Ok("Trial balance updated successfully.") : NotFound("Record not found.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.DeleteAsync(id);
            return result ? Ok("Trial balance deleted successfully.") : NotFound("Record not found.");
        }
    }
}
