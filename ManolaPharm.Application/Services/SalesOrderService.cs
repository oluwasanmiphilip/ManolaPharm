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
                Remarks = o.Remarks
            });
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
                CreatedAt = DateTime.UtcNow
            };

            await _context.Set<SalesOrder>().AddAsync(order);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
