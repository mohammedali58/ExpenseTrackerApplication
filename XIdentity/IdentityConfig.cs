using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApiEndpoints.CustomIdentity;

public static class IdentityConfigs
{
    public static IdentityBuilder AddCustomIdentityApiEndpoints<TUser>(this IServiceCollection services, Action<IdentityOptions> configure) where TUser : class, new()
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configure);        
        services
            .AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);

        return services.AddIdentityCore<TUser>(configure)
            .AddApiEndpoints();
    }
}