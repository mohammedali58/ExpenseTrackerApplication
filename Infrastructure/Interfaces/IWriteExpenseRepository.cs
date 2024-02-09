using Domain.Dtos;
using Domain.Entities;


namespace Infrastructure.Interfaces
{
    public interface IWriteExpenseRepository
    {
        public Task<int> CreateExpense(Guid userId, decimal amount,  int categoryId, DateTime date, string description, CancellationToken cToken);

        public Task<int> UpdateExpense(int expenseId, decimal amount, int categoryId, CancellationToken cToken);

        public Task<int> DeleteExpenseById(int id, CancellationToken cToken);

    }
}
