using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApiEndpoints.CustomIdentity;

public static class Startup
{
    public static IServiceCollection ConfigureAuth<TUser>(this IServiceCollection services) where TUser : class, new()
    {
        services.AddDbContext<AppDbContext>(dbContextOptionsBuilder => dbContextOptionsBuilder.UseSqlite("Data Source=myapp.db"));
        services.AddAuthorizationBuilder();
        services
            .AddCustomIdentityApiEndpoints<AppUser>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 4;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
            }).AddEntityFrameworkStores<AppDbContext>();

        return services;
    }
}