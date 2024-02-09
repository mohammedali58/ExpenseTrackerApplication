using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Expense : BaseEntity
    {
        public Guid UserId { get; set; }
        public decimal Amount { get; set; }

        public Category Category { get; set; }

        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
