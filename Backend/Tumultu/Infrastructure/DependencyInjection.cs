using Microsoft.Extensions.DependencyInjection;
using Tumultu.Application.Files.Commands;
using Tumultu.Application.Files.Queries;
using Tumultu.Application.FileVariants.Commands;
using Tumultu.Infrastructure.DataProviders.Memory.Read;
using Tumultu.Infrastructure.DataProviders.Memory.Write;

namespace Tumultu.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IFilesReadOnlyRepository, InMemoryFilesReadOnlyRepository>();
        services.AddSingleton<IFilesRepository, InMemoryFilesRepository>();
        services.AddSingleton<IFileVariantsRepository, InMemoryFileVariantsRepository>();
    }
}