using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tumultu.Infrastructure.Database;

namespace Tumultu.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);

        return services;
    }
}