using ManolaPharm.Application.DTOs.FinanceDtos;
using ManolaPharm.Domain.Entities.Finance;
using ManolaPharm.Persistence;
using ManolaPharm.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ManolaPharm.Application.Services
{
    public class ExpenseService
    {
        private readonly ApplicationDbContext _context;

        public ExpenseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ExpenseDto>> GetAllAsync()
        {
            var expenses = await _context.Set<Expense>().ToListAsync();
            return expenses.Select(e => new ExpenseDto
            {
                Description = e.Description,
                Amount = e.Amount,
                ExpenseDate = e.ExpenseDate,
                PaidTo = e.PaidTo,
                Remarks = e.Remarks,
                IsActive = e.IsActive,
                CreatedAt = e.CreatedAt,
                UpdatedAt = e.UpdatedAt
            });
        }

        public async Task<bool> CreateAsync(ExpenseCreateDto dto)
        {
            var expense = new Expense
            {
                Id = Guid.NewGuid(),
                Description = dto.Description,
                Amount = dto.Amount,
                ExpenseDate = dto.ExpenseDate,
                PaidTo = dto.PaidTo,
                Remarks = dto.Remarks,
                CreatedAt = DateTime.UtcNow
            };

            await _context.Set<Expense>().AddAsync(expense);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(Guid id, ExpenseUpdateDto dto)
        {
            var expense = await _context.Set<Expense>().FindAsync(id);
            if (expense == null) return false;

            expense.Description = dto.Description;
            expense.Amount = dto.Amount;
            expense.ExpenseDate = dto.ExpenseDate;
            expense.PaidTo = dto.PaidTo;
            expense.Remarks = dto.Remarks;
            expense.IsActive = dto.IsActive;
            expense.UpdatedAt = DateTime.UtcNow;

            _context.Set<Expense>().Update(expense);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var expense = await _context.Set<Expense>().FindAsync(id);
            if (expense == null) return false;

            _context.Set<Expense>().Remove(expense);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
