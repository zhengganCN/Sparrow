namespace Sparrow.Database.SqlSugar
{
    /// <summary>
    /// ssh连接配置
    /// </summary>
    public class SshConfig
    {
        /// <summary>
        /// ssh ip地址
        /// </summary>
        public string SshHost { get; set; }
        /// <summary>
        /// ssh 端口
        /// </summary>
        public int SshPort { get; set; } = 22;
        /// <summary>
        /// ssh 用户
        /// </summary>
        public string SshUser { get; set; }
        /// <summary>
        /// ssh 密码
        /// </summary>
        public string SshPassword { get; set; }
        /// <summary>
        /// 数据库ip
        /// </summary>
        public string DbHost { get; set; }
        /// <summary>
        /// 数据库端口
        /// </summary>
        public int DbPort { get; set; }
    }
}
