using Microsoft.AspNetCore.Mvc;
using ManolaPharm.Application.Services.Finance;
using ManolaPharm.Application.DTOs.Finance;
using System;
using System.Threading.Tasks;

namespace ManolaPharm.API.Controllers.Finance
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankReconciliationController : ControllerBase
    {
        private readonly BankReconciliationService _service;

        public BankReconciliationController(BankReconciliationService service)
        {
            _service = service;
        }

        // GET: api/BankReconciliation
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        // GET: api/BankReconciliation/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound("Bank Reconciliation record not found.");

            return Ok(result);
        }

        // POST: api/BankReconciliation
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBankReconciliationDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.CreateAsync(dto);
            return Ok("Bank Reconciliation record created successfully.");
        }

        // PUT: api/BankReconciliation
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBankReconciliationDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.UpdateAsync(dto);
            return Ok("Bank Reconciliation record updated successfully.");
        }

        // DELETE: api/BankReconciliation/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok("Bank Reconciliation record deleted successfully.");
        }
    }
}
