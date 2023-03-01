using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow.Extension.RabbitMQ.Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddSparrowRabbitMQ(options =>
            {
                options.UserName = "admin";
                options.Password = "hyy5201314";
                options.HostName = "dostudy.top";
            });
            Console.WriteLine("Press enter number to choice function");
            
            var provider = services.BuildServiceProvider();
            var mq = provider.GetService<SparrowRabbtiMQ>();
            var test = new Tests();
            test.QueueDeclare(mq);
            test.SimplePublic(mq);
            //new Tests().Consume(mq);
            Console.ReadLine();
            Console.WriteLine("Hello World!");
        }
    }
}
