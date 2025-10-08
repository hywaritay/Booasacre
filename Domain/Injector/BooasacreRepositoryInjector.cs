using Booasacre.Domain.Infrastructure.Repository.Booasacre;

namespace Booasacre.Domain.Injector;

public static class BooasacreRepositoryInjector
{
    public static void RegisterDependenciesBooasacre(this IServiceCollection services)
    {
        services.AddScoped<IApiUserRepository, ApiUserRepository>();
        services.AddScoped<IApiPermissionRepository, ApiPermissionRepository>();
        services.AddScoped<IApiUserPermissionRepository, ApiUserPermissionRepository>();
        services.AddScoped<IOtpRepository, OtpRepository>();
        services.AddScoped<IAlertNotifRepository, AlertNotifRepository>();
    }
}