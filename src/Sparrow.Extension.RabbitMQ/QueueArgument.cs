using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.Extension.RabbitMQ
{
    public class QueueArgument
    {
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
        public IDictionary<string, object> Arguments { get; set; } = null;
    }
}
