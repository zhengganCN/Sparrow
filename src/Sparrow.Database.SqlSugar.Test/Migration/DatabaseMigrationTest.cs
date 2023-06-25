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
            var version = new SparrowVersion(1, 0, 0, 1)
            {
                Name = "test",
                Creator = "test",
                CreateTime = DateTime.Now
            };
            services.AddSparrowDatabaseMigration<DemoDbContext, DemoMigration<DemoDbContext, SparrowVersion>, SparrowVersion>(version);
        }
    }
}
