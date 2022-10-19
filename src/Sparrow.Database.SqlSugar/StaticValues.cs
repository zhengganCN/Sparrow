using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Sparrow.Database.SqlSugar
{
    internal class StaticValues
    {
        internal static ILogger<DbContext> Logger;
        internal static IServiceCollection Services = null;
    }
}
