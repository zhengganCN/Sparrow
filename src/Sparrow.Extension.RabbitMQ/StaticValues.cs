using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.Extension.RabbitMQ
{
    internal static class StaticValues
    {
        internal const string default_key = "sparrow_extension_rabbitmq_default";
        internal static Dictionary<string, ConnectionFactory> ConnectionFactories = new Dictionary<string, ConnectionFactory>();
    }
}
