using NUnit.Framework;

namespace Sparrow.Database.SqlSugar.Test
{
    internal class SshDbTest
    {
        [Test]
        public void SshConnectTest()
        {
            using var context = new SshDemoDbContext();
            var table = context.SugarClient.Ado.GetDataTable("show tables");
        }
    }
}
