using ManolaPharm.Domain.Entities.HR;
using ManolaPharm.Application.DTOs.HRDtos;
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

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employees = await _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Role)
                .ToListAsync();

            return employees.Select(e => new EmployeeDto
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                Phone = e.Phone,
                DepartmentName = e.Department?.Name,
                RoleName = e.Role?.Name,
                Status = e.Status,
                DateHired = e.DateHired
            });
        }

        public async Task<EmployeeDto> GetByIdAsync(Guid id)
        {
            var e = await _context.Employees
                .Include(x => x.Department)
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (e == null) return null;

            return new EmployeeDto
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                Phone = e.Phone,
                DepartmentName = e.Department?.Name,
                RoleName = e.Role?.Name,
                Status = e.Status,
                DateHired = e.DateHired
            };
        }

        public async Task<bool> CreateAsync(EmployeeCreateDto dto)
        {
            var employee = new Employee
            {
                Id = Guid.NewGuid(),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Phone = dto.Phone,
                DepartmentId = dto.DepartmentId,
                RoleId = dto.RoleId,
                DateOfBirth = dto.DateOfBirth,
                DateHired = dto.DateHired,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            await _context.Employees.AddAsync(employee);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(EmployeeUpdateDto dto)
        {
            var employee = await _context.Employees.FindAsync(dto.Id);
            if (employee == null) return false;

            employee.FirstName = dto.FirstName;
            employee.LastName = dto.LastName;
            employee.Email = dto.Email;
            employee.Phone = dto.Phone;
            employee.DepartmentId = dto.DepartmentId;
            employee.RoleId = dto.RoleId;
            employee.Status = dto.Status;
            employee.DateHired = dto.DateHired;
            employee.UpdatedAt = DateTime.UtcNow;

            _context.Employees.Update(employee);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return false;

            _context.Employees.Remove(employee);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
