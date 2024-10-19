using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.ErrorLogger.Options;
using Shared.ErrorLogger.Repository;
using Shared.ErrorLogger.Services;

namespace Shared.ErrorLogger.Extensions;

public static class ApplicationServiceExtension
{
    public static IServiceCollection RegisterErrorLogServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddServices(config);
        return services;
    }

    // Services
    private static void AddServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddSingleton<IDbLoggerService, DbLoggerService>();
        services.AddSingleton<IDbLoggerRepository, DbLoggerRepository>();
        services.Configure<DatabaseConfig>(config.GetSection("ErrorsLogging"));
    }
}