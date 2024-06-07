using SqlSugar;
using System;
using System.IO;

namespace Sparrow.Database.SqlSugar.Test.Migrations
{
    internal class MigrationDbContext : DbContext
    {
        internal static string DatabasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Migration.db");
        protected override void ExectionSql(string sql, SugarParameter[] parameters)
        {
            Console.WriteLine(sql);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.SetConnectionConfig(new ConnectionConfig
            {
                ConnectionString = $"Data Source={DatabasePath};Cache=Shared",
                DbType = DbType.Sqlite
            });
        }
    }
}
