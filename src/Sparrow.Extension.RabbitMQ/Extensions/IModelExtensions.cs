using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.Extension.RabbitMQ
{
    public static class IModelExtensions
    {
        public static void CreateExchange(this IModel model,string exchange, EnumExchangeType type)
        {
            model.ExchangeDeclare(exchange, Utils.GetExchangeType(type));
        }

        public static void CreateQueue(this IModel model, string queue)
        {
            model.CreateQueue(queue, new QueueArgument());
        }

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

        public static void PublicMessage(this IModel model, string queue, ReadOnlyMemory<byte> message)
        {
            model.BasicPublish("", queue, null, message);
        }

        public static void ConsumeMessage(this IModel model, string queue, ConsumerArgument argument)
        {
            model.BasicConsume(queue, argument.AutoAck, argument.ConsumerTag,
                argument.NoLocal, argument.Exclusive, argument.Arguments, argument.Consumer);
        }

        public static void PublicMessage(this IModel model, string queue, string routeKey, ReadOnlyMemory<byte> message)
        {
            model.BasicPublish("", queue, null, message);
        }
    }
}
