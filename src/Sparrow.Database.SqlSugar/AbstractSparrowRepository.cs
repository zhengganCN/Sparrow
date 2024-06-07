namespace Sparrow.Database.SqlSugar
{
    /// <summary>
    /// 抽象仓储类
    /// </summary>
    public abstract class AbstractSparrowRepository
    {
        /// <summary>
        /// 数据库上下文
        /// </summary>
        public DbContext Context { get; set; }
    }
}
