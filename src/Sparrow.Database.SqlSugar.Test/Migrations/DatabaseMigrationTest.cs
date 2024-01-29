using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Sparrow.Database.SqlSugar.Models;

namespace Sparrow.Database.SqlSugar.Test.Migrations
{
    internal class DatabaseMigrationTest
    {
        [Test]
        public void MigrationTest()
        {
            IServiceCollection services = new ServiceCollection();
            using var context = new DemoDbContext();
            var names = new string[] { "", "migration", "computer" };
            var hump_tables = new string[] { "", "TestVersion", "MigrationVer" };
            var snake_tables = new string[] { "", "test_version", "migration_ver" };
            var table = "";
            for (int migration_type = 1; migration_type < 3; migration_type++)
            {
                for (int i = 0; i < hump_tables.Length; i++)
                {
                    if (migration_type == 1)
                    {
                        table = hump_tables[i];
                    }
                    else
                    {
                        table = snake_tables[i];
                    }
                    foreach (var name in names)
                    {
                        services.ExecuteMigration(1, context, new Migration(1, 0, 0, 0, name), 0, migration_type, table);
                        services.ExecuteMigration(1, context, new Migration(1, 0, 1, 0, name), 0, migration_type, table);
                        services.ExecuteMigration(1, context, new Migration(1, 0, 0, 5, name), 1, migration_type, table);
                        services.ExecuteMigration(1, context, new Migration(1, 1, 0, 0, name), 0, migration_type, table);
                    }
                    DeleteMigrationData(context, migration_type, table);
                    foreach (var name in names)
                    {
                        services.ExecuteMigration(2, context, new Migration(1, 0, 0, 0, name), 0, migration_type, table);
                        services.ExecuteMigration(2, context, new Migration(1, 0, 1, 0, name), 0, migration_type, table);
                        services.ExecuteMigration(2, context, new Migration(1, 0, 0, 5, name), 1, migration_type, table);
                        services.ExecuteMigration(2, context, new Migration(1, 1, 0, 0, name), 0, migration_type, table);
                    }
                    DeleteMigrationData(context, migration_type, table);

                    foreach (var name in names)
                    {
                        services.ExecuteMigration(3, context, new Migration(1, 0, 0, 0, name), 0, migration_type, table);
                        services.ExecuteMigration(3, context, new Migration(1, 0, 1, 0, name), -1, migration_type, table);
                        services.ExecuteMigration(3, context, new Migration(2, 0, 0, 0, name), 0, migration_type, table);
                        services.ExecuteMigration(3, context, new Migration(1, 1, 0, 0, name), 1, migration_type, table);
                    }
                    DeleteMigrationData(context, migration_type, table);

                    foreach (var name in names)
                    {
                        services.ExecuteMigration(4, context, new Migration(1, 0, 0, 0, name), 0, migration_type, table);
                        services.ExecuteMigration(4, context, new Migration(1, 0, 1, 0, name), -1, migration_type, table);
                        services.ExecuteMigration(4, context, new Migration(2, 0, 0, 0, name), 0, migration_type, table);
                        services.ExecuteMigration(4, context, new Migration(1, 1, 0, 0, name), 1, migration_type, table);
                    }
                    DeleteMigrationData(context, migration_type, table);

                    foreach (var name in names)
                    {
                        services.ExecuteMigration(5, context, new Migration(1, 0, 0, 0, name), 0, migration_type, table);
                        services.ExecuteMigration(5, context, new Migration(1, 0, 1, 0, name), 0, migration_type, table);
                        services.ExecuteMigration(5, context, new Migration(1, 0, 0, 5, name), 1, migration_type, table);
                        services.ExecuteMigration(5, context, new Migration(1, 1, 0, 0, name), 0, migration_type, table);
                    }
                    DeleteMigrationData(context, migration_type, table);

                    foreach (var name in names)
                    {
                        services.ExecuteMigration(6, context, new Migration(1, 0, 0, 0, name), 0, migration_type, table);
                        services.ExecuteMigration(6, context, new Migration(1, 0, 1, 0, name), 0, migration_type, table);
                        services.ExecuteMigration(6, context, new Migration(1, 0, 0, 5, name), 1, migration_type, table);
                        services.ExecuteMigration(6, context, new Migration(1, 1, 0, 0, name), 0, migration_type, table);
                    }
                    DeleteMigrationData(context, migration_type, table);
                }
            }
        }

        private static void DeleteMigrationData(DemoDbContext context, int migration_type, string table)
        {
            switch (migration_type)
            {
                case 1:
                    table = string.IsNullOrWhiteSpace(table) ? nameof(SparrowVersion) : table;
                    context.SugarClient.Deleteable<SparrowVersion>().AS(table).Where(e => e.Id > 0).ExecuteCommand();
                    break;
                case 2:
                    table = string.IsNullOrWhiteSpace(table) ? nameof(sparrow_version) : table;
                    context.SugarClient.Deleteable<sparrow_version>().AS(table).Where(e => e.id > 0).ExecuteCommand();
                    break;
            }
        }
    }

    public static class MigrationTestExtensions
    {

        public static void ExecuteMigration(this IServiceCollection services, int type, DemoDbContext context, Migration migration, int compare, int migration_type, string table)
        {
            if (migration_type == 1)
            {
                switch (type)
                {
                    case 1:
                        services.AddSparrowHumpDatabaseMigration<DemoHumpMigration, DemoDbContext>(migration, table);
                        break;
                    case 2:
                        services.AddSparrowHumpDatabaseMigration<DemoHumpMigration, DemoDbContext>(options =>
                        {
                            options.major = migration.major;
                            options.minor = migration.minor;
                            options.revision = migration.revision;
                            options.temporary = migration.temporary;
                            options.name = migration.name;
                        }, table);
                        break;
                    case 3:
                        services.AddSparrowHumpDatabaseMigration<DemoHumpMigration, DemoDbContext>(migration.major, migration.name, table);
                        break;
                    case 4:
                        services.AddSparrowHumpDatabaseMigration<DemoHumpMigration, DemoDbContext>(migration.major, migration.minor, migration.name, table);
                        break;
                    case 5:
                        services.AddSparrowHumpDatabaseMigration<DemoHumpMigration, DemoDbContext>(migration.major, migration.minor, migration.revision, migration.name, table);
                        break;
                    case 6:
                        services.AddSparrowHumpDatabaseMigration<DemoHumpMigration, DemoDbContext>(migration.major, migration.minor, migration.revision, migration.temporary, migration.name, table);
                        break;
                    default:
                        break;
                }
                Assert.True(GetHumpNewestSparrowVersion(context, migration, table) == compare);
            }
            else if (migration_type == 2)
            {
                switch (type)
                {
                    case 1:
                        services.AddSparrowSnakeDatabaseMigration<DemoSnakeMigration, DemoDbContext>(migration, table);
                        break;
                    case 2:
                        services.AddSparrowSnakeDatabaseMigration<DemoSnakeMigration, DemoDbContext>(options =>
                        {
                            options.major = migration.major;
                            options.minor = migration.minor;
                            options.revision = migration.revision;
                            options.temporary = migration.temporary;
                            options.name = migration.name;
                        }, table);
                        break;
                    case 3:
                        services.AddSparrowSnakeDatabaseMigration<DemoSnakeMigration, DemoDbContext>(migration.major, migration.name, table);
                        break;
                    case 4:
                        services.AddSparrowSnakeDatabaseMigration<DemoSnakeMigration, DemoDbContext>(migration.major, migration.minor, migration.name, table);
                        break;
                    case 5:
                        services.AddSparrowSnakeDatabaseMigration<DemoSnakeMigration, DemoDbContext>(migration.major, migration.minor, migration.revision, migration.name, table);
                        break;
                    case 6:
                        services.AddSparrowSnakeDatabaseMigration<DemoSnakeMigration, DemoDbContext>(migration.major, migration.minor, migration.revision, migration.temporary, migration.name, table);
                        break;
                    default:
                        break;
                }
                Assert.True(GetSnakeNewestSparrowVersion(context, migration, table) == compare);
            }
        }

        private static int GetHumpNewestSparrowVersion(DemoDbContext context, Migration migration, string table)
        {
            migration.name = string.IsNullOrWhiteSpace(migration.name) ? "database" : migration.name;
            table = string.IsNullOrWhiteSpace(table) ? nameof(SparrowVersion) : table;
            var current = context.SugarClient.Queryable<SparrowVersion>().AS(table)
                .Where(e => e.Name == migration.name)
                .Where(e => e.IsDeleted == false)
                .OrderByDescending(e => e.Serial)
                .Select(e => new Migration
                {
                    major = e.Major,
                    minor = e.Minor,
                    revision = e.Revision,
                    temporary = e.Temporary,
                    name = migration.name
                })
                .First();
            return current.Compare(migration);
        }

        private static int GetSnakeNewestSparrowVersion(DemoDbContext context, Migration migration, string table)
        {
            migration.name = string.IsNullOrWhiteSpace(migration.name) ? "database" : migration.name;
            table = string.IsNullOrWhiteSpace(table) ? nameof(sparrow_version) : table;
            var current = context.SugarClient.Queryable<sparrow_version>().AS(table)
                .Where(e => e.name == migration.name)
                .Where(e => e.is_deleted == false)
                .OrderByDescending(e => e.serial)
                .Select(e => new Migration
                {
                    major = e.major,
                    minor = e.minor,
                    revision = e.revision,
                    temporary = e.temporary,
                    name = migration.name
                })
                .First();
            return current.Compare(migration);
        }
    }
}
