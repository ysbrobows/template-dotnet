using System.ComponentModel.DataAnnotations;
using WebApi.Validations;

namespace WebApi.Startups.Infrastructure.Logging;

internal sealed record LogglySettings
{
    [Required]
    public bool? WriteToLoggly { get; init; }

    [RequiredIf(nameof(WriteToLoggly), true)]
    public string CustomerToken { get; init; }
}
