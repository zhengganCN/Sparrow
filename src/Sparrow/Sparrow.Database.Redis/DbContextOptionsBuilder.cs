using StackExchange.Redis;

namespace Sparrow.Database.Redis
{
    /// <summary>
    /// Redis配置项
    /// </summary>
    public class DbContextOptionsBuilder
    {
        internal ConfigurationOptions ConfigurationOptions = new ConfigurationOptions();

        /// <summary>
        /// 设置Redis连接
        /// </summary>
        /// <param name="host">主机地址</param>
        /// <param name="port">端口，默认为6379</param>
        /// <returns></returns>
        public virtual DbContextOptionsBuilder SetConnect(string host, int port = 6379)
        {
            ConfigurationOptions = ConfigurationOptions.Parse(host + ":" + port);
            return this;
        }
        /// <summary>
        /// 设置Redis连接
        /// </summary>
        /// <param name="host">主机地址</param>
        /// <param name="password">密码</param>
        /// <param name="port">端口，默认为6379</param>
        /// <returns></returns>
        public virtual DbContextOptionsBuilder SetConnect(string host, string password, int port = 6379)
        {
            SetConnect(host, port);
            ConfigurationOptions.Password = password;
            return this;
        }
        /// <summary>
        /// 设置Redis连接
        /// </summary>
        /// <param name="configuration">配置</param>
        /// <returns></returns>
        public virtual DbContextOptionsBuilder SetConfigurationOptions(ConfigurationOptions configuration)
        {
            ConfigurationOptions = configuration;
            return this;
        }
    }
}
