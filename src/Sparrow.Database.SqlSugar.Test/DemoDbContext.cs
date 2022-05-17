using SqlSugar;
using System;

namespace Sparrow.Database.SqlSugar.Test
{
    internal class DemoDbContext : DbContext
    {

        protected override void ExectionSql(string sql)
        {
            Console.WriteLine(sql);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.SetConnectionConfig(new ConnectionConfig
            {
                ConnectionString = "demo",
                DbType = DbType.Sqlite
            });
        }
    }
}
