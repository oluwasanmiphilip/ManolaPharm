using ManolaPharm.Application.DTOs.RoleDtos;
using ManolaPharm.Domain.Entities.HR;
using ManolaPharm.Domain.Entities.Users;
using ManolaPharm.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManolaPharm.Application.Services
{
    public class RoleService
    {
        private readonly ApplicationDbContext _context;

        public RoleService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoleDto>> GetAllAsync()
        {
            var roles = await _context.Set<Role>().ToListAsync();
            return roles.Select(r => new RoleDto
            {
                Name = r.Name,
                Description = r.Description,
                
            });
        }

        public async Task<RoleDto> GetByIdAsync(Guid id)
        {
            var role = await _context.Set<Role>().FirstOrDefaultAsync(r => r.Id == id);
            if (role == null)
                return null;

            return new RoleDto
            {
                Name = role.Name,
                Description = role.Description,
                
            };
        }

        public async Task<bool> CreateAsync(RoleCreateDto dto)
        {
            var role = new Role
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            await _context.Set<Role>().AddAsync(role);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Guid id, RoleUpdateDto dto)
        {
            var role = await _context.Set<Role>().FirstOrDefaultAsync(r => r.Id == id);
            if (role == null)
                return false;

            role.Name = dto.Name;
            role.Description = dto.Description;

            _context.Set<Role>().Update(role);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var role = await _context.Set<Role>().FirstOrDefaultAsync(r => r.Id == id);
            if (role == null)
                return false;

            _context.Set<Role>().Remove(role);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
