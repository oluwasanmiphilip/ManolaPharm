using ManolaPharm.Application.DTOs.Finance.AccountsReceivableDtos;
using ManolaPharm.Domain.Entities.Finance;
using ManolaPharm.Persistence;
using ManolaPharm.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManolaPharm.Application.Services.Finance
{
    public class AccountsReceivableService
    {
        private readonly ApplicationDbContext _context;

        public AccountsReceivableService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AccountsReceivableReadDto>> GetAllAsync()
        {
            var records = await _context.AccountsReceivables
                .AsNoTracking()
                .Include(a => a.SalesOrder)
                .ToListAsync();

            return records.Select(a => new AccountsReceivableReadDto
            {
                Id = a.Id,
                SalesOrderId = a.SalesOrderId,
                AmountOwed = a.AmountOwed,
                AmountPaid = a.AmountPaid,
                DueDate = a.DueDate,
                PaymentDate = a.PaymentDate,
                Status = a.Status,
                Remarks = a.Remarks,
                IsActive = a.IsActive,
                CreatedAt = a.CreatedAt
            });
        }

        public async Task<AccountsReceivableReadDto> GetByIdAsync(Guid id)
        {
            var record = await _context.AccountsReceivables
                .AsNoTracking()
                .Include(a => a.SalesOrder)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (record == null) return null;

            return new AccountsReceivableReadDto
            {
                Id = record.Id,
                SalesOrderId = record.SalesOrderId,
                AmountOwed = record.AmountOwed,
                AmountPaid = record.AmountPaid,
                DueDate = record.DueDate,
                PaymentDate = record.PaymentDate,
                Status = record.Status,
                Remarks = record.Remarks,
                IsActive = record.IsActive,
                CreatedAt = record.CreatedAt
            };
        }

        public async Task<bool> CreateAsync(AccountsReceivableCreateDto dto)
        {
            var newRecord = new AccountsReceivable
            {
                Id = Guid.NewGuid(),
                SalesOrderId = dto.SalesOrderId,
                AmountOwed = dto.AmountOwed,
                AmountPaid = dto.AmountPaid,
                DueDate = dto.DueDate,
                Remarks = dto.Remarks,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            _context.AccountsReceivables.Add(newRecord);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Guid id, AccountsReceivableUpdateDto dto)
        {
            var record = await _context.AccountsReceivables.FindAsync(id);
            if (record == null) return false;

            record.AmountOwed = dto.AmountOwed;
            record.AmountPaid = dto.AmountPaid;
            record.DueDate = dto.DueDate;
            record.PaymentDate = dto.PaymentDate;
            record.Status = dto.Status;
            record.Remarks = dto.Remarks;
            record.UpdatedAt = DateTime.UtcNow;

            _context.AccountsReceivables.Update(record);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var record = await _context.AccountsReceivables.FindAsync(id);
            if (record == null) return false;

            _context.AccountsReceivables.Remove(record);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
