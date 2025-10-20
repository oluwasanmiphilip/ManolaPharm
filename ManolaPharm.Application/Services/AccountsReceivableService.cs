using ManolaPharm.Application.DTOs.FinanceDtos;
using ManolaPharm.Domain.Entities.Finance;
using ManolaPharm.Persistence;
using ManolaPharm.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ManolaPharm.Application.Services
{
    public class AccountsReceivableService
    {
        private readonly ApplicationDbContext _context;

        public AccountsReceivableService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AccountsReceivableDto>> GetAllAsync()
        {
            var receivables = await _context.Set<AccountsReceivable>().ToListAsync();
            return receivables.Select(r => new AccountsReceivableDto
            {
                AmountDue = r.AmountDue,
                AmountPaid = r.AmountPaid,
                DueDate = r.DueDate,
                PaymentDate = r.PaymentDate,
                Status = r.Status,
                Remarks = r.Remarks,
                IsActive = r.IsActive,
                CreatedAt = r.CreatedAt,
                UpdatedAt = r.UpdatedAt
            });
        }

        public async Task<AccountsReceivableDto> GetByIdAsync(Guid id)
        {
            var r = await _context.Set<AccountsReceivable>().FindAsync(id);
            if (r == null) return null;

            return new AccountsReceivableDto
            {
                AmountDue = r.AmountDue,
                AmountPaid = r.AmountPaid,
                DueDate = r.DueDate,
                PaymentDate = r.PaymentDate,
                Status = r.Status,
                Remarks = r.Remarks,
                IsActive = r.IsActive,
                CreatedAt = r.CreatedAt,
                UpdatedAt = r.UpdatedAt
            };
        }

        public async Task<bool> CreateAsync(AccountsReceivableCreateDto dto)
        {
            var ar = new AccountsReceivable
            {
                Id = Guid.NewGuid(),
                SalesOrderId = dto.SalesOrderId,
                AmountDue = dto.AmountDue,
                DueDate = dto.DueDate,
                Remarks = dto.Remarks,
                CreatedAt = DateTime.UtcNow,
                Status = "Pending",
                IsActive = true
            };

            await _context.Set<AccountsReceivable>().AddAsync(ar);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Guid id, AccountsReceivableUpdateDto dto)
        {
            var ar = await _context.Set<AccountsReceivable>().FindAsync(id);
            if (ar == null) return false;

            ar.AmountPaid = dto.AmountPaid;
            ar.PaymentDate = dto.PaymentDate;
            ar.Status = dto.Status;
            ar.Remarks = dto.Remarks;
            ar.IsActive = dto.IsActive;
            ar.UpdatedAt = DateTime.UtcNow;

            _context.Set<AccountsReceivable>().Update(ar);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var ar = await _context.Set<AccountsReceivable>().FindAsync(id);
            if (ar == null) return false;

            _context.Set<AccountsReceivable>().Remove(ar);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
