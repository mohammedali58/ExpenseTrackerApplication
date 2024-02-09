using Application.Expenses.Commands.CreateExpense;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Contacts.Commands.CreateContact
{
    public class CreateExpenseCommandHandler : IRequestHandler<CreateExpenseCommand, int>
    {
        private readonly IWriteExpenseRepository _expenseRepository;

        public CreateExpenseCommandHandler(IWriteExpenseRepository contactRepository)
        {
            _expenseRepository = contactRepository;

        }

        public async Task<int> Handle(CreateExpenseCommand request, CancellationToken cancellationToken)
        {
            return await _expenseRepository.CreateExpense(request.UserId, request.Amount, request.CategoryId, request.Date, request.Description, cancellationToken);
        }
    }
}
