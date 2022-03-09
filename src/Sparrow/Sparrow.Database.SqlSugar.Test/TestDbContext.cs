using NUnit.Framework;

namespace Sparrow.Database.SqlSugar.Test
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
            var data = context.SugarClient.Queryable<EntityDistricts>()
                .Where(entity => entity.DistrictCode.StartsWith("35"))
                .ToPageList(1, 10);
            Assert.Pass();
        }

        [Test]
        public void LogTest()
        {
            using var context = new DemoDbContext();
            var data = context.SugarClient.Queryable<EntityDistricts>()
                .Where(entity => entity.DistrictCode.StartsWith("35"))
                .ToPageList(1, 10);
            Assert.Pass();
        }
    }
}