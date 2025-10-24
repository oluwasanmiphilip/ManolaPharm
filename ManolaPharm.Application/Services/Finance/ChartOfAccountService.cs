using ManolaPharm.Application.DTOs.Finance;
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
    public class ChartOfAccountService
    {
        private readonly ApplicationDbContext _context;

        public ChartOfAccountService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChartOfAccountDto>> GetAllAsync()
        {
            var accounts = await _context.ChartOfAccounts
                .AsNoTracking()
                .OrderBy(a => a.AccountCode)
                .ToListAsync();

            return accounts.Select(a => new ChartOfAccountDto
            {
                AccountCode = a.AccountCode,
                AccountName = a.AccountName,
                AccountType = a.AccountType,
                AccountCategory = a.AccountCategory,
                IsActive = a.IsActive,
                Description = a.Description,
                CreatedAt = a.CreatedAt
            });
        }

        public async Task<ChartOfAccountDto?> GetByIdAsync(Guid id)
        {
            var account = await _context.ChartOfAccounts
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);

            if (account == null)
                return null;

            return new ChartOfAccountDto
            {
                AccountCode = account.AccountCode,
                AccountName = account.AccountName,
                AccountType = account.AccountType,
                AccountCategory = account.AccountCategory,
                IsActive = account.IsActive,
                Description = account.Description,
                CreatedAt = account.CreatedAt
            };
        }

        public async Task<bool> CreateAsync(ChartOfAccountCreateDto dto)
        {
            var exists = await _context.ChartOfAccounts
                .AnyAsync(a => a.AccountCode == dto.AccountCode);

            if (exists)
                return false;

            var account = new ChartOfAccount
            {
                Id = Guid.NewGuid(),
                AccountCode = dto.AccountCode,
                AccountName = dto.AccountName,
                AccountType = dto.AccountType,
                AccountCategory = dto.AccountCategory,
                Description = dto.Description,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            _context.ChartOfAccounts.Add(account);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Guid id, ChartOfAccountUpdateDto dto)
        {
            var account = await _context.ChartOfAccounts.FindAsync(id);
            if (account == null)
                return false;

            account.AccountName = dto.AccountName;
            account.AccountType = dto.AccountType;
            account.AccountCategory = dto.AccountCategory;
            account.Description = dto.Description;
            account.IsActive = dto.IsActive;
            account.UpdatedAt = DateTime.UtcNow;

            _context.ChartOfAccounts.Update(account);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var account = await _context.ChartOfAccounts.FindAsync(id);
            if (account == null)
                return false;

            _context.ChartOfAccounts.Remove(account);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
