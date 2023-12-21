using Microsoft.Extensions.DependencyInjection;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Infrastructure.Data.InMemory;

namespace Tumultu.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IReadOnlyRepository<,>), typeof(InMemoryRepository<,>));
        services.AddSingleton(typeof(IRepository<,>), typeof(InMemoryRepository<,>));
        return services;
    }
}