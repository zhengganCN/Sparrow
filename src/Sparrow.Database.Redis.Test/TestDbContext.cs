using NUnit.Framework;

namespace Sparrow.Database.Redis.Test
{
    public class TestDbContext
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NewInstanceTest()
        {
            using var context = new DemoDbContext();
            var hash = context.RedisClient().HashGet("public_approval_level_dict:detail");
            Assert.Pass();
        }

        [Test]
        public void GetDataFromDb2Test()
        {
            using var context = new DemoDbContext();
            var hash = context.RedisClient(1).HashGet("fizz_rate_limit");
            Assert.Pass();
        }
    }
}