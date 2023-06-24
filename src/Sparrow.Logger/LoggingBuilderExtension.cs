using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Sparrow.Logger
{
    /// <summary>
    /// 日志服务注册扩展
    /// </summary>
    public static class LoggingBuilderExtension
    {
        /// <summary>
        /// 添加通用日志
        /// </summary>
        /// <param name="loggingBuilder">日志构造器</param>
        /// <returns></returns>
        public static ILoggingBuilder AddSparrowLogger(this ILoggingBuilder loggingBuilder)
        {
            var provider = loggingBuilder.Services.BuildServiceProvider();
            SparrowLogger.LoggerFactory = provider.GetRequiredService<ILoggerFactory>();
            return loggingBuilder;
        }
    }
}
