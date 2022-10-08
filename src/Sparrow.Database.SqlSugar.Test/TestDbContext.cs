using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace Sparrow.Database.SqlSugar.Test
{
    public class TestDbContext
    {
        private DbContextFactory? _dbContextFactory;
        [SetUp]
        public void Setup()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddSqlSugar<DemoDbContext>(GetType().Assembly);
            var provider = services.BuildServiceProvider();
            _dbContextFactory = provider.GetService<DbContextFactory>();
        }

        [Test]
        public void NewInstanceTest()
        {
            using var context = _dbContextFactory?.GetDbContext<DemoDbContext>();
            context?.SugarClient.CodeFirst.InitTables(typeof(EntityDistricts));
            var data = context?.SugarClient.Queryable<EntityDistricts>()
                .Where(entity => entity.DistrictCode.StartsWith("35"))
                .ToPageList(1, 10);
            Assert.Pass();
        }

        [Test]
        public void LogTest()
        {
            using var context = _dbContextFactory?.GetDbContext<DemoDbContext>();
            var data = context?.SugarClient.Queryable<EntityDistricts>()
                .Where(entity => entity.DistrictCode.StartsWith("35"))
                .ToPageList(1, 10);
            Assert.Pass();
        }
    }
}