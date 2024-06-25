using SqlSugar;
using System;

namespace Sparrow.Database.SqlSugar.Test.Migrations
{
    internal class MigrationDbContext : DbContext
    {
        protected override void ExectionSql(string sql, SugarParameter[] parameters)
        {
            Console.WriteLine(sql);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.SetConnectionConfig(new ConnectionConfig
            {
                ConnectionString = AppSettings.DbConnectionString,
                DbType = (DbType)AppSettings.DbType
            });
        }
    }
}
