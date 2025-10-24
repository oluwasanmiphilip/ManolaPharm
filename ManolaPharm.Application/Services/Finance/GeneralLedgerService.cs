using ManolaPharm.Application.DTOs.FinanceDtos;
using ManolaPharm.Domain.Entities.Finance;
using ManolaPharm.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManolaPharm.Application.Services.Finance
{
    public class GeneralLedgerService
    {
        private readonly ApplicationDbContext _context;

        public GeneralLedgerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GeneralLedgerReadDto>> GetAllAsync()
        {
            return await _context.GeneralLedgers
                .Where(g => g.IsActive)
                .Select(g => new GeneralLedgerReadDto
                {
                    AccountName = g.AccountName,
                    AccountCode = g.AccountCode,
                    Debit = g.Debit,
                    Credit = g.Credit,
                    Balance = g.Balance,
                    Description = g.Description,
                    Status = g.Status,
                    CreatedAt = g.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<GeneralLedgerReadDto?> GetByIdAsync(Guid id)
        {
            var ledger = await _context.GeneralLedgers.FindAsync(id);
            if (ledger == null) return null;

            return new GeneralLedgerReadDto
            {
                AccountName = ledger.AccountName,
                AccountCode = ledger.AccountCode,
                Debit = ledger.Debit,
                Credit = ledger.Credit,
                Balance = ledger.Balance,
                Description = ledger.Description,
                Status = ledger.Status,
                CreatedAt = ledger.CreatedAt
            };
        }

        public async Task<bool> CreateAsync(GeneralLedgerCreateDto dto)
        {
            var ledger = new GeneralLedger
            {
                Id = Guid.NewGuid(),
                AccountName = dto.AccountName,
                AccountCode = dto.AccountCode,
                Debit = dto.Debit,
                Credit = dto.Credit,
                Balance = dto.Balance,
                Description = dto.Description
            };

            _context.GeneralLedgers.Add(ledger);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(GeneralLedgerUpdateDto dto)
        {
            var ledger = await _context.GeneralLedgers.FindAsync(dto.Id);
            if (ledger == null) return false;

            ledger.AccountName = dto.AccountName;
            ledger.AccountCode = dto.AccountCode;
            ledger.Debit = dto.Debit;
            ledger.Credit = dto.Credit;
            ledger.Balance = dto.Balance;
            ledger.Description = dto.Description;
            ledger.Status = dto.Status;
            ledger.UpdatedAt = DateTime.UtcNow;

            _context.GeneralLedgers.Update(ledger);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var ledger = await _context.GeneralLedgers.FindAsync(id);
            if (ledger == null) return false;

            ledger.IsActive = false;
            ledger.UpdatedAt = DateTime.UtcNow;

            _context.GeneralLedgers.Update(ledger);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
