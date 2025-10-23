using ManolaPharm.Application.DTOs.DepartmentDtos;
using ManolaPharm.Domain.Entities.HR;
using ManolaPharm.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ManolaPharm.Application.Services
{
    public class DepartmentService
    {
        private readonly ApplicationDbContext _context;

        public DepartmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
        {
            var departments = await _context.Departments.ToListAsync();
            return departments.Select(d => new DepartmentDto
            {
                Name = d.Name,
                Description = d.Description
            });
        }

        public async Task<DepartmentDto?> GetByIdAsync(Guid id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null) return null;

            return new DepartmentDto
            {
                Name = department.Name,
                Description = department.Description
            };
        }

        public async Task<Department> CreateAsync(DepartmentCreateDto dto)
        {
            var department = new Department
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<bool> UpdateAsync(Guid id, DepartmentUpdateDto dto)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null) return false;

            department.Name = dto.Name;
            department.Description = dto.Description;
            department.UpdatedAt = DateTime.UtcNow;

            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null) return false;

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
