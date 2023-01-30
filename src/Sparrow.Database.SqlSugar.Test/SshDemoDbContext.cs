using SqlSugar;
using System;

namespace Sparrow.Database.SqlSugar.Test
{
    internal class SshDemoDbContext : DbContext
    {

        protected override void ExectionSql(string sql, SugarParameter[] parameters)
        {
            Console.WriteLine(sql);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var ip = "xxx.xxx.xxx.xxx";
            var user = "xxx";
            var password = "xxxxxxxx";
            var port = 3306;
            var name = "xxxxxxxxxxxxxx";
            var connection = new ConnectionConfig
            {
                DbType = DbType.MySql,
                ConnectionString = $"server={ip};uid={user};pwd={password};port={port};database={name};sslmode=Preferred;CharSet=utf8mb4;"
            };
            var ssh = new SshConfig
            {
                SshHost = "xxx.xxx.xxx.xxx",
                SshUser = "xxxx",
                SshPassword = "xxxxxx",
                SshPort = 22,
                DbHost = ip,
                DbPort = port
            };
            builder.SetConnectionConfig(connection, ssh);
        }
    }
}
