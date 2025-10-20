using ManolaPharm.Application.DTOs.SupplierDtos;
using ManolaPharm.Domain.Entities.Supplier;
using ManolaPharm.Persistence;
using ManolaPharm.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ManolaPharm.Application.Services
{
    public class SupplierService
    {
        private readonly ApplicationDbContext _context;

        public SupplierService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SupplierDto>> GetAllAsync()
        {
            var suppliers = await _context.Set<Supplier>().ToListAsync();
            return suppliers.Select(s => new SupplierDto
            {
                Id = s.Id,
                Name = s.Name,
                ContactPerson = s.ContactPerson,
                Email = s.Email,
                Phone = s.Phone,
                Address = s.Address,
                City = s.City,
                State = s.State,
                Country = s.Country,
                IsActive = s.IsActive
            });
        }

        public async Task<SupplierDto> GetByIdAsync(Guid id)
        {
            var s = await _context.Set<Supplier>().FindAsync(id);
            if (s == null) return null;

            return new SupplierDto
            {
                Id = s.Id,
                Name = s.Name,
                ContactPerson = s.ContactPerson,
                Email = s.Email,
                Phone = s.Phone,
                Address = s.Address,
                City = s.City,
                State = s.State,
                Country = s.Country,
                IsActive = s.IsActive
            };
        }

        public async Task<bool> CreateAsync(SupplierCreateDto dto)
        {
            var supplier = new Supplier
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                ContactPerson = dto.ContactPerson,
                Email = dto.Email,
                Phone = dto.Phone,
                Address = dto.Address,
                City = dto.City,
                State = dto.State,
                Country = dto.Country,
                IsActive = true
            };

            await _context.Set<Supplier>().AddAsync(supplier);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Guid id, SupplierUpdateDto dto)
        {
            var supplier = await _context.Set<Supplier>().FindAsync(id);
            if (supplier == null) return false;

            supplier.Name = dto.Name;
            supplier.ContactPerson = dto.ContactPerson;
            supplier.Email = dto.Email;
            supplier.Phone = dto.Phone;
            supplier.Address = dto.Address;
            supplier.City = dto.City;
            supplier.State = dto.State;
            supplier.Country = dto.Country;
            supplier.IsActive = dto.IsActive;
            supplier.UpdatedAt = DateTime.UtcNow;

            _context.Set<Supplier>().Update(supplier);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var supplier = await _context.Set<Supplier>().FindAsync(id);
            if (supplier == null) return false;

            _context.Set<Supplier>().Remove(supplier);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
