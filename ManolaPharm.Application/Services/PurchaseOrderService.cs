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
                Remarks = o.Remarks
            });
        }

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
    }
}
