using Microsoft.Extensions.Configuration;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow.Database.SqlSugar.Test
{
    internal static class AppSettings
    {
        internal static IConfiguration Configuration { get; set; }
        public static int DbType
        {
            get
            {
                var value = Configuration.GetValue<string>("DATASOURCE_DBTYPE");
                int type = value switch
                {
                    "mysql" => 0,
                    "sqlite" => 2,
                    //人大金仓
                    "kingbase" => 6,
                    _ => 0,//默认为mysql数据库
                };
                return type;
            }
        }

        /// <summary>
        /// 数据库配置
        /// </summary>
        public static string DbConnectionString
        {
            get
            {
                var ip = Configuration.GetValue<string>("DATASOURCE_HOST");
                var user = Configuration.GetValue<string>("DATASOURCE_USERNAME");
                var password = Configuration.GetValue<string>("DATASOURCE_PASSWORD");
                var port = Configuration.GetValue<string>("DATASOURCE_PORT");
                var name = Configuration.GetValue<string>("DATASOURCE_DB_NAME");
                if (DbType == 0) //mysql
                {
                    return $"server={ip};uid={user};pwd={password};port={port};database={name};CharSet=utf8mb4;";
                }
                else if (DbType == 2) //sqlite
                {
                    return $"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{name}.db")};Cache=Shared";
                }
                else if (DbType == 6) //kingbase
                {
                    return $"host={ip};username={user};password={password};port={port};database={name};";
                }
                else
                {
                    return "";
                }
            }
        }
    }
}
