using RabbitMQ.Client;
using System;
using System.Linq;

namespace Sparrow.Extension.RabbitMQ
{
    public class SparrowRabbtiMQ : ISparrowRabbitMQ
    {
        public ConnectionFactory CreateConnectionFactory()
        {
            return CreateConnectionFactory(StaticValues.default_key);
        }

        public ConnectionFactory CreateConnectionFactory(string key)
        {
            if (StaticValues.ConnectionFactories.Any(e => e.Key == key))
            {
                return StaticValues.ConnectionFactories[key];
            }
            throw new ArgumentException("must register service of AddSparrowRabbitMQ");
        }

        public IConnection CreateConnection()
        {
            return CreateConnection(StaticValues.default_key);
        }

        public IConnection CreateConnection(string key)
        {
            return CreateConnectionFactory(key).CreateConnection();
        }

        public IModel CreateChannel()
        {
            return CreateChannel(StaticValues.default_key);
        }

        public IModel CreateChannel(string key)
        {
            return CreateConnectionFactory(key).CreateConnection().CreateModel();
        }

        public void Dispose()
        {
        }
    }
}
