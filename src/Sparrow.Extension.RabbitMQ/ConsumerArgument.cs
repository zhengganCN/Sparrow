using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.Extension.RabbitMQ
{
    /// <summary>
    /// 消费者参数
    /// </summary>
    public class ConsumerArgument
    {
        /// <summary>
        /// 自动确认
        /// </summary>
        public bool AutoAck { get; set; } = false;
        public string ConsumerTag { get; set; } = "";
        public bool NoLocal { get; set; }
        public bool Exclusive { get; set; } = false;
        public IDictionary<string, object> Arguments { get; set; }
        /// <summary>
        /// 消费者
        /// </summary>
        public IBasicConsumer Consumer { get; set; }
    }
}
