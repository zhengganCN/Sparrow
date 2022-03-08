namespace Sparrow.Database.Redis
{
    /// <summary>
    /// Redis上下文配置项
    /// </summary>
    public class DbContextOptionsBuilder
    {
        internal string SslHost { get; set; }
        internal string Password { get; set; }
        internal int Db { get; set; }
        /// <summary>
        /// 设置Redis连接地址
        /// </summary>
        /// <param name="host">主机地址</param>
        /// <param name="port">端口，默认为6379</param>
        /// <returns></returns>
        public virtual DbContextOptionsBuilder SetConnect(string host, int port = 6379)
        {
            SslHost = host + ":" + port;
            return this;
        }
        /// <summary>
        /// 设置Redis连接密码
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public virtual DbContextOptionsBuilder SetPassword(string password)
        {
            Password = password;
            return this;
        }
        /// <summary>
        /// 设置Redis连接数据库，默认为 0 
        /// </summary>
        /// <param name="db">数据库序号，默认为 0</param>
        /// <returns></returns>
        public virtual DbContextOptionsBuilder SetDb(int db = 0)
        {
            Db = db;
            return this;
        }
    }
}
