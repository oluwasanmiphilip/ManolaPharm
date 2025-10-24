using ManolaPharm.Application.DTOs.Finance;
using ManolaPharm.Domain.Entities.Finance;
using ManolaPharm.Persistence;
using ManolaPharm.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManolaPharm.Application.Services.Finance
{
    public class BankReconciliationService
    {
        private readonly ApplicationDbContext _context;

        public BankReconciliationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BankReconciliationDto>> GetAllAsync()
        {
            var entities = await _context.BankReconciliations.ToListAsync();
            var result = new List<BankReconciliationDto>();

            foreach (var item in entities)
            {
                result.Add(new BankReconciliationDto
                {
                    Id = item.Id,
                    AccountNumber = item.AccountNumber,
                    BankName = item.BankName,
                    StatementDate = item.StatementDate,
                    BankStatementBalance = item.BankStatementBalance,
                    BookBalance = item.BookBalance,
                    OutstandingDeposits = item.OutstandingDeposits,
                    OutstandingPayments = item.OutstandingPayments,
                    Remarks = item.Remarks,
                    IsReconciled = item.IsReconciled,
                    IsActive = item.IsActive,
                    CreatedAt = item.CreatedAt
                });
            }

            return result;
        }

        public async Task<BankReconciliationDto> GetByIdAsync(Guid id)
        {
            var item = await _context.BankReconciliations.FindAsync(id);
            if (item == null) return null;

            return new BankReconciliationDto
            {
                Id = item.Id,
                AccountNumber = item.AccountNumber,
                BankName = item.BankName,
                StatementDate = item.StatementDate,
                BankStatementBalance = item.BankStatementBalance,
                BookBalance = item.BookBalance,
                OutstandingDeposits = item.OutstandingDeposits,
                OutstandingPayments = item.OutstandingPayments,
                Remarks = item.Remarks,
                IsReconciled = item.IsReconciled,
                IsActive = item.IsActive,
                CreatedAt = item.CreatedAt
            };
        }

        public async Task CreateAsync(CreateBankReconciliationDto dto)
        {
            var entity = new BankReconciliation
            {
                Id = Guid.NewGuid(),
                AccountNumber = dto.AccountNumber,
                BankName = dto.BankName,
                StatementDate = dto.StatementDate,
                BankStatementBalance = dto.BankStatementBalance,
                BookBalance = dto.BookBalance,
                OutstandingDeposits = dto.OutstandingDeposits,
                OutstandingPayments = dto.OutstandingPayments,
                Remarks = dto.Remarks
            };

            await _context.BankReconciliations.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateBankReconciliationDto dto)
        {
            var entity = await _context.BankReconciliations.FindAsync(dto.Id);
            if (entity == null) return;

            entity.BankStatementBalance = dto.BankStatementBalance;
            entity.BookBalance = dto.BookBalance;
            entity.OutstandingDeposits = dto.OutstandingDeposits;
            entity.OutstandingPayments = dto.OutstandingPayments;
            entity.Remarks = dto.Remarks;
            entity.IsReconciled = dto.IsReconciled;
            entity.IsActive = dto.IsActive;

            _context.BankReconciliations.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.BankReconciliations.FindAsync(id);
            if (entity == null) return;

            _context.BankReconciliations.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
