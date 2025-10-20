using ManolaPharm.Application.DTOs.WarehouseDtos;
using ManolaPharm.Domain.Entities.Warehouse;
using ManolaPharm.Persistence;
using ManolaPharm.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ManolaPharm.Application.Services
{
    public class WarehouseService
    {
        private readonly ApplicationDbContext _context;

        public WarehouseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WarehouseDto>> GetAllAsync()
        {
            var warehouses = await _context.Set<Warehouse>().ToListAsync();
            return warehouses.Select(w => new WarehouseDto
            {
               
                Name = w.Name,
                Location = w.Location,
                Address = w.Address,
                City = w.City,
                State = w.State,
                Country = w.Country,
                Manager = w.Manager,
                Phone = w.Phone,
                Email = w.Email,
                Capacity = w.Capacity,
                IsActive = w.IsActive
            });
        }

        public async Task<WarehouseDto> GetByIdAsync(Guid id)
        {
            var w = await _context.Set<Warehouse>().FindAsync(id);
            if (w == null) return null;

            return new WarehouseDto
            {
                
                Name = w.Name,
                Location = w.Location,
                Address = w.Address,
                City = w.City,
                State = w.State,
                Country = w.Country,
                Manager = w.Manager,
                Phone = w.Phone,
                Email = w.Email,
                Capacity = w.Capacity,
                IsActive = w.IsActive
            };
        }

        public async Task<bool> CreateAsync(WarehouseCreateDto dto)
        {
            var warehouse = new Warehouse
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Location = dto.Location,
                Address = dto.Address,
                City = dto.City,
                State = dto.State,
                Country = dto.Country,
                Manager = dto.Manager,
                Phone = dto.Phone,
                Email = dto.Email,
                Capacity = dto.Capacity,
                IsActive = true
            };

            await _context.Set<Warehouse>().AddAsync(warehouse);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Guid id, WarehouseUpdateDto dto)
        {
            var warehouse = await _context.Set<Warehouse>().FindAsync(id);
            if (warehouse == null) return false;

            warehouse.Name = dto.Name;
            warehouse.Location = dto.Location;
            warehouse.Address = dto.Address;
            warehouse.City = dto.City;
            warehouse.State = dto.State;
            warehouse.Country = dto.Country;
            warehouse.Manager = dto.Manager;
            warehouse.Phone = dto.Phone;
            warehouse.Email = dto.Email;
            warehouse.Capacity = dto.Capacity;
            warehouse.IsActive = dto.IsActive;

            _context.Set<Warehouse>().Update(warehouse);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var warehouse = await _context.Set<Warehouse>().FindAsync(id);
            if (warehouse == null) return false;

            _context.Set<Warehouse>().Remove(warehouse);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
