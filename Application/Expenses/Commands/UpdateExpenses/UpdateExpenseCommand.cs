using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Expenses.Commands.UpdateExpenses
{
    public class UpdateExpenseCommand : IRequest<int>
    {
        public int ExpenseId { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId  { get; set; }
    }
}
