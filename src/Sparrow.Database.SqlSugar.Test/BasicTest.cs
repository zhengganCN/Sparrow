using NUnit.Framework;

namespace Sparrow.Database.SqlSugar.Test
{
    internal class BasicTest
    {
        [Test]
        public void ConnectTest()
        {
            using var context = new DemoDbContext();
            context.SugarClient.CodeFirst.InitTables(typeof(EntityDistricts));
        }
    }
}
