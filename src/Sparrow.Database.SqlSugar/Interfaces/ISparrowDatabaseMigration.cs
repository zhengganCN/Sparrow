using Sparrow.Database.Interface;
using Sparrow.Database.SqlSugar.Models;

namespace Sparrow.Database.SqlSugar.Interfaces
{
    /// <summary>
    /// 数据库迁移接口
    /// </summary>
    public interface ISparrowDatabaseMigration
    {
        /// <summary>
        /// 获取数据库上下文
        /// </summary>
        /// <typeparam name="D">数据库上下文</typeparam>
        /// <returns></returns>
        DbContext GetDbContext<D>() where D : IDbContext, new();
        /// <summary>
        /// 获取已同步的最新的数据库版本号
        /// </summary>
        /// <param name="context">数据库上下文</param>
        /// <param name="options">数据库迁移配置项</param>
        /// <returns></returns>
        Migration GetSyncDatabaseVersion(DbContext context, Migration options);
        /// <summary>
        /// 判断版本表是否存在
        /// </summary>
        /// <param name="context">数据库上下文</param>
        /// <param name="options">数据库迁移配置项</param>
        /// <returns></returns>
        bool ExistVersionTable(DbContext context, Migration options);
        /// <summary>
        /// 创建版本表
        /// </summary>
        /// <param name="context">数据库上下文</param>
        /// <param name="options">数据库迁移配置项</param>
        /// <returns></returns>
        bool CreateVersionTable(DbContext context, Migration options);
        /// <summary>
        /// 新增已同步到数据库的版本数据
        /// </summary>
        /// <param name="context">数据库上下文</param>
        /// <param name="options">当前版本</param>
        /// <returns></returns>
        bool InsertVersionData(DbContext context, Migration options);
        /// <summary>
        /// 判断数据库版本是否需要更新
        /// </summary>
        /// <param name="options">数据库迁移配置项</param>
        /// <param name="version">数据库中最新版本信息</param>
        /// <returns></returns>
        bool CanUpdateVersion(Migration options, Migration version);
        /// <summary>
        /// 执行版本同步
        /// </summary>
        /// <typeparam name="D">数据库上下文</typeparam>
        /// <param name="options">数据库迁移配置项</param>
        /// <returns></returns>
        bool Execute<D>(Migration options) where D : IDbContext, new();
        /// <summary>
        /// 在表同步之前执行
        /// </summary>
        bool ExcuteBeforeDatabaseSynchronous();
        /// <summary>
        /// 表同步执行
        /// </summary>
        bool ExcuteDatabaseSynchronous();
        /// <summary>
        /// 在表同步之后执行
        /// </summary>
        bool ExcuteAfterDatabaseSynchronous();
    }
}
