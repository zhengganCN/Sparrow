using Microsoft.Extensions.Logging;
using SqlSugar;
using System;

namespace Sparrow.Database.SqlSugar
{
    public abstract class DbContext : IDisposable
    {
        private readonly DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
        public readonly SqlSugarClient SugarClient;

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

        protected virtual void ExectionSql(string sql)
        {
            StaticValues.Logger.LogDebug(sql);
        }

        public void Dispose()
        {
            SugarClient.Dispose();
        }
    }
}
