using Microsoft.AspNetCore.Builder;
using Sparrow.Monitor.Http;

namespace Sparrow.Monitor
{
    /// <summary>
    /// 监控扩展
    /// </summary>
    public static class SparrowMonitorApplicationExtension
    {
        /// <summary>
        /// http记录器
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSparrowHttpRecorder(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<SparrowHttpRecorderMiddleware>();
            return builder;
        }
    }
}
