using ManolaPharm.Application.DTOs.FinanceDtos;
using ManolaPharm.Domain.Entities.Finance;
using ManolaPharm.Persistence;
using ManolaPharm.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ManolaPharm.Application.Services
{
    public class AccountsPayableService
    {
        private readonly ApplicationDbContext _context;

        public AccountsPayableService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AccountsPayableDto>> GetAllAsync()
        {
            var payables = await _context.Set<AccountsPayable>().ToListAsync();
            return payables.Select(p => new AccountsPayableDto
            {
                AmountOwed = p.AmountOwed,
                AmountPaid = p.AmountPaid,
                DueDate = p.DueDate,
                PaymentDate = p.PaymentDate,
                Status = p.Status,
                Remarks = p.Remarks,
                IsActive = p.IsActive,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            });
        }

        public async Task<AccountsPayableDto> GetByIdAsync(Guid id)
        {
            var p = await _context.Set<AccountsPayable>().FindAsync(id);
            if (p == null) return null;

            return new AccountsPayableDto
            {
                AmountOwed = p.AmountOwed,
                AmountPaid = p.AmountPaid,
                DueDate = p.DueDate,
                PaymentDate = p.PaymentDate,
                Status = p.Status,
                Remarks = p.Remarks,
                IsActive = p.IsActive,
                CreatedAt = p.CreatedAt,
                UpdatedAt = p.UpdatedAt
            };
        }

        public async Task<bool> CreateAsync(AccountsPayableCreateDto dto)
        {
            var payable = new AccountsPayable
            {
                Id = Guid.NewGuid(),
                PurchaseOrderId = dto.PurchaseOrderId,
                AmountOwed = dto.AmountOwed,
                DueDate = dto.DueDate,
                Remarks = dto.Remarks,
                CreatedAt = DateTime.UtcNow,
                Status = "Pending",
                IsActive = true
            };

            await _context.Set<AccountsPayable>().AddAsync(payable);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Guid id, AccountsPayableUpdateDto dto)
        {
            var p = await _context.Set<AccountsPayable>().FindAsync(id);
            if (p == null) return false;

            p.AmountPaid = dto.AmountPaid;
            p.PaymentDate = dto.PaymentDate;
            p.Status = dto.Status;
            p.Remarks = dto.Remarks;
            p.IsActive = dto.IsActive;
            p.UpdatedAt = DateTime.UtcNow;

            _context.Set<AccountsPayable>().Update(p);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var p = await _context.Set<AccountsPayable>().FindAsync(id);
            if (p == null) return false;

            _context.Set<AccountsPayable>().Remove(p);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
