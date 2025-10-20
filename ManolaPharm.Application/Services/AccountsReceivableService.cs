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
                Id = r.Id,
                AmountDue = r.AmountDue,
                AmountPaid = r.AmountPaid,
                DueDate = r.DueDate,
                PaymentDate = r.PaymentDate,
                Status = r.Status,
                Remarks = r.Remarks
            });
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
                CreatedAt = DateTime.UtcNow
            };

            await _context.Set<AccountsReceivable>().AddAsync(ar);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
