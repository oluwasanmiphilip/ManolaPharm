using ManolaPharm.Application.DTOs.CustomerDtos;
using ManolaPharm.Domain.Entities.Customer;
using ManolaPharm.Persistence;
using ManolaPharm.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ManolaPharm.Application.Services
{
    public class CustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            var customers = await _context.Set<Customer>().ToListAsync();
            return customers.Select(c => new CustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                ContactPerson = c.ContactPerson,
                Email = c.Email,
                Phone = c.Phone,
                Address = c.Address,
                City = c.City,
                State = c.State,
                Country = c.Country,
                IsActive = c.IsActive
            });
        }

        public async Task<CustomerDto> GetByIdAsync(Guid id)
        {
            var c = await _context.Set<Customer>().FindAsync(id);
            if (c == null) return null;

            return new CustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                ContactPerson = c.ContactPerson,
                Email = c.Email,
                Phone = c.Phone,
                Address = c.Address,
                City = c.City,
                State = c.State,
                Country = c.Country,
                IsActive = c.IsActive
            };
        }

        public async Task<bool> CreateAsync(CustomerCreateDto dto)
        {
            var customer = new Customer
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

            await _context.Set<Customer>().AddAsync(customer);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Guid id, CustomerUpdateDto dto)
        {
            var customer = await _context.Set<Customer>().FindAsync(id);
            if (customer == null) return false;

            customer.Name = dto.Name;
            customer.ContactPerson = dto.ContactPerson;
            customer.Email = dto.Email;
            customer.Phone = dto.Phone;
            customer.Address = dto.Address;
            customer.City = dto.City;
            customer.State = dto.State;
            customer.Country = dto.Country;
            customer.IsActive = dto.IsActive;
            customer.UpdatedAt = DateTime.UtcNow;

            _context.Set<Customer>().Update(customer);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var customer = await _context.Set<Customer>().FindAsync(id);
            if (customer == null) return false;

            _context.Set<Customer>().Remove(customer);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
