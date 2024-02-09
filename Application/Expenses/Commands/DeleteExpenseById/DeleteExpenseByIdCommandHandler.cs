using Infrastructure.Interfaces;
using MediatR;

namespace Application.Expenses.Commands.DeleteExpenseById
{
    public class DeleteExpenseByIdCommandHandler : IRequestHandler<DeleteExpenseByIdCommand, int>
    {
        private readonly IWriteExpenseRepository _expenseRepository;

        public DeleteExpenseByIdCommandHandler(IWriteExpenseRepository contactRepository)
        {
            _expenseRepository = contactRepository;
        }

        public async Task<int> Handle(DeleteExpenseByIdCommand request, CancellationToken cancellationToken)
        {
            return await _expenseRepository.DeleteExpenseById(request.Id, cancellationToken);

        }
    }
}
