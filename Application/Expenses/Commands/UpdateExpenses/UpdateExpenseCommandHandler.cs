using Infrastructure.Interfaces;
using MediatR;

namespace Application.Expenses.Commands.UpdateExpenses
{
    public class UpdateExpenseCommandHandler : IRequestHandler<UpdateExpenseCommand, int>
    {
        private readonly IWriteExpenseRepository _expenseRepository;

        public UpdateExpenseCommandHandler(IWriteExpenseRepository contactRepository)
        {
            _expenseRepository = contactRepository;

        }

        public async Task<int> Handle(UpdateExpenseCommand request, CancellationToken cancellationToken)
        {
            return await _expenseRepository.UpdateExpense(request.ExpenseId, request.Amount, request.CategoryId, cancellationToken);
        }
    }
}
