using ManolaPharm.Application.DTOs.Finance.TrialBalanceDtos;
using ManolaPharm.Domain.Entities.Finance;
using ManolaPharm.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManolaPharm.Application.Services.Finance
{
    public class TrialBalanceService
    {
        private readonly ApplicationDbContext _context;

        public TrialBalanceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TrialBalanceResponseDto>> GetAllAsync()
        {
            var trialBalances = await _context.TrialBalances
                .AsNoTracking()
                .ToListAsync();

            return trialBalances.Select(tb => new TrialBalanceResponseDto
            {
                AccountName = tb.AccountName,
                AccountCode = tb.AccountCode,
                Debit = tb.Debit,
                Credit = tb.Credit,
                PeriodStart = tb.PeriodStart,
                PeriodEnd = tb.PeriodEnd,
                IsActive = tb.IsActive
            });
        }

        public async Task<TrialBalanceResponseDto?> GetByIdAsync(Guid id)
        {
            var tb = await _context.TrialBalances.FindAsync(id);
            if (tb == null) return null;

            return new TrialBalanceResponseDto
            {
                AccountName = tb.AccountName,
                AccountCode = tb.AccountCode,
                Debit = tb.Debit,
                Credit = tb.Credit,
                PeriodStart = tb.PeriodStart,
                PeriodEnd = tb.PeriodEnd,
                IsActive = tb.IsActive
            };
        }

        public async Task<bool> CreateAsync(TrialBalanceCreateDto dto)
        {
            var tb = new TrialBalance
            {
                Id = Guid.NewGuid(),
                AccountName = dto.AccountName,
                AccountCode = dto.AccountCode,
                Debit = dto.Debit,
                Credit = dto.Credit,
                PeriodStart = dto.PeriodStart,
                PeriodEnd = dto.PeriodEnd
            };

            await _context.TrialBalances.AddAsync(tb);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Guid id, TrialBalanceUpdateDto dto)
        {
            var tb = await _context.TrialBalances.FindAsync(id);
            if (tb == null) return false;

            tb.Debit = dto.Debit;
            tb.Credit = dto.Credit;
            tb.PeriodEnd = dto.PeriodEnd;
            tb.IsActive = dto.IsActive;
            tb.UpdatedAt = DateTime.UtcNow;

            _context.TrialBalances.Update(tb);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var tb = await _context.TrialBalances.FindAsync(id);
            if (tb == null) return false;

            _context.TrialBalances.Remove(tb);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
