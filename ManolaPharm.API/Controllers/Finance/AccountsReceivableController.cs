using ManolaPharm.Application.DTOs.Finance.AccountsReceivableDtos;
using ManolaPharm.Application.Services.Finance;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ManolaPharm.API.Controllers.Finance
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsReceivableController : ControllerBase
    {
        private readonly AccountsReceivableService _service;

        public AccountsReceivableController(AccountsReceivableService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null) return NotFound("Record not found.");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AccountsReceivableCreateDto dto)
        {
            var success = await _service.CreateAsync(dto);
            return success ? Ok("Account receivable created successfully.")
                           : BadRequest("Failed to create account receivable.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, AccountsReceivableUpdateDto dto)
        {
            var success = await _service.UpdateAsync(id, dto);
            return success ? Ok("Account receivable updated successfully.")
                           : NotFound("Record not found.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.DeleteAsync(id);
            return success ? Ok("Account receivable deleted successfully.")
                           : NotFound("Record not found.");
        }
    }
}
