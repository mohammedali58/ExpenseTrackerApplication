
namespace Domain.Entities
{
    public class Category : BaseEntity
    {
        public required string CategoryName { get; set; }

        public static implicit operator Category(Task<Category?> v)
        {
            throw new NotImplementedException();
        }
    }
}
