using ManolaPharm.Application.DTOs.HRDtos;
using ManolaPharm.Domain.Entities.HR;
using ManolaPharm.Persistence;
using ManolaPharm.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ManolaPharm.Application.Services
{
    public class PayrollService
    {
        private readonly ApplicationDbContext _context;

        public PayrollService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PayrollDto>> GetAllAsync()
        {
            var payrolls = await _context.Set<Payroll>().ToListAsync();
            return payrolls.Select(p => new PayrollDto
            {
                EmployeeId = p.EmployeeId,
                BasicSalary = p.BasicSalary,
                Allowances = p.Allowances,
                Deductions = p.Deductions,
                PayrollDate = p.PayrollDate,
                NetPay = p.NetPay,
                IsActive = p.IsActive,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            });
        }

        public async Task<PayrollDto> GetByIdAsync(Guid id)
        {
            var p = await _context.Set<Payroll>().FindAsync(id);
            if (p == null) return null;

            return new PayrollDto
            {
                EmployeeId = p.EmployeeId,
                BasicSalary = p.BasicSalary,
                Allowances = p.Allowances,
                Deductions = p.Deductions,
                PayrollDate = p.PayrollDate,
                NetPay = p.NetPay,
                IsActive = p.IsActive,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            };
        }

        public async Task<bool> CreateAsync(PayrollCreateDto dto)
        {
            var payroll = new Payroll
            {
                Id = Guid.NewGuid(),
                EmployeeId = dto.EmployeeId,
                BasicSalary = dto.BasicSalary,
                Allowances = dto.Allowances,
                Deductions = dto.Deductions,
                PayrollDate = dto.PayrollDate,
                CreatedAt = DateTime.UtcNow
            };

            await _context.Set<Payroll>().AddAsync(payroll);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Guid id, PayrollUpdateDto dto)
        {
            var payroll = await _context.Set<Payroll>().FindAsync(id);
            if (payroll == null) return false;

            payroll.BasicSalary = dto.BasicSalary;
            payroll.Allowances = dto.Allowances;
            payroll.Deductions = dto.Deductions;
            payroll.PayrollDate = dto.PayrollDate;
            payroll.UpdatedAt = DateTime.UtcNow;

            _context.Set<Payroll>().Update(payroll);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var payroll = await _context.Set<Payroll>().FindAsync(id);
            if (payroll == null) return false;

            payroll.IsActive = false;
            payroll.UpdatedAt = DateTime.UtcNow;

            _context.Set<Payroll>().Update(payroll);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
