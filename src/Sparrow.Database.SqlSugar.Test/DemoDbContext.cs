using Sparrow.Database.SqlSugar.Test.Entities;
using SqlSugar;
using System;

namespace Sparrow.Database.SqlSugar.Test
{
    internal class DemoDbContext : DbContext
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

        /// <summary>
        /// 地区表
        /// </summary>
        public DbSet<EntityDistricts> Districts { get; set; }
    }
}
