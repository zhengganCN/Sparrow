using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Sparrow.StandardResult.Test.RegisterTest
{
    internal class RegisterStandardResultTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void RegisterDefaultStandardResultTest()
        {
            var services = new ServiceCollection();
            services.AddDefaultStandardResult();
            new Standard();
            Assert.Pass();
        }

        [TestCase("test_1")]
        [TestCase("test_2")]
        [TestCase("test_3")]
        [TestCase("test_4")]
        [TestCase("test_5")]
        public void RegisterDefineStandardResultTest(string key)
        {
            var services = new ServiceCollection();
            services.AddStandardResult(key);
            new Standard(key);
        }
    }
}
