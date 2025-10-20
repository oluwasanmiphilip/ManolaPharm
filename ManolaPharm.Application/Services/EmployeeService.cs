using ManolaPharm.Application.DTOs.HRDtos;
using ManolaPharm.Domain.Entities.HR;
using ManolaPharm.Persistence;
using ManolaPharm.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ManolaPharm.Application.Services
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all employees
        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employees = await _context.Set<Employee>()
                .Include(e => e.Department)
                .Include(e => e.Role)
                .ToListAsync();

            return employees.Select(e => new EmployeeDto
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                Address = e.Address,
                City = e.City,
                State = e.State,
                Country = e.Country,
                Email = e.Email,
                Phone = e.Phone,
                Status = e.Status,
                DateOfBirth = e.DateOfBirth,
                DateHired = e.DateHired,
                IsActive = e.IsActive,
                CreatedAt = e.CreatedAt,
                UpdatedAt = e.UpdatedAt,
                DepartmentName = e.Department?.Name,
                RoleName = e.Role?.Name
            });
        }

        // Get employee by Id
        public async Task<EmployeeDto> GetByIdAsync(Guid id)
        {
            var e = await _context.Set<Employee>()
                .Include(emp => emp.Department)
                .Include(emp => emp.Role)
                .FirstOrDefaultAsync(emp => emp.Id == id);

            if (e == null) return null;

            return new EmployeeDto
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                Address = e.Address,
                City = e.City,
                State = e.State,
                Country = e.Country,
                Email = e.Email,
                Phone = e.Phone,
                Status = e.Status,
                DateOfBirth = e.DateOfBirth,
                DateHired = e.DateHired,
                IsActive = e.IsActive,
                CreatedAt = e.CreatedAt,
                UpdatedAt = e.UpdatedAt,
                DepartmentName = e.Department?.Name,
                RoleName = e.Role?.Name
            };
        }

        // Create new employee
        public async Task<bool> CreateAsync(EmployeeCreateDto dto)
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Address = dto.Address,
                City = dto.City,
                State = dto.State,
                Country = dto.Country,
                Email = dto.Email,
                Phone = dto.Phone,
                DateOfBirth = dto.DateOfBirth,
                DateHired = dto.DateHired,
                DepartmentId = dto.DepartmentId,
                RoleId = dto.RoleId,
                Status = "Active",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _context.Set<Employee>().AddAsync(employee);
            return await _context.SaveChangesAsync() > 0;
        }

        // Update employee
        public async Task<bool> UpdateAsync(Guid id, EmployeeUpdateDto dto)
        {
            var e = await _context.Set<Employee>().FindAsync(id);
            if (e == null) return false;

            e.FirstName = dto.FirstName;
            e.LastName = dto.LastName;
            e.Address = dto.Address;
            e.City = dto.City;
            e.State = dto.State;
            e.Country = dto.Country;
            e.Email = dto.Email;
            e.Phone = dto.Phone;
            e.DateOfBirth = dto.DateOfBirth;
            e.DateHired = dto.DateHired;
            e.DepartmentId = dto.DepartmentId;
            e.RoleId = dto.RoleId;
            e.Status = dto.Status;
            e.IsActive = dto.IsActive;
            e.UpdatedAt = DateTime.UtcNow;

            _context.Set<Employee>().Update(e);
            return await _context.SaveChangesAsync() > 0;
        }

        // Delete employee (soft delete)
        public async Task<bool> DeleteAsync(Guid id)
        {
            var e = await _context.Set<Employee>().FindAsync(id);
            if (e == null) return false;

            e.IsActive = false;
            e.Status = "Inactive";
            e.UpdatedAt = DateTime.UtcNow;

            _context.Set<Employee>().Update(e);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
