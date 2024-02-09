using AutoMapper;
using Domain.Common.Interfaces;
using Domain.Dtos;
using Domain.Exceptions;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;



namespace Infrastructure.Repositories
{
    public class ReadExpenseRepository : IReadExpenseRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly  IMapper _mapper;

        public ReadExpenseRepository(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<List<ExpenseDto>> GetAllExpense(Guid userId, CancellationToken cToken)
        {
            var expenses = await _context.Expenses
                .Where(e => e.UserId == userId)
                .Include(e => e.Category).Select(e => new ExpenseDto()
            {
                Id = e.Id,
                Amount = e.Amount,
                Date = e.Date,
                Description = e.Description,
                Category = e.Category
            }).ToListAsync();

            if (expenses is null)
            {
                throw new HttpException(StatusCodes.Status404NotFound, "courses not found");
            }
            

            return expenses;
        }

        public async Task<ExpenseDto> GetExpenseById(int id, CancellationToken cToken)
        {
            var expense = await _context.Expenses.Include(c => c.Category).FirstOrDefaultAsync(i=>i.Id == id);

            if (expense is null)
            {
                throw new HttpException(StatusCodes.Status404NotFound, "Expense not found");
            }
            ExpenseDto response = new()
            {
                Id = id,
                Amount = expense.Amount,
                Description = expense.Description,
                Category = expense.Category,
                Date = expense.Date,
            };

            return response;
        }

      
    }
}
