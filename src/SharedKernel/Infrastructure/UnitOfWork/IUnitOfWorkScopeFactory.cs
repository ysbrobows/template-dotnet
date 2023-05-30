namespace SharedKernel.Infrastructure.UnitOfWork;

public interface IUnitOfWorkScopeFactory
{
    bool ScopeOpened { get; }

    IUnitOfWorkScope Get();
}
