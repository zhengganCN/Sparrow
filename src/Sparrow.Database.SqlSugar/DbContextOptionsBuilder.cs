using SqlSugar;

namespace Sparrow.Database.SqlSugar
{
    /// <summary>
    /// 数据库可选配置
    /// </summary>
    public class DbContextOptionsBuilder
    {
        internal ConnectionConfig Connection;
        internal SshConfig SshConfig;
        /// <summary>
        /// 设置数据库连接
        /// </summary>
        /// <param name="connection">数据库连接配置</param>
        public void SetConnectionConfig(ConnectionConfig connection)
        {
            Connection = connection;
        }

        /// <summary>
        /// 设置数据库连接
        /// </summary>
        /// <param name="connection">数据库连接配置</param>
        /// <param name="sshConfig">ssh配置</param>
        public void SetConnectionConfig(ConnectionConfig connection, SshConfig sshConfig)
        {
            Connection = connection;
            SshConfig = sshConfig;
        }
    }
}
