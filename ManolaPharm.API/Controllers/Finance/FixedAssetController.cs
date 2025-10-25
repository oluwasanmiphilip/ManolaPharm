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
    public class FixedAssetController : ControllerBase
    {
        private readonly FixedAssetService _service;

        public FixedAssetController(FixedAssetService service)
        {
            _service = service;
        }

        // GET: api/FixedAsset
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        // GET: api/FixedAsset/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result == null)
                return NotFound("Fixed Asset record not found.");

            return Ok(result);
        }

        // POST: api/FixedAsset
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFixedAssetDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.CreateAsync(dto);
            return Ok("Fixed Asset created successfully.");
        }

        // PUT: api/FixedAsset
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFixedAssetDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.UpdateAsync(dto);
            return Ok("Fixed Asset updated successfully.");
        }

        // DELETE: api/FixedAsset/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return Ok("Fixed Asset deleted successfully.");
        }
    }
}
