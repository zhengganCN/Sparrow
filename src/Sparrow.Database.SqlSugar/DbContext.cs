using SqlSugar;
using System;

namespace Sparrow.Database.SqlSugar
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public abstract class DbContext : IDbContext, IDisposable
    {
        private readonly DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
        private bool isInitialization = false;
        private SqlSugarClient client;
        /// <summary>
        /// 数据库客户端
        /// </summary>
        public SqlSugarClient SugarClient
        {
            get
            {
                if (isInitialization)
                {
                    return client;
                }
                OnConfiguring(builder);
                if (builder.Connection is null)
                {
                    throw new ArgumentNullException(nameof(builder.Connection));
                }
                client = new SqlSugarClient(builder.Connection);
                client.Aop.OnLogExecuting = ExectionSql;
                SetSqlSugarClient(client);
                isInitialization = true;
                return client;
            }
        }

        /// <summary>
        /// 配置DbContext
        /// </summary>
        /// <param name="builder"></param>
        protected internal abstract void OnConfiguring(DbContextOptionsBuilder builder);

        /// <summary>
        /// 设置SqlSugarClient
        /// </summary>
        /// <param name="client">SqlSugarClient</param>
        protected virtual void SetSqlSugarClient(SqlSugarClient client)
        {
        }

        /// <summary>
        /// 打印日志
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">sql参数</param>
        protected virtual void ExectionSql(string sql, SugarParameter[] parameters)
        {
            if (parameters != null && parameters.Length > 0)
            {
                sql += "\nparameters is: ";
            }
            foreach (var parameter in parameters)
            {
                sql += $"\nname: {parameter.ParameterName}; value: {parameter.Value}";
            }
            Console.WriteLine(sql);
        }

        /// <summary>
        /// 销毁
        /// </summary>
        public void Dispose()
        {
            SugarClient?.Dispose();
        }
    }
}
