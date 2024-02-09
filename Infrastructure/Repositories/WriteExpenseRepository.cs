using AutoMapper;
using Domain.Common.Interfaces;
using Domain.Dtos;
using Domain.Entities;
using Domain.Exceptions;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.CodeDom;


namespace Infrastructure.Repositories
{
    public class WriteExpenseRepository : IWriteExpenseRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly  IMapper _mapper;

        public WriteExpenseRepository(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<int> CreateExpense(Guid userId, decimal amount, int categoryId, DateTime date, string description, CancellationToken cToken)
        {
            Category? category = await _context.Categories.FirstOrDefaultAsync(category => category.Id == categoryId).ConfigureAwait(false);

            if(category == null)
            {
                throw new HttpException(StatusCodes.Status404NotFound, "Category does not exist");
            }

            Expense expense = new() { 
                UserId = userId,
                Amount = amount,
                Category = category,
                Date = date,
                Description = description,
            };

            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync(cToken);
            return expense.Id;
        }

        public async Task<int> DeleteExpenseById(int id, CancellationToken cToken)
        {
            var expense = _context.Expenses.FirstOrDefault(x => x.Id == id);

            if (expense is null)
            {
                throw new HttpException(StatusCodes.Status404NotFound, "expense not found");
            }

            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync(cToken);
            return expense.Id;
        }

        public async Task<int> UpdateExpense(int expenseId, decimal amount, int categoryId, CancellationToken cToken)
        {
            var expense = await _context.Expenses.FirstOrDefaultAsync(x => x.Id == expenseId);
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);

            if (expense is null || category is null)
            {
                throw new HttpException(StatusCodes.Status404NotFound, "expense or category not found");
            }

            expense.Amount = amount;
            expense.Category = category;

            await _context.SaveChangesAsync(cToken);
            
            return expense.Id;
        }
    }
}
