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
                ConnectionString = "Data Source=dostudy.top;Initial Catalog=BackgroundManager.Dev;User ID=sa;Password=yR8DFEYZPfQk9ExzfrKx;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False",
                DbType = DbType.SqlServer
            });
        }
    }
}
