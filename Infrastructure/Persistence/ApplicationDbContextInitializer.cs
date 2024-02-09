using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContextInitializer
    {
        private readonly ILogger<ApplicationDbContextInitializer> _logger;
        private readonly ApplicationDbContext _context;
        //private readonly UserManager<IdentityUser> _userManager;

        public ApplicationDbContextInitializer(ILogger<ApplicationDbContextInitializer> logger,
            ApplicationDbContext context)//, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            //_userManager = userManager;

        }

        public async Task InitializeAsync()
        {
            try
            {
                if (_context.Database.IsSqlite())
                {
                    await _context.Database.MigrateAsync();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initializing the database.");
                throw;
            }
        }

        public async Task SeedDataAsync()
        {
            try
            {
                List<Category>? categories = default;
    


                if (!_context.Categories.Any())
                {
                    var categoriesText = File.ReadAllText("../Infrastructure/SeedingData/Categories.json");
                    categories = JsonSerializer.Deserialize<List<Category>>(categoriesText);
                    if (categories is null)
                    {
                        throw new Exception("languages data seeding is null");
                    }

                    _context.AddRange(categories);
                    await _context.SaveChangesAsync();
                }

           
                if (_context.ChangeTracker.HasChanges())
                {
                    await _context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding data.");
            }
        }
    }
}
