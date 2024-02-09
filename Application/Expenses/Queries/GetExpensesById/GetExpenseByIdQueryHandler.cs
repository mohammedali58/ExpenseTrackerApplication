using Domain.Dtos;
using Infrastructure.Interfaces;
using MediatR;

namespace Application.Expenses.Queries.GetExpenseById
{
    public class GetExpenseByIdQueryHandler : IRequestHandler<GetExpenseByIdQuery, ExpenseDto>
    {
        private readonly IReadExpenseRepository _expenseRepository;

        public GetExpenseByIdQueryHandler(IReadExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<ExpenseDto> Handle(GetExpenseByIdQuery request, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(request, nameof(request));

            ExpenseDto expenseDto = await _expenseRepository.GetExpenseById(request.Id, cancellationToken);

            return expenseDto;
        }
    }
}
