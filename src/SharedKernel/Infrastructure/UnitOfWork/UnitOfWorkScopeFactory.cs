using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Logging;
using SharedKernel.Helpers;

namespace SharedKernel.Infrastructure.UnitOfWork;

[ExcludeFromCodeCoverage]
public abstract class UnitOfWorkScopeFactory : IUnitOfWorkScopeFactory
{
    private readonly ILogger<UnitOfWorkScope> _logger;
    private IUnitOfWorkScope _scope;

    public bool ScopeOpened => !_scope.IsDefault() && !_scope.Committed;

    protected UnitOfWorkScopeFactory(ILogger<UnitOfWorkScope> logger)
    {
        _logger = logger;
    }

    public IUnitOfWorkScope Get()
    {
        if (!ScopeOpened)
        {
            _logger.LogDebug("New UnitOfWork scope created");

            _scope = CreateNew();
        }
        else
        {
            _logger.LogDebug("UnitOfWork scope already created");
        }

        return _scope;
    }

    protected abstract IUnitOfWorkScope CreateNew();
}
