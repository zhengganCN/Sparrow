using Microsoft.Extensions.Logging;

namespace Sparrow.Database.SqlSugar
{
    internal class StaticValues
    {
        internal static readonly ILogger<DbContext> Logger = new LoggerFactory().CreateLogger<DbContext>();
    }
}
