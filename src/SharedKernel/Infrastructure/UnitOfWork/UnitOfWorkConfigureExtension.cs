using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;

namespace SharedKernel.Infrastructure.UnitOfWork;

[ExcludeFromCodeCoverage]
public static class UnitOfWorkConfigureExtension
{
    public static void AddUnitOfWork<TFactory>(this IServiceCollection services)
        where TFactory : UnitOfWorkScopeFactory
    {
        services.AddUnitOfWork<IUnitOfWorkScopeFactory, TFactory>();
    }

    public static void AddUnitOfWork<TIFactory, TFactory>(this IServiceCollection services)
        where TIFactory : class, IUnitOfWorkScopeFactory
        where TFactory : UnitOfWorkScopeFactory, TIFactory
    {
        services.AddScoped<TIFactory, TFactory>();
    }
}
