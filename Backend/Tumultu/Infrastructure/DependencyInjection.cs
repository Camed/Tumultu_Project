using Microsoft.Extensions.DependencyInjection;
using Tumultu.Application.Files;
using Tumultu.Infrastructure.DataProviders.Database.Dapper.Files;
using Tumultu.Infrastructure.DataProviders.Database.EFCore.Files;
using Tumultu.Infrastructure.DataProviders.Memory.Files;

namespace Tumultu.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        //In memory
        services.AddSingleton<IFileReadOnlyRepository, InMemoryFileReadOnlyRepository>();
        services.AddSingleton<IFileRepository, InMemoryFileRepository>();
       
        
        // services.AddSingleton<IFileReadOnlyRepository, DapperFileReadRepository>();
        // services.AddSingleton<IFileRepository, EfCoreFileRepository>();
    }
}