using Microsoft.Extensions.DependencyInjection;
using System;

namespace Sparrow.Extension.RabbitMQ.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            //services.AddSparrowRabbitMQ(options =>
            //{
            //    options.UserName = "admin";
            //    options.Password = "hyy5201314";
            //    options.HostName = "dostudy.top";
            //});
            services.AddSparrowRabbitMQ(options =>
            {
                options.UserName = "guest";
                options.Password = "guest";
                options.Port = 5672;
                options.HostName = "192.168.3.122";
            });
            Console.WriteLine("Press enter number to choice function");

            var provider = services.BuildServiceProvider();
            var mq = provider.GetService<SparrowRabbtiMQ>();
            var test = new Tests();
            test.ExchangeDeclare(mq);
            //test.QueueDeclare(mq);
            //test.SimplePublic(mq);
            //test.Consume(mq);
            TestDeadLetterQueue(mq, test);
            Console.ReadLine();
            Console.WriteLine("Hello World!");
        }

        private static void TestDeadLetterQueue(SparrowRabbtiMQ mq, Tests test)
        {
            test.DeadLetterQueueDeclare(mq);
        }
    }
}
