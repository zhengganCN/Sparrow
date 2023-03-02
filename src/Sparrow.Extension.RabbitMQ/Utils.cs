using RabbitMQ.Client;

namespace Sparrow.Extension.RabbitMQ
{
    internal static class Utils
    {
        internal static string GetExchangeType(EnumExchangeType type)
        {
            var result = string.Empty;
            switch (type)
            {
                case EnumExchangeType.Direct:
                    result = ExchangeType.Direct;
                    break;
                case EnumExchangeType.Fanout:
                    result = ExchangeType.Fanout;
                    break;
                case EnumExchangeType.Headers:
                    result = ExchangeType.Headers;
                    break;
                case EnumExchangeType.Topic:
                    result = ExchangeType.Topic;
                    break;
            }
            return result;
        }


        internal static string GetQueueArgumentKey(EnumQueueArguments arguments)
        {
            return arguments.ToString().Replace('_', '-');
        }
    }
}
