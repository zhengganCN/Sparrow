using Renci.SshNet;
using SqlSugar;
using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;

namespace Sparrow.Database.SqlSugar
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public class DbContext : IDbContext, IDisposable
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

        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="configure">配置构造器</param>
        public DbContext(Action<DbContextOptionsBuilder> configure)
        {
            configure.Invoke(builder);
        }

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
                SshConnect();
                return client;
            }
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
        /// 连接ssh
        /// </summary>
        private void SshConnect()
        {
            if (builder.SshConfig is null)
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(builder.SshConfig.SshHost))
            {
                throw new ArgumentNullException(nameof(builder.SshConfig.SshHost));
            }
            int forwardedPort = GetUnActiveTcpPort();
            var loopback = IPAddress.Loopback.ToString();
            ReplaceConnectionString(forwardedPort, loopback);
            var auth = new PasswordAuthenticationMethod(builder.SshConfig.SshUser, builder.SshConfig.SshPassword);
            ConnectionInfo conInfo = new ConnectionInfo(builder.SshConfig.SshHost, (int)builder.SshConfig.SshPort, builder.SshConfig.SshUser, auth);
            sshClient = new SshClient(conInfo);
            var forwarded = new ForwardedPortLocal(loopback, (uint)forwardedPort, builder.SshConfig.DbHost, (uint)builder.SshConfig.DbPort);
            sshClient.Connect();
            if (!sshClient.IsConnected)
            {
                throw new Exception("ssh连接失败");
            }
            sshClient.AddForwardedPort(forwarded);
            forwarded.Start();
        }

        /// <summary>
        /// 替换连接字符串中的ip为本机的回环地址，端口为转发端口
        /// </summary>
        /// <param name="forwardedPort">转发端口</param>
        /// <param name="loopback">本机的回环地</param>
        private void ReplaceConnectionString(int forwardedPort, string loopback)
        {
            var connect = client.CurrentConnectionConfig.ConnectionString;
            var ipRegex = new Regex("(.*)(=)([0-9]*\\.[0-9]*\\.[0-9]*\\.[0-9]*)(.*)");
            connect = ipRegex.Replace(connect, $"$1={loopback}$4");
            var portRegex = new Regex("(.*)(=)([0-9]{4,5})(.*)");
            connect = portRegex.Replace(connect, $"$1={forwardedPort}$4");
            client.CurrentConnectionConfig.ConnectionString = connect;
        }

        /// <summary>
        /// 随机获取未使用的端口
        /// </summary>
        /// <returns></returns>
        private static int GetUnActiveTcpPort()
        {
            var random = new Random();
            var port = random.Next(10000, 65535);
            while (IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpListeners().Any(p => p.Port == port))
            {
                port = random.Next(10000, 65535);
            }
            return port;
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
