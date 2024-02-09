using Domain.Dtos;
using Domain.Entities;


namespace Infrastructure.Interfaces
{
    public interface IReadExpenseRepository
    {
        public Task<List<ExpenseDto>> GetAllExpense(Guid userId, CancellationToken cToken);
        public Task<ExpenseDto> GetExpenseById(int id, CancellationToken cToken);
    }
}
