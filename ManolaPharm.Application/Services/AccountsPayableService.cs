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
                Id = p.Id,
                AmountOwed = p.AmountOwed,
                AmountPaid = p.AmountPaid,
                DueDate = p.DueDate,
                PaymentDate = p.PaymentDate,
                Status = p.Status,
                Remarks = p.Remarks
            });
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
                CreatedAt = DateTime.UtcNow
            };

            await _context.Set<AccountsPayable>().AddAsync(payable);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
