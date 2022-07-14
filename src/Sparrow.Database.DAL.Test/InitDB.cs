using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Sparrow.Database.DAL.Test
{
    internal class InitDB
    {
        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDAL<Test1DbContext>();
            var provider = services.BuildServiceProvider();
            var dal = provider.GetService<BaseDAL<Test1DbContext>>();
            dal.Context.Database.EnsureCreated();
        }
    }
}
