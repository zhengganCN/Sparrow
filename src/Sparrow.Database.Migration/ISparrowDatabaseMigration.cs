namespace Sparrow.Database.Migration
{
    /// <summary>
    /// 数据库迁移接口
    /// </summary>
    public interface ISparrowDatabaseMigration
    {
        /// <summary>
        /// 判断版本表是否存在
        /// </summary>
        /// <returns></returns>
        bool ExistVersionTable<V>() where V : class, ISparrowVersion, new();
        /// <summary>
        /// 获取当前版本
        /// </summary>
        /// <param name="name">版本名称</param>
        /// <returns></returns>
        ISparrowVersion GetCurrentVersion<V>(string name) where V : class, ISparrowVersion, new();
        /// <summary>
        /// 保存当前版本
        /// </summary>
        /// <param name="version"></param>
        void SaveCurrentVersion<V>(V version) where V : class, ISparrowVersion, new();
        /// <summary>
        /// 在表同步之前执行
        /// </summary>
        void ExcuteBeforeDatabaseSynchronous<V>(V version) where V : class, ISparrowVersion, new();
        /// <summary>
        /// 表同步执行
        /// </summary>
        void ExcuteDatabaseSynchronous<V>(V version) where V : class, ISparrowVersion, new();
        /// <summary>
        /// 在表同步之后执行
        /// </summary>
        void ExcuteAfterDatabaseSynchronous<V>(V version) where V : class, ISparrowVersion, new();
    }
}
