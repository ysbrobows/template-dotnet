using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace SharedKernel.Infrastructure.UnitOfWork;

[ExcludeFromCodeCoverage]
public sealed class UnitOfWorkScope : IUnitOfWorkScope
{
    private readonly DbContext _context;
    private readonly ILogger<UnitOfWorkScope> _logger;

    public UnitOfWorkScope(
        DbContext context,
        ILogger<UnitOfWorkScope> logger)
    {
        _context = context;
        _logger = logger;
    }

    public bool Committed { get; private set; }

    public async Task CommitAsync(bool force = false)
    {
        if (!Committed)
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while saving entities");

                throw;
            }

            Committed = true;

            _logger.LogDebug("UnitOfWork scope committed");
        }
        else
        {
            _logger.LogError("UnitOfWork scope already committed");
        }
    }

    #region Dispose

    private bool _disposed;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                if (!Committed)
                {
                    _logger.LogWarning("UnitOfWork scope disposed without commit");
                }

                // Free other state (managed objects).
            }

            // Free your own state (unmanaged objects).
            // Set large fields to null.
            _disposed = true;
        }
    }

    ~UnitOfWorkScope()
    {
        Dispose(false);
    }

    #endregion Dispose
}
