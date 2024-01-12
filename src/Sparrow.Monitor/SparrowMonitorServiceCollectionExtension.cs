using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Sparrow.Monitor.Flow;
using Sparrow.Monitor.Http;
using System;

namespace Sparrow.Monitor
{
    /// <summary>
    /// 监控扩展
    /// </summary>
    public static class SparrowMonitorServiceCollectionExtension
    {
        /// <summary>
        /// 添加访问频率设置
        /// </summary>
        /// <returns></returns>
        public static IServiceCollection AddSparrowAccessFrequency(this IServiceCollection services, Action<AccessFrequency> action)
        {
            action?.Invoke(SparrowAccessFrequencyAttribute.AccessFrequency);
            return services;
        }

        /// <summary>
        /// 添加Http记录器设置
        /// </summary>
        /// <returns></returns>
        public static IServiceCollection AddSparrowHttpRecorder(this IServiceCollection services, Func<HttpContext, string> format, Action<string> recorder)
        {
            HttpRecorder.FormatHttpContextFunc = format;
            HttpRecorder.RecordStringAction = recorder;
            return services;
        }

    }
}
