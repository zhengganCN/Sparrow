using Sparrow.Database.Interface;
using Sparrow.Database.SqlSugar.Interfaces;
using Sparrow.Database.SqlSugar.Test.Entities;
using SqlSugar;
using System;
using System.Reflection;

namespace Sparrow.Database.SqlSugar.Test.Migration
{
#pragma warning disable CS8604 // 引用类型参数可能为 null。
#pragma warning disable CS8603 // 可能返回 null 引用。
#pragma warning disable CS8602 // 解引用可能出现空引用。
    internal class DefineMigration : ISparrowDatabaseMigration
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
        /// <param name="current">当前版本</param>
        /// <returns></returns>
        public object GetSyncDatabaseVersion(DbContext context, object current)
        {
            var version = current as demo_version;
            return context.SugarClient.Queryable<demo_version>()
                .Where(e => e.name == version.name)
                .Where(e => e.is_deleted == false)
                .OrderByDescending(e => e.serial)
                .First();
        }

        /// <summary>
        /// 判断版本表是否存在
        /// </summary>
        /// <param name="context">数据库上下文</param>
        /// <returns></returns>
        public bool ExistVersionTable(DbContext context)
        {
            string name = "";
            var table = typeof(demo_version).GetCustomAttribute<SugarTable>();
            if (table != null && !string.IsNullOrWhiteSpace(table.TableName))
            {
                name = table.TableName;
            }
            else
            {
                name = nameof(demo_version);
            }
            return context.SugarClient.DbMaintenance.IsAnyTable(name);
        }

        /// <summary>
        /// 创建版本表
        /// </summary>
        /// <param name="context">数据库上下文</param>
        /// <returns></returns>
        public bool CreateVersionTable(DbContext context)
        {
            context.SugarClient.CodeFirst.InitTables<demo_version>();
            return true;
        }

        /// <summary>
        /// 新增已同步到数据库的版本数据
        /// </summary>
        /// <param name="context">数据库上下文</param>
        /// <param name="current">当前版本</param>
        /// <returns></returns>
        public bool InsertVersionData(DbContext context, object current)
        {
            var version = current as demo_version;
            version.serial = SparrowVersionStatic.ComputerVersionSeria(version.major, version.minor, version.revision, version.temporary);
            version.create_time = DateTime.Now;
            version.creator = "system";
            version.is_deleted = false;
            context.SugarClient.Insertable(version).ExecuteReturnSnowflakeId();
            return true;
        }

        /// <summary>
        /// 判断数据库版本是否需要更新
        /// </summary>
        /// <param name="current">当前版本信息</param>
        /// <param name="version">数据库中最新版本信息</param>
        /// <returns></returns>
        public bool CanUpdateVersion(object current, object version)
        {
            var current_entity = current as demo_version;
            var version_entity = version as demo_version;
            return current_entity.Compare(version_entity) > 0;
        }

        /// <summary>
        /// 执行版本同步
        /// </summary>
        /// <param name="current">版本信息</param>
        /// <typeparam name="D">数据库上下文</typeparam>
        public bool Execute<D>(object current) where D : IDbContext, new()
        {
            using var context = GetDbContext<D>();
            if (!ExistVersionTable(context))
            {
                if (!CreateVersionTable(context))
                {
                    return false;
                }
            }
            var sync_version = GetSyncDatabaseVersion(context, current) as demo_version;
            if (sync_version is null || CanUpdateVersion(current, sync_version))
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
                if (InsertVersionData(context, current))
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
        public bool ExcuteBeforeDatabaseSynchronous()
        {
            return true;
        }
        /// <summary>
        /// 表同步执行
        /// </summary>
        public bool ExcuteDatabaseSynchronous()
        {
            return true;
        }
        /// <summary>
        /// 在表同步之后执行
        /// </summary>
        public bool ExcuteAfterDatabaseSynchronous()
        {
            return true;
        }
    }
#pragma warning restore CS8602 // 解引用可能出现空引用。
#pragma warning restore CS8604 // 引用类型参数可能为 null。
#pragma warning restore CS8603 // 可能返回 null 引用。
}
