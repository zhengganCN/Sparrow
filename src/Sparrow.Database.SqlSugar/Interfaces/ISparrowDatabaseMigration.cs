using Sparrow.Database.SqlSugar.Migrations;

namespace Sparrow.Database.SqlSugar.Interfaces
{
    /// <summary>
    /// 数据库迁移接口
    /// </summary>
    public interface ISparrowDatabaseMigration
    {
        /// <summary>
        /// 在表同步之前执行
        /// </summary>
        /// <param name="options">迁移选项</param>
        bool ExcuteBeforeDatabaseSynchronous(MigrationOptions options);
        /// <summary>
        /// 表同步执行
        /// </summary>
        /// <param name="options">迁移选项</param>
        bool ExcuteDatabaseSynchronous(MigrationOptions options);
        /// <summary>
        /// 在表同步之后执行
        /// </summary>
        /// <param name="options">迁移选项</param>
        bool ExcuteAfterDatabaseSynchronous(MigrationOptions options);
        /// <summary>
        /// 视图同步执行
        /// </summary>
        /// <param name="options">迁移选项</param>
        bool ExcuteViewSynchronous(MigrationOptions options);
    }
}
