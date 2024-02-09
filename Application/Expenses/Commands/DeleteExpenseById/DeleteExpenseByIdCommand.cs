using MediatR;
namespace Application.Expenses.Commands.DeleteExpenseById
{
    public class DeleteExpenseByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
