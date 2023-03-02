using RabbitMQ.Client;
using System;
using System.Linq;

namespace Sparrow.Extension.RabbitMQ
{
    /// <summary>
    /// RabbitMQ
    /// </summary>
    public class SparrowRabbtiMQ : ISparrowRabbitMQ
    {
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
        /// <returns></returns>
        public IConnection CreateConnection()
        {
            return CreateConnection(StaticValues.default_key);
        }
        /// <summary>
        /// 创建连接
        /// </summary>
        /// <param name="key">指定注册的key创建连接工厂</param>
        /// <returns></returns>
        public IConnection CreateConnection(string key)
        {
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
