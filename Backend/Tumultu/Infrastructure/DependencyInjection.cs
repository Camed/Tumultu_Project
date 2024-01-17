using Microsoft.Extensions.DependencyInjection;
using Tumultu.Application.Common.Interfaces;
using Tumultu.Application.Files;
using Tumultu.Infrastructure.DataProviders.Database.Dapper.Read;
using Tumultu.Infrastructure.DataProviders.Database.EFCore.Write;
using Tumultu.Infrastructure.DataProviders.Memory.Read;
using Tumultu.Infrastructure.DataProviders.Memory.Write;

namespace Tumultu.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        //In memory
        
        //Generic write repo
        services.AddSingleton(typeof(IWriteRepository<,>), typeof(InMemoryWriteRepository<,>));
        
        //Specific read repos
        services.AddSingleton<IFilesReadOnlyRepository, InMemoryFilesReadRepository>();
        
        
        // //EF Core for writes, Dapper for reads
        //
        // //Generic write repo
        // services.AddSingleton(typeof(IWriteRepository<,>), typeof(EfCoreWriteRepository<,>));
        //
        // //Specific read repos
        // services.AddSingleton<IFilesReadRepository, DapperFilesReadRepository>();
    }
}