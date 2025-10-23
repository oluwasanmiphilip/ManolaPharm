using ManolaPharm.Application.DTOs.FinanceDtos;
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
    public class JournalEntryService
    {
        private readonly ApplicationDbContext _context;

        public JournalEntryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<JournalEntryDto>> GetAllAsync()
        {
            var entries = await _context.JournalEntries
                .AsNoTracking()
                .OrderByDescending(j => j.EntryDate)
                .ToListAsync();

            return entries.Select(j => new JournalEntryDto
            {
                EntryNumber = j.EntryNumber,
                EntryDate = j.EntryDate,
                AccountName = j.AccountName,
                AccountCode = j.AccountCode,
                Debit = j.Debit,
                Credit = j.Credit,
                Description = j.Description,
                Status = j.Status,
                IsActive = j.IsActive,
                CreatedAt = j.CreatedAt,
                UpdatedAt = j.UpdatedAt
            });
        }

        public async Task<JournalEntryDto> GetByIdAsync(Guid id)
        {
            var j = await _context.JournalEntries.FindAsync(id);
            if (j == null) return null;

            return new JournalEntryDto
            {
                EntryNumber = j.EntryNumber,
                EntryDate = j.EntryDate,
                AccountName = j.AccountName,
                AccountCode = j.AccountCode,
                Debit = j.Debit,
                Credit = j.Credit,
                Description = j.Description,
                Status = j.Status,
                IsActive = j.IsActive,
                CreatedAt = j.CreatedAt,
                UpdatedAt = j.UpdatedAt
            };
        }

        public async Task<bool> CreateAsync(JournalEntryCreateDto dto)
        {
            var entry = new JournalEntry
            {
                Id = Guid.NewGuid(),
                EntryNumber = dto.EntryNumber,
                EntryDate = dto.EntryDate,
                AccountName = dto.AccountName,
                AccountCode = dto.AccountCode,
                Debit = dto.Debit,
                Credit = dto.Credit,
                Description = dto.Description,
                Status = "Pending",
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            await _context.JournalEntries.AddAsync(entry);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Guid id, JournalEntryUpdateDto dto)
        {
            var entry = await _context.JournalEntries.FindAsync(dto.Id);
            if (entry == null) return false;

            entry.AccountName = dto.AccountName ?? entry.AccountName;
            entry.AccountCode = dto.AccountCode ?? entry.AccountCode;
            entry.Debit = dto.Debit ?? entry.Debit;
            entry.Credit = dto.Credit ?? entry.Credit;
            entry.Description = dto.Description ?? entry.Description;
            entry.Status = dto.Status ?? entry.Status;
            entry.IsActive = dto.IsActive ?? entry.IsActive;
            entry.UpdatedAt = DateTime.UtcNow;

            _context.JournalEntries.Update(entry);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entry = await _context.JournalEntries.FindAsync(id);
            if (entry == null) return false;

            _context.JournalEntries.Remove(entry);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
