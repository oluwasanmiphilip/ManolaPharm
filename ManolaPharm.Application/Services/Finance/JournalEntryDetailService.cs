using ManolaPharm.Application.DTOs.Finance;
using ManolaPharm.Domain.Entities.Finance;
using ManolaPharm.Persistence;
using ManolaPharm.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManolaPharm.Application.Services.Finance
{
    public class JournalEntryDetailService
    {
        private readonly ApplicationDbContext _context;

        public JournalEntryDetailService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<JournalEntryDetail>> GetAllAsync()
        {
            return await _context.JournalEntryDetails
                .Include(d => d.JournalEntry)
                .ToListAsync();
        }

        public async Task<JournalEntryDetail> GetByIdAsync(int id)
        {
            return await _context.JournalEntryDetails
                .Include(d => d.JournalEntry)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<JournalEntryDetail> CreateAsync(JournalEntryDetailCreateDto dto)
        {
            var detail = new JournalEntryDetail
            {
                JournalEntryId = dto.JournalEntryId,
                AccountName = dto.AccountName,
                AccountCode = dto.AccountCode,
                Debit = dto.Debit,
                Credit = dto.Credit,
                Description = dto.Description,
                CreatedAt = System.DateTime.UtcNow,
                IsActive = true
            };

            _context.JournalEntryDetails.Add(detail);
            await _context.SaveChangesAsync();
            return detail;
        }

        public async Task<bool> UpdateAsync(int id, JournalEntryDetailUpdateDto dto)
        {
            var detail = await _context.JournalEntryDetails.FindAsync(id);
            if (detail == null) return false;

            detail.AccountName = dto.AccountName;
            detail.AccountCode = dto.AccountCode;
            detail.Debit = dto.Debit;
            detail.Credit = dto.Credit;
            detail.Description = dto.Description;
            detail.IsActive = dto.IsActive;

            _context.JournalEntryDetails.Update(detail);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var detail = await _context.JournalEntryDetails.FindAsync(id);
            if (detail == null) return false;

            _context.JournalEntryDetails.Remove(detail);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
