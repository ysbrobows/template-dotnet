using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Logging;
using SharedKernel.Infrastructure.UnitOfWork;

namespace Infrastructure.Data;

[ExcludeFromCodeCoverage]
public class ApplicationUnitOfWorkFactory : UnitOfWorkScopeFactory
{

    private readonly ApplicationContext _context;
    private readonly ILogger<UnitOfWorkScope> _logger;

    public ApplicationUnitOfWorkFactory(
        ApplicationContext context,
        ILogger<UnitOfWorkScope> logger)
        : base(logger)
    {
        _context = context;
        _logger = logger;
    }

    protected override IUnitOfWorkScope CreateNew() =>
        new UnitOfWorkScope(_context, _logger);
}
