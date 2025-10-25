using ManolaPharm.Application.DTOs.Finance;
using ManolaPharm.Application.DTOs.FinanceDtos;
using ManolaPharm.Domain.Entities.Finance;
using ManolaPharm.Persistence;
using ManolaPharm.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManolaPharm.Application.Services.Finance
{
    public class DepreciationService
    {
        private readonly ApplicationDbContext _context;

        public DepreciationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DepreciationDto>> GetAllAsync()
        {
            var depreciations = await _context.Depreciations
                .Include(d => d.FixedAsset)
                .ToListAsync();

            return depreciations.Select(d => new DepreciationDto
            {
                Id = d.Id,
                FixedAssetId = d.FixedAssetId,
                AssetName = d.FixedAsset?.AssetName,
                DepreciationDate = d.DepreciationDate,
                DepreciationAmount = d.DepreciationAmount,
                AccumulatedDepreciation = d.AccumulatedDepreciation,
                BookValue = d.BookValue,
                Remarks = d.Remarks,
                IsPosted = d.IsPosted,
                CreatedAt = d.CreatedAt
            }).ToList();
        }

        public async Task<DepreciationDto> GetByIdAsync(Guid id)
        {
            var d = await _context.Depreciations
                .Include(x => x.FixedAsset)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (d == null) return null;

            return new DepreciationDto
            {
                Id = d.Id,
                FixedAssetId = d.FixedAssetId,
                AssetName = d.FixedAsset?.AssetName,
                DepreciationDate = d.DepreciationDate,
                DepreciationAmount = d.DepreciationAmount,
                AccumulatedDepreciation = d.AccumulatedDepreciation,
                BookValue = d.BookValue,
                Remarks = d.Remarks,
                IsPosted = d.IsPosted,
                CreatedAt = d.CreatedAt
            };
        }

        public async Task CreateAsync(CreateDepreciationDto dto)
        {
            var asset = await _context.FixedAssets.FindAsync(dto.FixedAssetId);
            if (asset == null)
                throw new Exception("Fixed asset not found.");

            var accumulatedDep = asset.AccumulatedDepreciation + dto.DepreciationAmount;
            var bookValue = asset.Cost - accumulatedDep;

            var depreciation = new Depreciation
            {
                Id = Guid.NewGuid(),
                FixedAssetId = dto.FixedAssetId,
                DepreciationDate = dto.DepreciationDate,
                DepreciationAmount = dto.DepreciationAmount,
                AccumulatedDepreciation = accumulatedDep,
                BookValue = bookValue,
                Remarks = dto.Remarks,
                IsPosted = false
            };

            // update asset accumulated depreciation
            asset.AccumulatedDepreciation = accumulatedDep;

            await _context.Depreciations.AddAsync(depreciation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateDepreciationDto dto)
        {
            var dep = await _context.Depreciations.FindAsync(dto.Id);
            if (dep == null) return;

            dep.DepreciationAmount = dto.DepreciationAmount;
            dep.Remarks = dto.Remarks;
            dep.IsPosted = dto.IsPosted;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var dep = await _context.Depreciations.FindAsync(id);
            if (dep == null) return;

            _context.Depreciations.Remove(dep);
            await _context.SaveChangesAsync();
        }
    }
}
