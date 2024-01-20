using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tumultu.Application.AnalysisResults;
using Tumultu.Application.Behaviours;
using Tumultu.Application.Files;
using Tumultu.Application.FileVariants;
using Tumultu.Application.Users;
using Tumultu.Infrastructure.DataProviders.Dapper;
using Tumultu.Infrastructure.DataProviders.Dapper.AnalysisResults;
using Tumultu.Infrastructure.DataProviders.Dapper.Behaviours;
using Tumultu.Infrastructure.DataProviders.Dapper.Files;
using Tumultu.Infrastructure.DataProviders.Dapper.FileVariants;
using Tumultu.Infrastructure.DataProviders.Dapper.Users;
using Tumultu.Infrastructure.DataProviders.EFCore;
using Tumultu.Infrastructure.DataProviders.EFCore.AnalysisResults;
using Tumultu.Infrastructure.DataProviders.EFCore.Behaviours;
using Tumultu.Infrastructure.DataProviders.EFCore.Files;
using Tumultu.Infrastructure.DataProviders.EFCore.FileVariants;
using Tumultu.Infrastructure.DataProviders.EFCore.Users;

namespace Tumultu.Infrastructure;

public static class DependencyInjection
{
    // docker run --name postgres-dev -e POSTGRES_PASSWORD=tumultu -e POSTGRES_USER=tumultu -e POSTGRES_DB=tumultu-dev -d -p 5432:5432 postgres:16
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        //Dapper
        services.AddSingleton<IDbConnectionFactory, PostgreSqlDbConnectionFactory>();

        services.AddSingleton<IAnalysisResultReadOnlyRepository, AnalysisResultReadOnlyRepository>();
        services.AddSingleton<IBehaviourReadOnlyRepository, BehaviourReadOnlyRepository>();
        services.AddSingleton<IFileReadOnlyRepository, FileReadRepository>();
        services.AddSingleton<IFileVariantReadOnlyRepository, FileVariantReadOnlyRepository>();
        services.AddSingleton<IUserReadOnlyRepository, UserReadOnlyRepository>();

        //EF Core
        services.AddDbContext<EfCoreDbContext>(
            options => options
                .UseNpgsql(configuration.GetConnectionString("SqlConnection")));

        services.AddScoped<IAnalysisResultRepository, AnalysisResultRepository>();
        services.AddScoped<IBehaviourRepository, BehaviourRepository>();
        services.AddScoped<IFileRepository, FileRepository>();
        services.AddScoped<IFileVariantRepository, FileVariantRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}