using System;
using System.Threading.Tasks;

namespace SharedKernel.Infrastructure.UnitOfWork;

public interface IUnitOfWorkScope : IDisposable
{
    bool Committed { get; }

    Task CommitAsync(bool force = false);
}
