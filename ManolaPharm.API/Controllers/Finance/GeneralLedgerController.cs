using Microsoft.AspNetCore.Mvc;
using ManolaPharm.Application.Services.Finance;
using ManolaPharm.Application.DTOs.FinanceDtos;
using System;
using System.Threading.Tasks;

namespace ManolaPharm.API.Controllers.Finance
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeneralLedgerController : ControllerBase
    {
        private readonly GeneralLedgerService _service;

        public GeneralLedgerController(GeneralLedgerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ledger = await _service.GetByIdAsync(id);
            if (ledger == null) return NotFound();
            return Ok(ledger);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GeneralLedgerCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return result ? Ok("General ledger entry created successfully.") : BadRequest("Failed to create ledger entry.");
        }

        [HttpPut]
        public async Task<IActionResult> Update(GeneralLedgerUpdateDto dto)
        {
            var result = await _service.UpdateAsync(dto);
            return result ? Ok("Ledger entry updated successfully.") : NotFound("Ledger entry not found.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.DeleteAsync(id);
            return result ? Ok("Ledger entry deleted successfully.") : NotFound("Ledger entry not found.");
        }
    }
}
