using System.Collections.Generic;

namespace Sparrow.Extension.RabbitMQ
{
    /// <summary>
    /// 队列参数
    /// </summary>
    public class QueueArgument
    {
        /// <summary>
        /// 队列类型 默认值为Classic
        /// </summary>
        public EnumQueueType Type { get; set; } = EnumQueueType.Classic;
        /// <summary>
        /// 持久 默认值为true
        /// </summary>
        public bool Durable { get; set; } = true;
        /// <summary>
        /// 排外 默认值为false
        /// </summary>
        /// <remarks>即只允许该channel访问该队列，用于一个队列只能有一个消费者来消费的场景</remarks>
        public bool Exclusive { get; set; } = false;
        /// <summary>
        /// 自动删除 默认值为false
        /// </summary>
        /// <remarks>消费完删除队列</remarks>
        public bool AutoDelete { get; set; } = false;
        /// <summary>
        /// 其他属性
        /// </summary>
        public IDictionary<string, object> Arguments { get; set; } = new Dictionary<string, object>();

        /// <summary>
        /// 绑定死信队列
        /// </summary>
        /// <param name="exchange">交换机</param>
        public void BindDeadLetterQueue(string exchange)
        {
            BindDeadLetterQueue(exchange, string.Empty);
        }

        /// <summary>
        /// 绑定死信队列
        /// </summary>
        /// <param name="exchange">交换机</param>
        /// <param name="routeKey">路由key</param>
        public void BindDeadLetterQueue(string exchange, string routeKey)
        {
            var x_dead_letter_exchange = Utils.GetQueueArgumentKey(EnumQueueArguments.x_dead_letter_exchange);
            if (Arguments.ContainsKey(x_dead_letter_exchange))
            {
                Arguments[x_dead_letter_exchange] = exchange;
            }
            else
            {
                Arguments.Add(x_dead_letter_exchange, exchange);
            }
            if (!string.IsNullOrWhiteSpace(routeKey))
            {
                var x_dead_letter_routing_key = Utils.GetQueueArgumentKey(EnumQueueArguments.x_dead_letter_routing_key);
                if (Arguments.ContainsKey(x_dead_letter_routing_key))
                {
                    Arguments[x_dead_letter_routing_key] = routeKey;
                }
                else
                {
                    Arguments.Add(x_dead_letter_routing_key, routeKey);
                }
            }
        }
    }
}
