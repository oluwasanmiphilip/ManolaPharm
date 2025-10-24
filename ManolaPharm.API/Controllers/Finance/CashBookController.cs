using Microsoft.AspNetCore.Mvc;
using ManolaPharm.Application.Services.Finance;
using ManolaPharm.Application.DTOs.Finance;
using System;
using System.Threading.Tasks;

namespace ManolaPharm.API.Controllers.Finance
{
    [ApiController]
    [Route("api/[controller]")]
    public class CashBookController : ControllerBase
    {
        private readonly CashBookService _service;

        public CashBookController(CashBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var cashBook = await _service.GetByIdAsync(id);
            if (cashBook == null) return NotFound();
            return Ok(cashBook);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CashBookCreateDto dto)
        {
            var result = await _service.CreateAsync(dto);
            return result ? Ok("CashBook entry created successfully.") : BadRequest("Creation failed.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CashBookUpdateDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            return result ? Ok("CashBook updated successfully.") : NotFound("Record not found.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _service.DeleteAsync(id);
            return result ? Ok("CashBook deleted successfully.") : NotFound("Record not found.");
        }
    }
}
