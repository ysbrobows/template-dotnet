using Infrastructure.Data;
using SharedKernel.Infrastructure.UnitOfWork;
using WebApi.Startups.Infrastructure.Persistence.Settings;

namespace WebApi.Startups.Infrastructure.Persistence;

internal static class PersistenceStartup
{
    public static void AddMyPersistence(
        this IServiceCollection service,
        IHostEnvironment environment)
    {
        service.AddSingleton<ConnectionStrings>();
        service.AddUnitOfWork<ApplicationUnitOfWorkFactory>();
        service.AddMyPostgreSql(environment);
        // service.AddMyAnotherDbStartup(configuration, environment);
    }
}
