namespace Sparrow.Database.Migration
{
    /// <summary>
    /// 数据库迁移接口
    /// </summary>
    public interface ISparrowDatabaseMigration<T> where T : class, ISparrowVersion, new()
    {
        /// <summary>
        /// 判断版本表是否存在
        /// </summary>
        /// <returns></returns>
        bool ExistVersionTable();
        /// <summary>
        /// 获取当前版本
        /// </summary>
        /// <param name="name">版本名称</param>
        /// <returns></returns>
        ISparrowVersion GetCurrentVersion(string name);
        /// <summary>
        /// 保存当前版本
        /// </summary>
        /// <param name="version"></param>
        void SaveCurrentVersion(T version);
        /// <summary>
        /// 在表同步之前执行
        /// </summary>
        void ExcuteBeforeDatabaseSynchronous();
        /// <summary>
        /// 表同步执行
        /// </summary>
        void ExcuteDatabaseSynchronous();
        /// <summary>
        /// 在表同步之后执行
        /// </summary>
        void ExcuteAfterDatabaseSynchronous();
    }
}
