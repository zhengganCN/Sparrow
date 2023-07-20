using Microsoft.Extensions.DependencyInjection;
using Sparrow.Monitor.Flow;
using System;

namespace Sparrow.Monitor
{
    public static class SparrowMonitorServiceCollectionExtension
    {
        /// <summary>
        /// 添加访问频率设置
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddSparrowAccessFrequency(this IServiceCollection services, Action<AccessFrequency> action)
        {
            action?.Invoke(SparrowAccessFrequencyAttribute.AccessFrequency);
            return services;
        }
    }
}
