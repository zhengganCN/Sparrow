using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Sparrow.Database.SqlSugar.Migrations;

namespace Sparrow.Database.SqlSugar.Test.Migrations
{
    internal class DatabaseMigrationTest
    {
        [SetUp]
        public void SetUp()
        {
            //File.Delete(MigrationDbContext.DatabasePath);
        }

        [Test]
        public void MigrationTest()
        {
            IServiceCollection services = new ServiceCollection();
            var hump_tables = new string[] { "TestVersion", "MigrationVer" };
            var snake_tables = new string[] { "test_version", "migration_ver" };
            var names = new string[] { "migration", "computer" };
            MigrationOptions migration = null;
            var naming = NamingScheme.Snake;
            foreach (var name in names)
            {
                foreach (var item in hump_tables)
                {
                    migration = new MigrationOptions(1, 0, 0, 0, name) { SheetName = item };
                    services.ExecuteMigration(migration, null);
                    migration = new MigrationOptions(1, 0, 0, 0, name) { SheetName = item };
                    services.ExecuteMigration(migration, 0);
                    migration = new MigrationOptions(1, 0, 0, 1, name) { SheetName = item };
                    services.ExecuteMigration(migration, 1);
                    migration = new MigrationOptions(1, 0, 1, 0, name) { SheetName = item };
                    services.ExecuteMigration(migration, 1);
                    migration = new MigrationOptions(1, 1, 0, 0, name) { SheetName = item };
                    services.ExecuteMigration(migration, 1);
                    migration = new MigrationOptions(1, 0, 0, 0, name) { SheetName = item };
                    services.ExecuteMigration(migration, -1);
                    migration = new MigrationOptions(1, 1, 0, 0, name) { SheetName = item };
                    services.ExecuteMigration(migration, 0);
                    migration = new MigrationOptions(2, 1, 1, 1, name) { SheetName = item };
                    services.ExecuteMigration(migration, 1);
                    migration = new MigrationOptions(2, 1, 1, 1, name) { SheetName = item };
                    services.ExecuteMigration(migration, 0);
                    migration = new MigrationOptions(2, 1, 1, 0, name) { SheetName = item };
                    services.ExecuteMigration(migration, -1);
                    migration = new MigrationOptions(1, 1, 1, 0, name) { SheetName = item };
                    services.ExecuteMigration(migration, -1);
                    migration = new MigrationOptions(1, 1000, 1, 0, name) { SheetName = item };
                    services.ExecuteMigration(migration, -1);
                }
                foreach (var item in snake_tables)
                {
                    migration = new MigrationOptions(1, 0, 0, 0, name) { SheetName = item, NamingScheme = naming };
                    services.ExecuteMigration(migration, null);
                    migration = new MigrationOptions(1, 0, 0, 0, name) { SheetName = item, NamingScheme = naming };
                    services.ExecuteMigration(migration, 0);
                    migration = new MigrationOptions(1, 0, 0, 1, name) { SheetName = item, NamingScheme = naming };
                    services.ExecuteMigration(migration, 1);
                    migration = new MigrationOptions(1, 0, 1, 0, name) { SheetName = item, NamingScheme = naming };
                    services.ExecuteMigration(migration, 1);
                    migration = new MigrationOptions(1, 1, 0, 0, name) { SheetName = item, NamingScheme = naming };
                    services.ExecuteMigration(migration, 1);
                    migration = new MigrationOptions(1, 0, 0, 0, name) { SheetName = item, NamingScheme = naming };
                    services.ExecuteMigration(migration, -1);
                    migration = new MigrationOptions(1, 1, 0, 0, name) { SheetName = item, NamingScheme = naming };
                    services.ExecuteMigration(migration, 0);
                    migration = new MigrationOptions(2, 1, 1, 1, name) { SheetName = item, NamingScheme = naming };
                    services.ExecuteMigration(migration, 1);
                    migration = new MigrationOptions(2, 1, 1, 1, name) { SheetName = item, NamingScheme = naming };
                    services.ExecuteMigration(migration, 0);
                    migration = new MigrationOptions(2, 1, 1, 0, name) { SheetName = item, NamingScheme = naming };
                    services.ExecuteMigration(migration, -1);
                    migration = new MigrationOptions(1, 1, 1, 0, name) { SheetName = item, NamingScheme = naming };
                    services.ExecuteMigration(migration, -1);
                    migration = new MigrationOptions(1, 1000, 1, 0, name) { SheetName = item, NamingScheme = naming };
                    services.ExecuteMigration(migration, -1);
                }
            }
            migration = new MigrationOptions(1, 0, 0, 0);
            services.ExecuteMigration(migration, null);
            migration = new MigrationOptions(1, 0, 0, 0);
            services.ExecuteMigration(migration, 0);
            migration = new MigrationOptions(1, 0, 0, 1);
            services.ExecuteMigration(migration, 1);
            migration = new MigrationOptions(1, 0, 1, 0);
            services.ExecuteMigration(migration, 1);
            migration = new MigrationOptions(1, 1, 0, 0);
            services.ExecuteMigration(migration, 1);
            migration = new MigrationOptions(1, 0, 0, 0);
            services.ExecuteMigration(migration, -1);
            migration = new MigrationOptions(1, 1, 0, 0);
            services.ExecuteMigration(migration, 0);
            migration = new MigrationOptions(2, 1, 1, 1);
            services.ExecuteMigration(migration, 1);
            migration = new MigrationOptions(2, 1, 1, 1);
            services.ExecuteMigration(migration, 0);
            migration = new MigrationOptions(2, 1, 1, 0);
            services.ExecuteMigration(migration, -1);
            migration = new MigrationOptions(1, 1, 1, 0);
            services.ExecuteMigration(migration, -1);
            migration = new MigrationOptions(1, 1000, 1, 0);
            services.ExecuteMigration(migration, -1);


            migration = new MigrationOptions(1, 0, 0, 0) { NamingScheme = naming };
            services.ExecuteMigration(migration, null);
            migration = new MigrationOptions(1, 0, 0, 0) { NamingScheme = naming };
            services.ExecuteMigration(migration, 0);
            migration = new MigrationOptions(1, 0, 0, 1) { NamingScheme = naming };
            services.ExecuteMigration(migration, 1);
            migration = new MigrationOptions(1, 0, 1, 0) { NamingScheme = naming };
            services.ExecuteMigration(migration, 1);
            migration = new MigrationOptions(1, 1, 0, 0) { NamingScheme = naming };
            services.ExecuteMigration(migration, 1);
            migration = new MigrationOptions(1, 0, 0, 0) { NamingScheme = naming };
            services.ExecuteMigration(migration, -1);
            migration = new MigrationOptions(1, 1, 0, 0) { NamingScheme = naming };
            services.ExecuteMigration(migration, 0);
            migration = new MigrationOptions(2, 1, 1, 1) { NamingScheme = naming };
            services.ExecuteMigration(migration, 1);
            migration = new MigrationOptions(2, 1, 1, 1) { NamingScheme = naming };
            services.ExecuteMigration(migration, 0);
            migration = new MigrationOptions(2, 1, 1, 0) { NamingScheme = naming };
            services.ExecuteMigration(migration, -1);
            migration = new MigrationOptions(1, 1, 1, 0) { NamingScheme = naming };
            services.ExecuteMigration(migration, -1);
            migration = new MigrationOptions(1, 1000, 1, 0) { NamingScheme = naming };
            services.ExecuteMigration(migration, -1);
        }

        [Test]
        public void MigrationViewTest()
        {
            IServiceCollection services = new ServiceCollection();
            var migration = new MigrationOptions(1, 0, 0, 0) { NamingScheme = NamingScheme.Snake };
            services.AddSparrowDatabaseMigration<DemoDatabaseMigration, MigrationDbContext>(migration);
        }
    }
    public static class MigrationTestExtensions
    {
        public static void ExecuteMigration(this IServiceCollection services, MigrationOptions migration, int? compare)
        {
            using var context = new MigrationDbContext();
            var current_serial = migration.ComputerVersionSeria();
            if (compare != null)
            {
                if (string.IsNullOrWhiteSpace(migration.SheetName))
                {
                    migration.SheetName = migration.NamingScheme switch
                    {
                        NamingScheme.Hump => "SparrowVersion",
                        NamingScheme.Snake => "sparrow_version",
                        _ => "SparrowVersion",
                    };
                }
                if (string.IsNullOrWhiteSpace(migration.Name))
                {
                    migration.Name = "database";
                }
                if (!CompareSerial(context, migration, compare))
                {
                    Assert.Fail("表迁移失败");
                }
            }
            services.AddSparrowDatabaseMigration<DemoDatabaseMigration, MigrationDbContext>(migration);
            if (compare == 1 || compare is null)
            {
                compare = 0;
            }
            if (!CompareSerial(context, migration, compare))
            {
                Assert.Fail("表迁移失败");
            }
        }

        private static bool CompareSerial(MigrationDbContext context, MigrationOptions migration, int? compare)
        {
            bool res = false;
            var current = migration.ComputerVersionSeria();
            var actual_serial = context.SugarClient.Queryable<object>().AS(migration.SheetName)
                .Where($"{VersionSheetFileds.Type.GetFieldName(migration.NamingScheme)}=@Type", new { Type = (int)VersionType.Sheet })
                .Where($"{VersionSheetFileds.Name.GetFieldName(migration.NamingScheme)}=@Name", new { migration.Name })
                .Where($"{VersionSheetFileds.IsDeleted.GetFieldName(migration.NamingScheme)}=@IsDeleted", new { IsDeleted = false })
                .Max<ulong>(VersionSheetFileds.Serial.GetFieldName(migration.NamingScheme));
            if (compare == 0)
            {
                if (current != actual_serial)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (compare == 1)
            {
                if (current <= actual_serial)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (compare == -1)
            {
                if (current >= actual_serial)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return res;
        }
    }
}
