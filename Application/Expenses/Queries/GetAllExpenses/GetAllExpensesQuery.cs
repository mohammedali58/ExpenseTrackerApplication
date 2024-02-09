using Domain.Dtos;
using MediatR;

namespace Application.Expenses.Queries.GetAllExpenses
{
    public record GetAllExpensesQuery(Guid UserId) : IRequest<List<ExpenseDto>>
    {
    }
}
