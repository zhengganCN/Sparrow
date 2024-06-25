using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NUnit.Framework;
using Sparrow.Database.SqlSugar.Migrations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Xml.Linq;

namespace Sparrow.Database.SqlSugar.Test.Migrations
{
    internal class DatabaseMigrationTest
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TestCase("sqlite", "[[1,0,0,0],[1,0,0,1],[1,1,0,0]]")]
        [TestCase("mysql", "[[1,0,0,0],[1,0,0,1],[1,1,0,0]]")]
        [TestCase("kingbase", "[[1,0,0,0],[1,0,0,1],[1,1,0,0]]")]
        public void DbTest(string type, string version_string)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "Configs", $"appsettings.{type}.json");
            AppSettings.Configuration = new ConfigurationBuilder().AddJsonFile(path).Build();
            IServiceCollection services = new ServiceCollection();
            var versions = JsonConvert.DeserializeObject<List<List<int>>>(version_string);
            if (versions is null)
            {
                Assert.Fail();
            }
            foreach (var version in versions)
            {                
                services.AddSparrowDatabaseMigration<DemoDatabaseMigration, MigrationDbContext>(options =>
                {
                    options.Major = (ushort)version[0];
                    options.Minor = (ushort)version[1];
                    options.Revision = (ushort)version[2];
                    options.Temporary = (ushort)version[3];
                    options.Name = "bank_database";
                    options.NamingScheme = NamingScheme.Hump;
                    options.SheetName = "bankaccount_db_version";
                });
            }            
        }

        [TestCase("sqlite")]
        public void MigrationTest(string type)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migrations", "Configs", $"appsettings.{type}.json");
            AppSettings.Configuration = new ConfigurationBuilder().AddJsonFile(path).Build();
            File.Delete(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{AppSettings.Configuration.GetValue<string>("DATASOURCE_DB_NAME")}.db"));
            IServiceCollection services = new ServiceCollection();
            var hump_tables = new string[] { "TestVersion", "MigrationVer" };
            var snake_tables = new string[] { "test_version", "migration_ver" };
            var names = new string[] { "migration", "computer" };
            var naming = NamingScheme.Snake;
            MigrationOptions migration;
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
                .Where($"{VersionSheetFileds.Deleted.GetFieldName(migration.NamingScheme)}=@Deleted", new { Deleted = "N" })
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
