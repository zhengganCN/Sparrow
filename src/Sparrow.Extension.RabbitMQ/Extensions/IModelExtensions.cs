using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;

namespace Sparrow.Extension.RabbitMQ
{
    /// <summary>
    /// <see cref="IModel"/>扩展
    /// </summary>
    public static class IModelExtensions
    {
        /// <summary>
        /// 创建交换机
        /// </summary>
        /// <param name="model"></param>
        /// <param name="exchange">交换机名称</param>
        public static void CreateExchange(this IModel model, string exchange)
        {
            model.CreateExchange(exchange, new ExchangeArgument());
        }
        /// <summary>
        /// 创建交换机
        /// </summary>
        /// <param name="model"></param>
        /// <param name="exchange">交换机名称</param>
        /// <param name="argument">交换机参数</param>
        public static void CreateExchange(this IModel model, string exchange, ExchangeArgument argument)
        {
            model.ExchangeDeclare(exchange, Utils.GetExchangeType(argument.Type), argument.Durable, argument.AutoDelete, argument.Arguments);
        }
        /// <summary>
        /// 创建队列
        /// </summary>
        /// <param name="model"></param>
        /// <param name="queue">队列名称</param>
        public static void CreateQueue(this IModel model, string queue)
        {
            model.CreateQueue(queue, new QueueArgument());
        }
        /// <summary>
        /// 创建队列
        /// </summary>
        /// <param name="model"></param>
        /// <param name="queue">队列名称</param>
        /// <param name="argument">队列参数</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void CreateQueue(this IModel model, string queue, QueueArgument argument)
        {
            if (argument is null)
            {
                throw new ArgumentNullException(nameof(argument));
            }
            if (argument.Arguments is null)
            {
                argument.Arguments = new Dictionary<string, object>();
            }
            if (argument.Arguments.ContainsKey("x-queue-type"))
            {
                argument.Arguments["x-queue-type"] = argument.Type.ToString().ToLowerInvariant();
            }
            else
            {
                argument.Arguments.Add("x-queue-type", argument.Type.ToString().ToLowerInvariant());
            }
            model.QueueDeclare(queue, argument.Durable, argument.Exclusive, argument.AutoDelete, argument.Arguments);
        }

        /// <summary>
        /// 发布消息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="exchange">交换机名称</param>
        /// <param name="routingKey">路由</param>
        /// <param name="message">消息体</param>
        public static void PublishMessage(this IModel model, string exchange, string routingKey, ReadOnlyMemory<byte> message)
        {
            model.PublishMessage(exchange, routingKey, message, new PublishArgument());
        }
        /// <summary>
        /// 发布消息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="exchange">交换机名称</param>
        /// <param name="routingKey">路由</param>
        /// <param name="message">消息体</param>
        /// <param name="argument">发布参数</param>
        public static void PublishMessage(this IModel model, string exchange, string routingKey, ReadOnlyMemory<byte> message, PublishArgument argument)
        {
            model.BasicPublish(exchange, routingKey, argument.Mandatory, argument.BasicProperties, message);
        }

        /// <summary>
        /// 消费消息
        /// </summary>
        /// <param name="model"></param>
        /// <param name="queue">队列名称</param>
        /// <param name="argument">消费参数</param>
        public static void ConsumeMessage(this IModel model, string queue, ConsumeArgument argument)
        {
            var eventing = new EventingBasicConsumer(model);
            eventing.Received += (obj, deliver) =>
            {
                argument.Received.Invoke(obj, deliver);
            };
            model.BasicConsume(queue, argument.AutoAck, argument.ConsumerTag,
                argument.NoLocal, argument.Exclusive, argument.Arguments, eventing);

        }
    }
}
