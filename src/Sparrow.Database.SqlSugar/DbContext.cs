using Microsoft.Extensions.Logging;
using SqlSugar;
using System;

namespace Sparrow.Database.SqlSugar
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public abstract class DbContext : IDisposable
    {
        private readonly DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
        /// <summary>
        /// 数据库客户端
        /// </summary>
        public readonly SqlSugarClient SugarClient;
        /// <summary>
        /// 数据库上下文
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public DbContext()
        {
            OnConfiguring(builder);
            if (builder.Connection is null)
            {
                throw new ArgumentNullException(nameof(builder.Connection));
            }
            SugarClient = new SqlSugarClient(builder.Connection);
            SugarClient.Aop.OnLogExecuting = (previewSql, parameters) =>
            {
                var sql = previewSql;
                if (parameters != null && parameters.Length > 0)
                {
                    sql += "\nparameters is:";
                }
                foreach (var parameter in parameters)
                {
                    sql += $"\nname:{parameter.ParameterName};value:{parameter.Value}";
                }
                ExectionSql(sql);
            };
        }

        /// <summary>
        /// 配置DbContext
        /// </summary>
        /// <param name="builder"></param>
        protected internal abstract void OnConfiguring(DbContextOptionsBuilder builder);

        /// <summary>
        /// 打印日志
        /// </summary>
        /// <param name="sql"></param>
        protected virtual void ExectionSql(string sql)
        {
            StaticValues.Logger.LogDebug(sql);
        }

        /// <summary>
        /// 销毁
        /// </summary>
        public void Dispose()
        {
            SugarClient.Dispose();
        }
    }
}
