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
    public class CashBookService
    {
        private readonly ApplicationDbContext _context;

        public CashBookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CashBookReadDto>> GetAllAsync()
        {
            return await _context.CashBooks
                .Where(x => x.IsActive)
                .Select(x => new CashBookReadDto
                {
                    TransactionType = x.TransactionType,
                    ReferenceNo = x.ReferenceNo,
                    Amount = x.Amount,
                    Description = x.Description,
                    TransactionDate = x.TransactionDate,
                    ReceivedBy = x.ReceivedBy,
                    ApprovedBy = x.ApprovedBy,
                    PaymentMethod = x.PaymentMethod,
                    IsReconciled = x.IsReconciled,
                    Remarks = x.Remarks,
                    CreatedAt = x.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<CashBookReadDto?> GetByIdAsync(Guid id)
        {
            var cashBook = await _context.CashBooks.FindAsync(id);
            if (cashBook == null) return null;

            return new CashBookReadDto
            {
                TransactionType = cashBook.TransactionType,
                ReferenceNo = cashBook.ReferenceNo,
                Amount = cashBook.Amount,
                Description = cashBook.Description,
                TransactionDate = cashBook.TransactionDate,
                ReceivedBy = cashBook.ReceivedBy,
                ApprovedBy = cashBook.ApprovedBy,
                PaymentMethod = cashBook.PaymentMethod,
                IsReconciled = cashBook.IsReconciled,
                Remarks = cashBook.Remarks,
                CreatedAt = cashBook.CreatedAt
            };
        }

        public async Task<bool> CreateAsync(CashBookCreateDto dto)
        {
            var entity = new CashBook
            {
                Id = Guid.NewGuid(),
                TransactionType = dto.TransactionType,
                ReferenceNo = dto.ReferenceNo,
                Amount = dto.Amount,
                Description = dto.Description,
                TransactionDate = dto.TransactionDate,
                ReceivedBy = dto.ReceivedBy,
                ApprovedBy = dto.ApprovedBy,
                PaymentMethod = dto.PaymentMethod,
                Remarks = dto.Remarks
            };

            _context.CashBooks.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Guid id, CashBookUpdateDto dto)
        {
            var entity = await _context.CashBooks.FindAsync(id);
            if (entity == null) return false;

            entity.Description = dto.Description;
            entity.Amount = dto.Amount;
            entity.ApprovedBy = dto.ApprovedBy;
            entity.Remarks = dto.Remarks;
            entity.IsReconciled = dto.IsReconciled;
            entity.UpdatedAt = DateTime.UtcNow;

            _context.CashBooks.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _context.CashBooks.FindAsync(id);
            if (entity == null) return false;

            entity.IsActive = false;
            _context.CashBooks.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
