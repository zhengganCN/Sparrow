using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Sparrow.Extension.RabbitMQ.Test
{
    public class Tests
    {
        /// <summary>
        /// 声明队列
        /// </summary>
        /// <param name="mq"></param>
        public void QueueDeclare(SparrowRabbtiMQ mq)
        {
            if (mq is null)
            {
                return;
            }
            var channel = mq.CreateChannel();
            channel.CreateQueue("hello_classic", new QueueArgument
            {
                Type = EnumQueueType.Classic
            });
            channel.CreateQueue("hello_quorum", new QueueArgument
            {
                Type = EnumQueueType.Quorum
            });
            channel.CreateQueue("hello_stream", new QueueArgument
            {
                Type = EnumQueueType.Stream
            });
            channel.Close();
        }

        public void SimplePublic(SparrowRabbtiMQ mq)
        {
            if (mq is null)
            {
                return;
            }
            var channel = mq.CreateChannel();
            //声明一个队列
            channel.CreateQueue("hello");
            for (int i = 0; i < 10; i++)
            {
                channel.PublicMessage("hello", Encoding.UTF8.GetBytes("消息"));
            }
            channel.Close();
        }

        public void Consume(SparrowRabbtiMQ mq)
        {
            if (mq is null)
            {
                return;
            }
            //创建连接
            var connection = mq.CreateConnection();
            
            //创建通道
            var channel = connection.CreateModel();
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (ch, ea) =>
            {
                var body = ea.Body.ToArray();
                var msg = Encoding.UTF8.GetString(body);

                // copy or deserialise the payload
                // and process the message
                // ...
                channel.BasicAck(ea.DeliveryTag, false);
            };
            var argument = new ConsumerArgument
            {
                AutoAck = false,
                Consumer = consumer
            };
            channel.ConsumeMessage("hello", argument);
            //var consumer1 = new EventingBasicConsumer(model);
            //consumer1.Received
            //model.BasicConsume();
            //channel.Close();
            //connection.Close();
        }
    }
}