using ManolaPharm.Application.DTOs.InventoryDtos;
using ManolaPharm.Domain.Entities.Inventory;
using ManolaPharm.Persistence;
using ManolaPharm.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ManolaPharm.Application.Services
{
    public class InventoryService
    {
        private readonly ApplicationDbContext _context;

        public InventoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InventoryDto>> GetAllAsync()
        {
            var inventories = await _context.Set<Inventory>()
                .Include(i => i.Product)
                .ToListAsync();

            return inventories.Select(i => new InventoryDto
            {
                ProductName = i.Product.Name,
                QuantityOnHand = i.QuantityOnHand,
                CostPrice = i.CostPrice,
                Location = i.Location,
                BatchNumber = i.BatchNumber,
                ExpiryDate = i.ExpiryDate,
                LotTrackingEnabled = i.LotTrackingEnabled,
                LastRestocked = i.LastRestocked,
                LastUpdated = i.LastUpdated
            });
        }

        public async Task<InventoryDto> GetByIdAsync(Guid id)
        {
            var i = await _context.Set<Inventory>()
                .Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (i == null) return null;

            return new InventoryDto
            {
                ProductName = i.Product.Name,
                QuantityOnHand = i.QuantityOnHand,
                CostPrice = i.CostPrice,
                Location = i.Location,
                BatchNumber = i.BatchNumber,
                ExpiryDate = i.ExpiryDate,
                LotTrackingEnabled = i.LotTrackingEnabled,
                LastRestocked = i.LastRestocked,
                LastUpdated = i.LastUpdated
            };
        }

        public async Task<bool> CreateAsync(InventoryCreateDto dto)
        {
            var inventory = new Inventory
            {
                Id = Guid.NewGuid(),
                ProductId = dto.ProductId,
                QuantityOnHand = dto.QuantityOnHand,
                CostPrice = dto.CostPrice,
                Location = dto.Location,
                BatchNumber = dto.BatchNumber,
                ExpiryDate = dto.ExpiryDate,
                LotTrackingEnabled = dto.LotTrackingEnabled,
                LastRestocked = dto.LastRestocked,
                LastUpdated = dto.LastUpdated
            };

            await _context.Set<Inventory>().AddAsync(inventory);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Guid id, InventoryUpdateDto dto)
        {
            var inventory = await _context.Set<Inventory>().FindAsync(id);
            if (inventory == null) return false;

            inventory.QuantityOnHand = dto.QuantityOnHand;
            inventory.CostPrice = dto.CostPrice;
            inventory.Location = dto.Location;
            inventory.BatchNumber = dto.BatchNumber;
            inventory.ExpiryDate = dto.ExpiryDate;
            inventory.LotTrackingEnabled = dto.LotTrackingEnabled;
            inventory.LastRestocked = dto.LastRestocked;
            inventory.LastUpdated = dto.LastUpdated;

            _context.Set<Inventory>().Update(inventory);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var inventory = await _context.Set<Inventory>().FindAsync(id);
            if (inventory == null) return false;

            _context.Set<Inventory>().Remove(inventory);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
