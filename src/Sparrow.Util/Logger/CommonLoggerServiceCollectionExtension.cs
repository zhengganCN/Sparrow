using Microsoft.Extensions.Logging;
using Sparrow.Util.Logger;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 通用日志服务注册扩展
    /// </summary>
    public static class CommonLoggerServiceCollectionExtension
    {
        /// <summary>
        /// 添加通用日志
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCommonLogger(this IServiceCollection services)
        {
            var logger = services.BuildServiceProvider().GetService<ILogger<CommonLogger>>();
            CommonLogger.Logger = logger;
            return services;
        }
    }
}
