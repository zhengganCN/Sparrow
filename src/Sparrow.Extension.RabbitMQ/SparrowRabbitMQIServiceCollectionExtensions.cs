using RabbitMQ.Client;
using Sparrow.Extension.RabbitMQ;
using System;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 服务扩展
    /// </summary>
    public static class SparrowRabbitMQIServiceCollectionExtensions
    {
        /// <summary>
        /// 注册RabbitMQ
        /// </summary>
        /// <param name="services"></param>
        /// <param name="action">参数</param>
        /// <returns></returns>
        public static IServiceCollection AddSparrowRabbitMQ(this IServiceCollection services, Action<ConnectionFactory> action)
        {
            services.AddSparrowRabbitMQ(StaticValues.default_key, action);
            return services;
        }
        /// <summary>
        /// 注册RabbitMQ
        /// </summary>
        /// <param name="services"></param>
        /// <param name="key">区分不同的RabbitMQ客户端；<see cref="SparrowRabbtiMQ"/>函数中的key</param>
        /// <param name="action">参数</param>
        /// <returns></returns>
        public static IServiceCollection AddSparrowRabbitMQ(this IServiceCollection services, string key, Action<ConnectionFactory> action)
        {
            var factory = new ConnectionFactory();
            action.Invoke(factory);
            if (StaticValues.ConnectionFactories.Any(e => e.Key == key))
            {
                StaticValues.ConnectionFactories[key] = factory;
            }
            else
            {
                StaticValues.ConnectionFactories.Add(key, factory);
            }
            services.AddSingleton<SparrowRabbtiMQ>();
            services.AddSingleton<ISparrowRabbitMQ, SparrowRabbtiMQ>();
            return services;
        }

    }
}
