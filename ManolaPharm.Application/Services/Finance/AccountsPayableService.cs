using ManolaPharm.Application.DTOs.FinanceDtos;
using ManolaPharm.Domain.Entities.Finance;
using ManolaPharm.Persistence;
using ManolaPharm.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManolaPharm.Application.Services.Finance
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
            var entities = _context.AccountsPayables.ToList();

            var dtos = entities.Select(x => new AccountsPayableDto
            {
                Id = x.Id,
                PurchaseOrderNumber = x.PurchaseOrderId.ToString(), // replace later with actual PO number link
                AmountOwed = x.AmountOwed,
                AmountPaid = x.AmountPaid,
                DueDate = x.DueDate,
                PaymentDate = x.PaymentDate,
                Status = x.Status,
                Remarks = x.Remarks,
                IsActive = x.IsActive,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            }).ToList();

            return await Task.FromResult(dtos);
        }

        public async Task<AccountsPayableDto> GetByIdAsync(Guid id)
        {
            var entity = await _context.AccountsPayables.FindAsync(id);
            if (entity == null) return null;

            return new AccountsPayableDto
            {
                Id = entity.Id,
                PurchaseOrderNumber = entity.PurchaseOrderId.ToString(),
                AmountOwed = entity.AmountOwed,
                AmountPaid = entity.AmountPaid,
                DueDate = entity.DueDate,
                PaymentDate = entity.PaymentDate,
                Status = entity.Status,
                Remarks = entity.Remarks,
                IsActive = entity.IsActive,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }

        public async Task<string> CreateAsync(AccountsPayableCreateDto dto)
        {
            var entity = new AccountsPayable
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

            _context.AccountsPayables.Add(entity);
            await _context.SaveChangesAsync();

            return "Accounts payable record created successfully.";
        }

        public async Task<string> UpdateAsync(Guid id, AccountsPayableCreateDto dto)
        {
            var entity = await _context.AccountsPayables.FindAsync(id);
            if (entity == null) return "Record not found.";

            entity.PurchaseOrderId = dto.PurchaseOrderId;
            entity.AmountOwed = dto.AmountOwed;
            entity.DueDate = dto.DueDate;
            entity.Remarks = dto.Remarks;
            entity.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return "Accounts payable record updated successfully.";
        }

        public async Task<string> DeleteAsync(Guid id)
        {
            var entity = await _context.AccountsPayables.FindAsync(id);
            if (entity == null) return "Record not found.";

            _context.AccountsPayables.Remove(entity);
            await _context.SaveChangesAsync();

            return "Accounts payable record deleted successfully.";
        }
    }
}
