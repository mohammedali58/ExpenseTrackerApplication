using Domain.Dtos;
using MediatR;

namespace Application.Expenses.Queries.GetExpenseById
{
    public class GetExpenseByIdQuery : IRequest<ExpenseDto>
    {
        public int Id { get; set; } 
    }
}
