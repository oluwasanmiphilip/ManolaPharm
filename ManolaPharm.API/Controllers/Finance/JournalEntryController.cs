using ManolaPharm.Application.DTOs.FinanceDtos;
using ManolaPharm.Application.Services.Finance;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ManolaPharm.API.Controllers.Finance
{
    [ApiController]
    [Route("api/[controller]")]
    public class JournalEntryController : ControllerBase
    {
        private readonly JournalEntryService _service;

        public JournalEntryController(JournalEntryService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entries = await _service.GetAllAsync();
            return Ok(entries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var entry = await _service.GetByIdAsync(id);
            if (entry == null) return NotFound("Journal entry not found.");
            return Ok(entry);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] JournalEntryCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _service.CreateAsync(dto);
            return result ? Ok("Journal entry created successfully.") : BadRequest("Failed to create journal entry.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] JournalEntryUpdateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _service.UpdateAsync(id, dto);
            return result ? Ok("Journal entry updated successfully.") : NotFound("Journal entry not found.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.DeleteAsync(id);
            return result ? Ok("Journal entry deleted successfully.") : NotFound("Journal entry not found.");
        }
    }
}
