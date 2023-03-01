using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using System;
using System.Linq;

namespace Sparrow.Extension.RabbitMQ
{
    /// <summary>
    /// 服务扩展
    /// </summary>
    public static class SparrowRabbitMQIServiceCollectionExtensions
    {
        public static IServiceCollection AddSparrowRabbitMQ(this IServiceCollection services, Action<ConnectionFactory> action)
        {
            services.AddSparrowRabbitMQ(StaticValues.default_key, action);
            return services;
        }

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
