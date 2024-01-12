using Renci.SshNet;
using Sparrow.Database.Interface;
using SqlSugar;
using System;
using System.Linq;

namespace Sparrow.Database.SqlSugar
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public partial class DbContext : IDbContext, IDisposable
    {
        private readonly DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
        private bool isInitialization = false;
        private SqlSugarClient client;
        private SshClient sshClient;
        /// <summary>
        /// 初始化
        /// </summary>
        public DbContext()
        {
            InitSugarClient();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="configure">配置构造器</param>
        public DbContext(Action<DbContextOptionsBuilder> configure)
        {
            configure.Invoke(builder);
            InitSugarClient();
        }

        /// <summary>
        /// 数据库客户端
        /// </summary>
        public SqlSugarClient SugarClient
        {
            get
            {
                return client;
            }
        }

        private void InitSugarClient()
        {
            if (isInitialization)
            {
                return;
            }
            OnConfiguring(builder);
            if (builder.Connection is null)
            {
                throw new ArgumentNullException(nameof(builder.Connection));
            }
            client = new SqlSugarClient(builder.Connection);
            client.Aop.OnLogExecuting = ExectionSql;
            SetSqlSugarClient(client);
            InitDbSets();
            SshConnect();
            isInitialization = true;
        }

        /// <summary>
        /// 配置DbContext
        /// </summary>
        /// <param name="builder">配置构造器</param>
        protected virtual void OnConfiguring(DbContextOptionsBuilder builder)
        {

        }

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
        /// 初始化DbSet属性
        /// </summary>
        private void InitDbSets()
        {
            var properties = GetType().GetProperties();
            var dbsets = properties.Where(e => e.PropertyType.Name == typeof(DbSet<>).Name).ToList();
            foreach (var dbset in dbsets)
            {
                // 使用 Activator.CreateInstance 方法创建泛型实例
                object instance = Activator.CreateInstance(dbset.PropertyType, client);
                dbset.SetValue(this, instance);
            }
        }

        /// <summary>
        /// 销毁
        /// </summary>
        public void Dispose()
        {
            SugarClient?.Dispose();
            sshClient?.Dispose();
        }
    }
}
