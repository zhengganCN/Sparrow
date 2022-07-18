using Microsoft.Extensions.Logging;

namespace Sparrow.Logger
{
    internal class LoggerStaticValues
    {
        internal static ILogger<Logger> Logger { get; set; }
    }
}
