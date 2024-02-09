using Domain.Entities;
using MediatR;

namespace Application.Expenses.Commands.CreateExpense
{
    public class CreateExpenseCommand : IRequest<int>
    {
        
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }

        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;

    }
}
