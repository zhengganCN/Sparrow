using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Sparrow.Database.SqlSugar.Models;
using Sparrow.Database.SqlSugar.Test.Entities;

namespace Sparrow.Database.SqlSugar.Test.Migration
{
    internal class DatabaseMigrationTest
    {
        [Test]
        public void HumpMigrationTest()
        {
            var services = new ServiceCollection();
            var version = new SparrowVersion(1, 0, 0, 0);
            services.AddSparrowDatabaseMigration<DemoHumpMigration, DemoDbContext>(version);
            using var context = new DemoDbContext();
            var name = "database";
            Assert.True(GetHumpNewestSparrowVersion(context, name).Compare(version) == 0);
            version = new SparrowVersion(1, 0, 1, 0);
            services.AddSparrowDatabaseMigration<DemoHumpMigration, DemoDbContext>(version);
            Assert.True(GetHumpNewestSparrowVersion(context, name).Compare(version) == 0);
            version = new SparrowVersion(1, 0, 0, 5);
            services.AddSparrowDatabaseMigration<DemoHumpMigration, DemoDbContext>(version);
            Assert.True(GetHumpNewestSparrowVersion(context, name).Compare(version) == 1);
            version = new SparrowVersion(1, 1, 0, 0);
            Assert.True(GetHumpNewestSparrowVersion(context, name).Compare(version) == -1);
            context.SugarClient.Deleteable<SparrowVersion>().Where(e => e.Id > 0).ExecuteCommand();
        }

        [Test]
        public void SnakeMigrationTest()
        {
            var services = new ServiceCollection();
            var version = new sparrow_version(1, 0, 0, 0);
            services.AddSparrowDatabaseMigration<DemoSnakeMigration, DemoDbContext>(version);
            using var context = new DemoDbContext();
            var name = "database";
            Assert.True(GetSnakeNewestSparrowVersion(context, name).Compare(version) == 0);
            version = new sparrow_version(1, 0, 1, 0);
            services.AddSparrowDatabaseMigration<DemoSnakeMigration, DemoDbContext>(version);
            Assert.True(GetSnakeNewestSparrowVersion(context, name).Compare(version) == 0);
            version = new sparrow_version(1, 0, 0, 5);
            services.AddSparrowDatabaseMigration<DemoSnakeMigration, DemoDbContext>(version);
            Assert.True(GetSnakeNewestSparrowVersion(context, name).Compare(version) == 1);
            version = new sparrow_version(1, 1, 0, 0);
            Assert.True(GetSnakeNewestSparrowVersion(context, name).Compare(version) == -1);
            context.SugarClient.Deleteable<sparrow_version>().Where(e => e.id > 0).ExecuteCommand();
        }

        [Test]
        public void DefineMigrationTest()
        {
            var services = new ServiceCollection();
            var version = new demo_version(1, 0, 0, 0);
            services.AddSparrowDatabaseMigration<DefineMigration, DemoDbContext>(version);
            using var context = new DemoDbContext();
            var name = "database";
            Assert.True(GetDefineNewestSparrowVersion(context, name).Compare(version) == 0);
            version = new demo_version(1, 0, 1, 0);
            services.AddSparrowDatabaseMigration<DefineMigration, DemoDbContext>(version);
            Assert.True(GetDefineNewestSparrowVersion(context, name).Compare(version) == 0);
            version = new demo_version(1, 0, 0, 5);
            services.AddSparrowDatabaseMigration<DefineMigration, DemoDbContext>(version);
            Assert.True(GetDefineNewestSparrowVersion(context, name).Compare(version) == 1);
            version = new demo_version(1, 1, 0, 0);
            Assert.True(GetDefineNewestSparrowVersion(context, name).Compare(version) == -1);
            context.SugarClient.Deleteable<demo_version>().Where(e => e.id > 0).ExecuteCommand();
        }

        private static SparrowVersion GetHumpNewestSparrowVersion(DemoDbContext context, string name)
        {
            return context.SugarClient.Queryable<SparrowVersion>()
                .Where(e => e.Name == name)
                .Where(e => e.IsDeleted == false)
                .OrderByDescending(e => e.Serial)
                .First();
        }
        private static sparrow_version GetSnakeNewestSparrowVersion(DemoDbContext context, string name)
        {
            return context.SugarClient.Queryable<sparrow_version>()
                .Where(e => e.name == name)
                .Where(e => e.is_deleted == false)
                .OrderByDescending(e => e.serial)
                .First();
        }
        private static demo_version GetDefineNewestSparrowVersion(DemoDbContext context, string name)
        {
            return context.SugarClient.Queryable<demo_version>()
                .Where(e => e.name == name)
                .Where(e => e.is_deleted == false)
                .OrderByDescending(e => e.serial)
                .First();
        }
    }
}
