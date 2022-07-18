using Microsoft.Extensions.Logging;
using Sparrow.Logger;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 日志服务注册扩展
    /// </summary>
    public static class LoggerServiceCollectionExtension
    {
        /// <summary>
        /// 添加通用日志
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSparrowLogger(this IServiceCollection services)
        {
            var provider = services.BuildServiceProvider();
            SparrowLogger.Logger = provider.GetService<ILogger<Logger>>();
            return services;
        }
    }
}
