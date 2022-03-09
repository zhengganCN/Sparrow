using System;
using Microsoft.Extensions.Logging;
using SqlSugar;

namespace Sparrow.Database.SqlSugar
{
    public abstract class DbContext : IDisposable
    {
        private static readonly ILogger<DbContext> _logger = new LoggerFactory().CreateLogger<DbContext>();
        private readonly DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
        private readonly SqlSugarClient Client;

        public DbContext()
        {
            OnConfiguring(builder);
            if (builder.Connection is null)
            {
                throw new ArgumentNullException(nameof(builder.Connection));
            }
            Client = new SqlSugarClient(builder.Connection);
            Client.Aop.OnLogExecuting = (previewSql, parameters) =>
            {
                var sql = previewSql;
                foreach (var parameter in parameters)
                {
                    sql += parameter.Value;
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
            _logger.LogDebug(sql);
        }

        public void Dispose()
        {
            Client.Dispose();
        }
    }
}
