using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tumultu.Application.AnalysisResults;
using Tumultu.Application.Behaviours;
using Tumultu.Application.Files;
using Tumultu.Application.FileVariants;
using Tumultu.Application.Users;
using Tumultu.Infrastructure.Database.Dapper;
using Tumultu.Infrastructure.Database.Dapper.Repositories.AnalysisResults;
using Tumultu.Infrastructure.Database.Dapper.Repositories.Behaviours;
using Tumultu.Infrastructure.Database.Dapper.Repositories.Files;
using Tumultu.Infrastructure.Database.Dapper.Repositories.FileVariants;
using Tumultu.Infrastructure.Database.Dapper.Repositories.Users;
using Tumultu.Infrastructure.Database.EFCore;
using Tumultu.Infrastructure.Database.EFCore.Repositories.AnalysisResults;
using Tumultu.Infrastructure.Database.EFCore.Repositories.Behaviours;
using Tumultu.Infrastructure.Database.EFCore.Repositories.Files;
using Tumultu.Infrastructure.Database.EFCore.Repositories.FileVariants;
using Tumultu.Infrastructure.Database.EFCore.Repositories.Users;

namespace Tumultu.Infrastructure.Database;

public static class DependencyInjection
{
    // docker run --name postgres-dev -e POSTGRES_PASSWORD=tumultu -e POSTGRES_USER=tumultu -e POSTGRES_DB=tumultu-dev -d -p 5432:5432 postgres:16
    internal static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
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
            options => 
                options.UseNpgsql(configuration.GetConnectionString("SqlConnection")));

        services.AddScoped<IAnalysisResultRepository, AnalysisResultRepository>();
        services.AddScoped<IBehaviourRepository, BehaviourRepository>();
        services.AddScoped<IFileRepository, FileRepository>();
        services.AddScoped<IFileVariantRepository, FileVariantRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}