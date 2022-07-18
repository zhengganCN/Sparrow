using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Sparrow.Logger
{
    /// <summary>
    /// Sparrow日志
    /// </summary>
    public class SparrowLogger
    {
        /// <summary>
        /// 日志，需要在<see cref="IServiceCollection"/>中注册<see cref="LoggerServiceCollectionExtension.AddSparrowLogger(IServiceCollection)"/>
        /// </summary>
        public static ILogger<Logger> Logger { get; internal set; }
    }
}
