using Microsoft.Extensions.DependencyInjection;
using Tumultu.Application.Files;
using Tumultu.Application.FileVariants;
using Tumultu.Infrastructure.DataProviders.Memory.Read;
using Tumultu.Infrastructure.DataProviders.Memory.Write;

namespace Tumultu.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        //In memory
        services.AddSingleton<IFilesReadRepository, InMemoryFilesReadRepository>();
        services.AddSingleton<IFilesWriteRepository, InMemoryFilesWriteRepository>();
        services.AddSingleton<IFileVariantsWriteRepository, InMemoryFileVariantsWriteRepository>();

        // // //EF Core for writes, Dapper for reads
        // services.AddSingleton<IFilesReadRepository, InMemoryFilesReadRepository>();
        // services.AddSingleton<IFilesWriteRepository, InMemoryFilesWriteRepository>();
        // services.AddSingleton<IFileVariantsWriteRepository, InMemoryFileVariantsWriteRepository>();
    }
}