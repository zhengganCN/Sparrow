using Microsoft.Extensions.Configuration;
using Sparrow.Configuration.Test.models;
using System.Text;

namespace Sparrow.Configuration.Test
{
    public class Tests
    {
        private IConfigurationRoot Configuration;
        [SetUp]
        public void Setup()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "configs", "data.json");
            var builder = new ConfigurationBuilder().AddJsonFile(path);
            Configuration = builder.Build();
        }

        [Test]
        public void BasicObjectTest()
        {
            var num = Configuration.GetObject<int>("num_1");
            Assert.Pass();
        }

        [Test]
        public void ArrayObjectTest()
        {
            var list = Configuration.GetObject<int[]>("list_num");
            Assert.IsTrue(list.Count() == 5);
        }

        [Test]
        public void SimpleObjectTest()
        {
            var obj = Configuration.GetObject<SimpleObject>("obj");
            var list_obj = Configuration.GetObject<SimpleObject[]>("list_obj");
            var person = Configuration.GetObject<Person>("person");
            var all = Configuration.GetObject();
            Assert.Pass();
        }
    }
}