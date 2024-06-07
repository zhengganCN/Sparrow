using NUnit.Framework;
using Sparrow.Database.SqlSugar.Extensions;

namespace Sparrow.Database.SqlSugar.Test.Repositories
{
    internal class RepositoryTest
    {
        [Test]
        public void GetDistrictCountTest()
        {
            using var context = new DemoDbContext();
            var count = context.Repository<DistrictRepository>().GetDistrictCount();
        }
    }
}
