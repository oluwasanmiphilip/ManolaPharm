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
    public class FixedAssetService
    {
        private readonly ApplicationDbContext _context;

        public FixedAssetService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<FixedAssetDto>> GetAllAsync()
        {
            var assets = await _context.FixedAssets.ToListAsync();

            return assets.Select(a => new FixedAssetDto
            {
                Id = a.Id,
                AssetName = a.AssetName,
                AssetCode = a.AssetCode,
                Category = a.Category,
                Cost = a.Cost,
                AccumulatedDepreciation = a.AccumulatedDepreciation,
                PurchaseDate = a.PurchaseDate,
                DisposalDate = a.DisposalDate,
                Location = a.Location,
                Department = a.Department,
                DepreciationMethod = a.DepreciationMethod,
                ResidualValue = a.ResidualValue,
                UsefulLifeYears = a.UsefulLifeYears,
                IsActive = a.IsActive
            }).ToList();
        }

        public async Task<FixedAssetDto> GetByIdAsync(Guid id)
        {
            var asset = await _context.FixedAssets.FindAsync(id);
            if (asset == null) return null;

            return new FixedAssetDto
            {
                Id = asset.Id,
                AssetName = asset.AssetName,
                AssetCode = asset.AssetCode,
                Category = asset.Category,
                Cost = asset.Cost,
                AccumulatedDepreciation = asset.AccumulatedDepreciation,
                PurchaseDate = asset.PurchaseDate,
                DisposalDate = asset.DisposalDate,
                Location = asset.Location,
                Department = asset.Department,
                DepreciationMethod = asset.DepreciationMethod,
                ResidualValue = asset.ResidualValue,
                UsefulLifeYears = asset.UsefulLifeYears,
                IsActive = asset.IsActive
            };
        }

        public async Task CreateAsync(CreateFixedAssetDto dto)
        {
            var asset = new FixedAsset
            {
                Id = Guid.NewGuid(),
                AssetName = dto.AssetName,
                AssetCode = dto.AssetCode,
                Category = dto.Category,
                Cost = dto.Cost,
                PurchaseDate = dto.PurchaseDate,
                Location = dto.Location,
                Department = dto.Department,
                DepreciationMethod = dto.DepreciationMethod,
                ResidualValue = dto.ResidualValue,
                UsefulLifeYears = dto.UsefulLifeYears,
                AccumulatedDepreciation = 0,
                IsActive = true
            };

            await _context.FixedAssets.AddAsync(asset);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateFixedAssetDto dto)
        {
            var asset = await _context.FixedAssets.FindAsync(dto.Id);
            if (asset == null) return;

            asset.AssetName = dto.AssetName;
            asset.Category = dto.Category;
            asset.Cost = dto.Cost;
            asset.PurchaseDate = dto.PurchaseDate;
            asset.Location = dto.Location;
            asset.Department = dto.Department;
            asset.DepreciationMethod = dto.DepreciationMethod;
            asset.ResidualValue = dto.ResidualValue;
            asset.UsefulLifeYears = dto.UsefulLifeYears;
            asset.IsActive = dto.IsActive;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var asset = await _context.FixedAssets.FindAsync(id);
            if (asset == null) return;

            _context.FixedAssets.Remove(asset);
            await _context.SaveChangesAsync();
        }
    }
}
