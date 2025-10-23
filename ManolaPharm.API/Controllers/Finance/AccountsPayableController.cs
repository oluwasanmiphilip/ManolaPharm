using Microsoft.AspNetCore.Mvc;
using ManolaPharm.Application.Services.Finance;
using ManolaPharm.Application.DTOs.FinanceDtos;
using System;
using System.Threading.Tasks;

namespace ManolaPharm.API.Controllers.Finance
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsPayableController : ControllerBase
    {
        private readonly AccountsPayableService _service;

        public AccountsPayableController(AccountsPayableService service)
        {
            _service = service;
        }

        // GET: api/accountspayable
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        // GET: api/accountspayable/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var payable = await _service.GetByIdAsync(id);
            if (payable == null)
                return NotFound("Accounts payable record not found.");

            return Ok(payable);
        }

        // POST: api/accountspayable
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AccountsPayableCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var message = await _service.CreateAsync(dto);
            return Ok(message);
        }

        // PUT: api/accountspayable/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] AccountsPayableCreateDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var message = await _service.UpdateAsync(id, dto);
            if (message.Contains("not found", StringComparison.OrdinalIgnoreCase))
                return NotFound(message);

            return Ok(message);
        }

        // DELETE: api/accountspayable/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var message = await _service.DeleteAsync(id);
            if (message.Contains("not found", StringComparison.OrdinalIgnoreCase))
                return NotFound(message);

            return Ok(message);
        }
    }
}
