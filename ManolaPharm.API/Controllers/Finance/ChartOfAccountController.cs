using ManolaPharm.Application.DTOs.Finance;
using ManolaPharm.Application.Services.Finance;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ManolaPharm.API.Controllers.Finance
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChartOfAccountController : ControllerBase
    {
        private readonly ChartOfAccountService _service;

        public ChartOfAccountController(ChartOfAccountService service)
        {
            _service = service;
        }

        // ✅ GET: api/chartofaccount
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var accounts = await _service.GetAllAsync();
            return Ok(accounts);
        }

        // ✅ GET: api/chartofaccount/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var account = await _service.GetByIdAsync(id);
            if (account == null)
                return NotFound("Account not found.");
            return Ok(account);
        }

        // ✅ POST: api/chartofaccount
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ChartOfAccountCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);
            if (!created)
                return Conflict("Account code already exists.");

            return Ok("Chart of Account created successfully.");
        }

        // ✅ PUT: api/chartofaccount/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ChartOfAccountUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, dto);
            if (!updated)
                return NotFound("Account not found.");

            return Ok("Chart of Account updated successfully.");
        }

        // ✅ DELETE: api/chartofaccount/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleted = await _service.DeleteAsync(id);
            if (!deleted)
                return NotFound("Account not found.");

            return Ok("Chart of Account deleted successfully.");
        }
    }
}
