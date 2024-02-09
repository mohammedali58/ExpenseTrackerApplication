using Domain.Dtos;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Expenses.Queries.GetAllExpenses
{
    public class GetAllExpensesQueryHandler : IRequestHandler<GetAllExpensesQuery, List<ExpenseDto>>
    {

        public GetAllExpensesQueryHandler(IReadExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        private readonly IReadExpenseRepository _expenseRepository;
        public async Task<List<ExpenseDto>> Handle(GetAllExpensesQuery request, CancellationToken cancellationToken)
        {
            return await _expenseRepository.GetAllExpense(request.UserId, cancellationToken);
        }
    }
}
