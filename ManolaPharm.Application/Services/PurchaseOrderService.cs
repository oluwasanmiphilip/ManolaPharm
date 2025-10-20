using ManolaPharm.Application.DTOs.PurchasingDtos;
using ManolaPharm.Domain.Entities.Purchasing;
using ManolaPharm.Persistence;
using ManolaPharm.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ManolaPharm.Application.Services
{
    public class PurchaseOrderService
    {
        private readonly ApplicationDbContext _context;

        public PurchaseOrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all
        public async Task<IEnumerable<PurchaseOrderDto>> GetAllAsync()
        {
            var orders = await _context.Set<PurchaseOrder>().ToListAsync();
            return orders.Select(o => new PurchaseOrderDto
            {
                OrderNumber = o.OrderNumber,
                OrderDate = o.OrderDate,
                ExpectedDeliveryDate = o.ExpectedDeliveryDate,
                TotalAmount = o.TotalAmount,
                Status = o.Status,
                Remarks = o.Remarks,
                IsActive = o.IsActive,
                CreatedAt = o.CreatedAt,
                UpdatedAt = o.UpdatedAt
            });
        }

        // Get by Id
        public async Task<PurchaseOrderDto> GetByIdAsync(Guid id)
        {
            var o = await _context.Set<PurchaseOrder>().FindAsync(id);
            if (o == null) return null;

            return new PurchaseOrderDto
            {
                OrderNumber = o.OrderNumber,
                OrderDate = o.OrderDate,
                ExpectedDeliveryDate = o.ExpectedDeliveryDate,
                TotalAmount = o.TotalAmount,
                Status = o.Status,
                Remarks = o.Remarks,
                IsActive = o.IsActive,
                CreatedAt = o.CreatedAt,
                UpdatedAt = o.UpdatedAt
            };
        }

        // Create
        public async Task<bool> CreateAsync(PurchaseOrderCreateDto dto)
        {
            var order = new PurchaseOrder
            {
                Id = Guid.NewGuid(),
                OrderNumber = $"PO-{DateTime.UtcNow:yyyyMMddHHmmss}",
                SupplierId = dto.SupplierId,
                WarehouseId = dto.WarehouseId,
                TotalAmount = dto.TotalAmount,
                Status = "Pending",
                Remarks = dto.Remarks,
                CreatedAt = DateTime.UtcNow
            };

            await _context.Set<PurchaseOrder>().AddAsync(order);
            return await _context.SaveChangesAsync() > 0;
        }

        // Update
        public async Task<bool> UpdateAsync(PurchaseOrderUpdateDto dto)
        {
            var order = await _context.Set<PurchaseOrder>().FindAsync(dto.Id);
            if (order == null) return false;

            order.ExpectedDeliveryDate = dto.ExpectedDeliveryDate;
            order.TotalAmount = dto.TotalAmount;
            order.Status = dto.Status;
            order.Remarks = dto.Remarks;
            order.IsActive = dto.IsActive;
            order.UpdatedAt = DateTime.UtcNow;

            _context.Set<PurchaseOrder>().Update(order);
            return await _context.SaveChangesAsync() > 0;
        }

        // Delete
        public async Task<bool> DeleteAsync(Guid id)
        {
            var order = await _context.Set<PurchaseOrder>().FindAsync(id);
            if (order == null) return false;

            _context.Set<PurchaseOrder>().Remove(order);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
