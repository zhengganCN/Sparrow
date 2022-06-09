using SqlSugar;

namespace Sparrow.Database.SqlSugar
{
    /// <summary>
    /// 数据库可选配置
    /// </summary>
    public class DbContextOptionsBuilder
    {
        internal ConnectionConfig Connection;
        /// <summary>
        /// 设置数据库连接
        /// </summary>
        /// <param name="connection"></param>
        public void SetConnectionConfig(ConnectionConfig connection)
        {
            Connection = connection;
        }
    }
}
