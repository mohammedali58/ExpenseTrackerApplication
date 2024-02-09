using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Common.Interfaces
{
    public interface IApplicationDbContext
    {

        DbSet<Expense> Expenses { get; }

        DbSet<Category> Categories { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
