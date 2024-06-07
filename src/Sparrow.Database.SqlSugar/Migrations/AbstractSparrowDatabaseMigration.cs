using Sparrow.Database.SqlSugar.Interfaces;

namespace Sparrow.Database.SqlSugar.Migrations
{
    /// <summary>
    /// 默认<see cref=" ISparrowDatabaseMigration"/>实现
    /// </summary>
    public abstract class AbstractSparrowDatabaseMigration : ISparrowDatabaseMigration
    {
        /// <summary>
        /// 在表同步之前执行
        /// </summary>
        /// <param name="options">迁移选项</param>
        public virtual bool ExcuteBeforeDatabaseSynchronous(MigrationOptions options)
        {
            return true;
        }

        /// <summary>
        /// 表同步执行
        /// </summary>
        /// <param name="options">迁移选项</param>
        public virtual bool ExcuteDatabaseSynchronous(MigrationOptions options)
        {
            return true;
        }

        /// <summary>
        /// 在表同步之后执行
        /// </summary>
        /// <param name="options">迁移选项</param>
        public virtual bool ExcuteAfterDatabaseSynchronous(MigrationOptions options)
        {
            return true;
        }

        /// <summary>
        /// 视图同步执行
        /// </summary>
        /// <param name="options">迁移选项</param>
        public virtual bool ExcuteViewSynchronous(MigrationOptions options)
        {
            return true;
        }
    }
}
