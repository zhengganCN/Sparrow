using SqlSugar;
using System;

namespace Sparrow.Database.SqlSugar.Test
{
    public class DemoDbContext : DbContext
    {

        protected override void ExectionSql(string sql, SugarParameter[] parameters)
        {
            Console.WriteLine(sql);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.SetConnectionConfig(new ConnectionConfig
            {
                ConnectionString = "Data Source=Demo.db;Cache=Shared",
                DbType = DbType.Sqlite
            });
        }
    }
}
