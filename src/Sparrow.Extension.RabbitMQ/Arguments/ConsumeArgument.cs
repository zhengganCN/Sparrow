using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;

namespace Sparrow.Extension.RabbitMQ
{
    /// <summary>
    /// 消费者参数
    /// </summary>
    public class ConsumeArgument
    {
        /// <summary>
        /// 自动确认
        /// </summary>
        public bool AutoAck { get; set; } = false;
        /// <summary>
        /// 消费者标签
        /// </summary>
        public string ConsumerTag { get; set; } = "";
        /// <summary>
        /// 非本地
        /// </summary>
        public bool NoLocal { get; set; }
        /// <summary>
        /// 排外
        /// </summary>
        public bool Exclusive { get; set; } = false;
        /// <summary>
        /// 其他参数
        /// </summary>
        public IDictionary<string, object> Arguments { get; set; }
        /// <summary>
        /// 消息接收函数
        /// </summary>
        /// <remarks>
        /// <code>
        /// Received = (obj, deliver) => 
        ///     {
        ///         try
        ///         {
        ///             var body = deliver.Body.ToArray();
        ///             var msg = Encoding.UTF8.GetString(body);
        ///             channel.BasicAck(deliver.DeliveryTag, false);
        ///         }
        ///         catch (Exception ex)
        ///         {
        ///             channel.BasicNack(deliver.DeliveryTag, false, false);
        ///             Console.WriteLine(ex.ToString());
        ///         }
        ///     }
        /// </code>
        /// </remarks>
        public Action<object, BasicDeliverEventArgs> Received;
    }
}
