using Domain.Entities;

namespace Domain.Dtos
{
    public class ExpenseDto: BaseEntity
    {
        public required decimal Amount { get; set; }
        public required Category Category { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
