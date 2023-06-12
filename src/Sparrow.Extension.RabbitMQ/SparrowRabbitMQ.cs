using RabbitMQ.Client;
using System;
using System.Linq;

namespace Sparrow.Extension.RabbitMQ
{
    /// <summary>
    /// RabbitMQ
    /// </summary>
    public class SparrowRabbitMQ : ISparrowRabbitMQ
    {
        private static readonly object ObjectLock = new object();
        /// <summary>
        /// 创建连接工厂
        /// </summary>
        /// <returns></returns>
        public static ConnectionFactory CreateConnectionFactory()
        {
            return CreateConnectionFactory(StaticValues.default_key);
        }
        /// <summary>
        /// 创建连接工厂
        /// </summary>
        /// <param name="key">指定注册的key创建连接工厂</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static ConnectionFactory CreateConnectionFactory(string key)
        {
            if (StaticValues.ConnectionFactories.Any(e => e.Key == key))
            {
                return StaticValues.ConnectionFactories[key];
            }
            throw new ArgumentException("must register service of AddSparrowRabbitMQ");
        }

        /// <summary>
        /// 创建连接
        /// </summary>
        /// <param name="singleton">单例模式，默认值为false</param>
        /// <returns></returns>
        public IConnection CreateConnection(bool singleton = false)
        {
            return CreateConnection(StaticValues.default_key, singleton);
        }
        /// <summary>
        /// 创建连接
        /// </summary>
        /// <param name="key">指定注册的key创建连接工厂</param>
        /// <param name="singleton">单例模式，默认值为false</param>
        /// <returns></returns>
        public IConnection CreateConnection(string key, bool singleton = false)
        {
            if (singleton)
            {
                lock (ObjectLock)
                {
                    if (!StaticValues.Connections.Any(e => e.Key == key))
                    {
                        StaticValues.Connections[key] = CreateConnectionFactory(key).CreateConnection();
                    }
                }
                return StaticValues.Connections[key];
            }
            return CreateConnectionFactory(key).CreateConnection();
        }
        /// <summary>
        /// 创建通道
        /// </summary>
        /// <returns></returns>
        public IModel CreateChannel()
        {
            return CreateChannel(StaticValues.default_key);
        }
        /// <summary>
        /// 创建通道
        /// </summary>
        /// <param name="key">指定注册的key创建通道</param>
        /// <returns></returns>
        public IModel CreateChannel(string key)
        {
            return CreateConnectionFactory(key).CreateConnection().CreateModel();
        }
    }
}
