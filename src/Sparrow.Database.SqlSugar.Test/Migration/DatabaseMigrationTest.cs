using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;

namespace Sparrow.Database.SqlSugar.Test.Migration
{
    internal class DatabaseMigrationTest
    {
        [Test]
        public void MigrationTest()
        {
            var services = new ServiceCollection();
            var version = new SparrowVersion(1, 0, 1, 6)
            {
                Name = "test",
                Creator = "test",
                CreateTime = DateTime.Now
            };
            services.AddSparrowDatabaseMigration<DemoMigration<DemoDbContext>, SparrowVersion>(version);
        }
    }
}
