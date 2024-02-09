using Application.Expenses.Commands.CreateExpense;
using Application.Expenses.Commands.DeleteExpenseById;
using Application.Expenses.Commands.UpdateExpenses;
using Application.Expenses.Queries.GetAllExpenses;
using Application.Expenses.Queries.GetExpenseById;
using Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpensesController : ControllerBase
    {
        private readonly IMediator _mediator;
        IHttpContextAccessor _httpContextAccessor;

        public ExpensesController(IMediator mediator, IHttpContextAccessor httpContextAccessor)
        {
            _mediator = mediator;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("all")]
        public async Task<List<ExpenseDto>> GetExpenseByUser()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var query = new GetAllExpensesQuery(Guid.Parse(userId));
            return await _mediator.Send(query).ConfigureAwait(false);
        }


        [HttpGet]
        public async Task<ExpenseDto> GetExpenseById([FromQuery] GetExpenseByIdQuery query)
        {            
            return await _mediator.Send(query).ConfigureAwait(false);
        }

        [HttpDelete]
        public async Task<int> DeleteExpenseById([FromQuery] DeleteExpenseByIdCommand query)
        {
            return await _mediator.Send<int>(query).ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<int> CreateNewExpense(CreateExpenseCommand command)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            command.UserId = Guid.Parse(userId);
            return await _mediator.Send(command).ConfigureAwait(false);
        }


        [HttpPut]
        public async Task<int> UpdateExistingExpense(UpdateExpenseCommand command)
        {
            return await _mediator.Send(command).ConfigureAwait(false);
        }
    }
}
