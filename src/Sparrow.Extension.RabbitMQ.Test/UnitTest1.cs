using RabbitMQ.Client;
using System;
using System.Text;

namespace Sparrow.Extension.RabbitMQ.Test
{
    public class Tests
    {
        /// <summary>
        /// 测试
        /// </summary>
        /// <param name="mq"></param>
        public void QueueDeclare(SparrowRabbitMQ mq)
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

        private const string ExchangeDlx = "test.sparrow.exchange.dlx";
        private const string ExchangeDirect = "test.sparrow.exchange.direct";
        private const string ExchangeFanout = "test.sparrow.exchange.fanout";
        private const string ExchangeTopic = "test.sparrow.exchange.topic";
        private const string ExchangeHeaders = "test.sparrow.exchange.headers";

        /// <summary>
        /// ����������
        /// </summary>
        /// <param name="mq"></param>
        public void ExchangeDeclare(SparrowRabbitMQ mq)
        {
            if (mq is null)
            {
                return;
            }
            var channel = mq.CreateChannel();
            channel.CreateExchange(ExchangeDlx, new ExchangeArgument
            {
                Type = EnumExchangeType.Direct
            });
            channel.CreateExchange(ExchangeDirect, new ExchangeArgument
            {
                Type = EnumExchangeType.Direct
            });
            channel.CreateExchange(ExchangeFanout, new ExchangeArgument
            {
                Type = EnumExchangeType.Fanout
            });
            channel.CreateExchange(ExchangeTopic, new ExchangeArgument
            {
                Type = EnumExchangeType.Topic
            });
            channel.CreateExchange(ExchangeHeaders, new ExchangeArgument
            {
                Type = EnumExchangeType.Headers
            });
        }

        /// <summary>
        /// �����������к����Ŷ��У��������Ŷ���
        /// </summary>
        /// <param name="mq"></param>
        public void DeadLetterQueueDeclare(SparrowRabbitMQ mq)
        {
            if (mq is null)
            {
                return;
            }
            var channel = mq.CreateChannel();
            var queue = "test.sparrow.queue.001";
            var routingKey = queue;
            var queueDlx = "test.sparrow.queue.001.dlx";
            var routingKeyDlx = queueDlx;
            channel.CreateQueue(queueDlx, new QueueArgument
            {
                Type = EnumQueueType.Classic
            });
            var queueArgument = new QueueArgument
            {
                Type = EnumQueueType.Classic
            };
            queueArgument.BindDeadLetterQueue(ExchangeDlx, routingKeyDlx);
            channel.CreateQueue(queue, queueArgument);

            channel.QueueBind(queue, ExchangeDirect, routingKey);
            channel.QueueBind(queueDlx, ExchangeDlx, routingKeyDlx);

            for (int i = 0; i < 3; i++)
            {
                var msg = Encoding.UTF8.GetBytes($"��{i}����Ϣ");
                channel.PublishMessage(ExchangeDirect, routingKey, msg);
            }
            channel.BasicQos(0, 1, false);
            var consumeArgument = new ConsumeArgument
            {
                AutoAck = false,
                Received = (obj, deliver) =>
                {
                    try
                    {
                        var body = deliver.Body.ToArray();
                        var msg = Encoding.UTF8.GetString(body);
                        channel.BasicAck(deliver.DeliveryTag, false);
                    }
                    catch (Exception ex)
                    {
                        channel.BasicNack(deliver.DeliveryTag, false, false);
                        Console.WriteLine(ex.ToString());
                    }
                }
            };
            channel.ConsumeMessage(queue, consumeArgument);
        }
    }
}