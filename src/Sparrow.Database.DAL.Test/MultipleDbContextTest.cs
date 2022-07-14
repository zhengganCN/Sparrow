using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Sparrow.Database.DAL.Test
{
    internal class MultipleDbContextTest
    {
        private BaseDAL<Test1DbContext> daltest1;
        private BaseDAL<Test2DbContext> daltest2;

        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDAL<Test1DbContext>();
            services.AddDAL<Test2DbContext>();
            var provider = services.BuildServiceProvider();
            daltest1 = provider.GetService<BaseDAL<Test1DbContext>>();
            daltest2 = provider.GetService<BaseDAL<Test2DbContext>>();
        }

        [Test]
        public void GenerateDatabase()
        {
            daltest1.Context.Database.EnsureCreated();
            daltest2.Context.Database.EnsureCreated();
            Assert.Pass();
        }
    }
}
