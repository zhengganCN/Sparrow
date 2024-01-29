using Sparrow.Database.Interface;
using Sparrow.Database.SqlSugar.Interfaces;
using Sparrow.Database.SqlSugar.Models;
using System;

namespace Sparrow.Database.SqlSugar.Migrations
{
    /// <summary>
    /// 默认<see cref=" ISparrowDatabaseMigration"/>实现，驼峰命名法
    /// </summary>
    public abstract class SparrowHumpDatabaseMigration : ISparrowDatabaseMigration
    {

        /// <summary>
        /// 获取数据库上下文
        /// </summary>
        /// <typeparam name="D">数据库上下文</typeparam>
        /// <returns></returns>
        public DbContext GetDbContext<D>() where D : IDbContext, new()
        {
            return new D() as DbContext;
        }

        /// <summary>
        /// 获取已同步的最新的数据库版本号
        /// </summary>
        /// <param name="context">数据库上下文</param>
        /// <param name="options">数据库迁移配置项</param>
        /// <returns></returns>
        public Migration GetSyncDatabaseVersion(DbContext context, Migration options)
        {
            return context.SugarClient.Queryable<SparrowVersion>().AS(options.table_name)
                .Where(e => e.Name == options.name)
                .Where(e => e.IsDeleted == false)
                .OrderByDescending(e => e.Serial)
                .Select(e => new Migration
                {
                    major = e.Major,
                    minor = e.Minor,
                    name = e.Name,
                    revision = e.Revision,
                    temporary = e.Temporary
                })
                .First();
        }

        /// <summary>
        /// 判断版本表是否存在
        /// </summary>
        /// <param name="context">数据库上下文</param>
        /// <param name="options">数据库迁移配置项</param>
        /// <returns></returns>
        public bool ExistVersionTable(DbContext context, Migration options)
        {
            return context.SugarClient.DbMaintenance.IsAnyTable(options.table_name);
        }

        /// <summary>
        /// 创建版本表
        /// </summary>
        /// <param name="context">数据库上下文</param>
        /// <param name="options">数据库迁移配置项</param>
        /// <returns></returns>
        public bool CreateVersionTable(DbContext context, Migration options)
        {
            context.SugarClient.CodeFirst.As<SparrowVersion>(options.table_name).InitTables<SparrowVersion>();
            return true;
        }

        /// <summary>
        /// 新增已同步到数据库的版本数据
        /// </summary>
        /// <param name="context">数据库上下文</param>
        /// <param name="options">数据库迁移配置项</param>
        /// <returns></returns>
        public bool InsertVersionData(DbContext context, Migration options)
        {
            var version = new SparrowVersion
            {
                Major = options.major,
                Minor = options.minor,
                Revision = options.revision,
                Temporary = options.temporary,
                Name = options.name,
                Serial = Migration.ComputerVersionSeria(options.major, options.minor, options.revision, options.temporary),
                CreateTime = DateTime.Now,
                Creator = "system",
                IsDeleted = false
            };
            context.SugarClient.Insertable(version).AS(options.table_name).ExecuteReturnSnowflakeId();
            return true;
        }

        /// <summary>
        /// 判断数据库版本是否需要更新
        /// </summary>
        /// <param name="current">当前版本信息</param>
        /// <param name="version">数据库中最新版本信息</param>
        /// <returns></returns>
        public bool CanUpdateVersion(Migration current, Migration version)
        {
            return current.Compare(version) > 0;
        }

        /// <summary>
        /// 执行版本同步
        /// </summary>
        /// <param name="options">版本信息</param>
        /// <typeparam name="D">数据库上下文</typeparam>
        public bool Execute<D>(Migration options) where D : IDbContext, new()
        {
            using var context = GetDbContext<D>();
            if (!ExistVersionTable(context, options))
            {
                if (!CreateVersionTable(context, options))
                {
                    return false;
                }
            }
            var sync_version = GetSyncDatabaseVersion(context, options);
            if (sync_version is null || CanUpdateVersion(options, sync_version))
            {
                if (!ExcuteBeforeDatabaseSynchronous())
                {
                    return false;
                }
                if (!ExcuteDatabaseSynchronous())
                {
                    return false;
                }
                if (!ExcuteAfterDatabaseSynchronous())
                {
                    return false;
                }
                if (InsertVersionData(context, options))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 在表同步之前执行
        /// </summary>
        public virtual bool ExcuteBeforeDatabaseSynchronous()
        {
            return true;
        }
        /// <summary>
        /// 表同步执行
        /// </summary>
        public virtual bool ExcuteDatabaseSynchronous()
        {
            return true;
        }
        /// <summary>
        /// 在表同步之后执行
        /// </summary>
        public virtual bool ExcuteAfterDatabaseSynchronous()
        {
            return true;
        }
    }
}
