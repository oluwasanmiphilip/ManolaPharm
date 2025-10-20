using ManolaPharm.Application.DTOs.SalesDtos;
using ManolaPharm.Application.DTOs.SalesDtos.ManolaPharm.Application.DTOs.SalesDtos;
using ManolaPharm.Domain.Entities.Sales;
using ManolaPharm.Persistence;
using ManolaPharm.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ManolaPharm.Application.Services
{
    public class SalesOrderService
    {
        private readonly ApplicationDbContext _context;

        public SalesOrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SalesOrderDto>> GetAllAsync()
        {
            var orders = await _context.Set<SalesOrder>().ToListAsync();
            return orders.Select(o => new SalesOrderDto
            {
                OrderNumber = o.OrderNumber,
                OrderDate = o.OrderDate,
                DeliveryDate = o.DeliveryDate,
                TotalAmount = o.TotalAmount,
                Status = o.Status,
                Remarks = o.Remarks,
                IsActive = o.IsActive,
                CreatedAt = o.CreatedAt,
                UpdatedAt = o.UpdatedAt
            });
        }

        public async Task<SalesOrderDto> GetByIdAsync(Guid id)
        {
            var o = await _context.Set<SalesOrder>().FindAsync(id);
            if (o == null) return null;

            return new SalesOrderDto
            {
                OrderNumber = o.OrderNumber,
                OrderDate = o.OrderDate,
                DeliveryDate = o.DeliveryDate,
                TotalAmount = o.TotalAmount,
                Status = o.Status,
                Remarks = o.Remarks,
                IsActive = o.IsActive,
                CreatedAt = o.CreatedAt,
                UpdatedAt = o.UpdatedAt
            };
        }

        public async Task<bool> CreateAsync(SalesOrderCreateDto dto)
        {
            var order = new SalesOrder
            {
                Id = Guid.NewGuid(),
                OrderNumber = $"SO-{DateTime.UtcNow:yyyyMMddHHmmss}",
                CustomerId = dto.CustomerId,
                WarehouseId = dto.WarehouseId,
                TotalAmount = dto.TotalAmount,
                Status = "Pending",
                Remarks = dto.Remarks,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            await _context.Set<SalesOrder>().AddAsync(order);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Guid id, SalesOrderUpdateDto dto)
        {
            var o = await _context.Set<SalesOrder>().FindAsync(id);
            if (o == null) return false;

            o.DeliveryDate = dto.DeliveryDate;
            o.Status = dto.Status;
            o.Remarks = dto.Remarks;
            o.IsActive = dto.IsActive;
            o.UpdatedAt = DateTime.UtcNow;

            _context.Set<SalesOrder>().Update(o);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var o = await _context.Set<SalesOrder>().FindAsync(id);
            if (o == null) return false;

            _context.Set<SalesOrder>().Remove(o);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
