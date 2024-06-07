using Sparrow.Database.Interface;
using Sparrow.Database.SqlSugar.Interfaces;
using SqlSugar;
using System;
using System.Collections.Generic;

namespace Sparrow.Database.SqlSugar.Migrations
{
    /// <summary>
    /// 迁移执行器
    /// </summary>
    internal static class MigrationExecute
    {
        /// <summary>
        /// 判断版本表是否存在
        /// </summary>
        /// <param name="context">数据库上下文</param>
        /// <param name="options">数据库迁移配置项</param>
        /// <returns></returns>
        private static bool ExistVersionTable(DbContext context, MigrationOptions options)
        {
            return context.SugarClient.DbMaintenance.IsAnyTable(options.SheetName);
        }

        /// <summary>
        /// 创建版本表
        /// </summary>
        /// <param name="context">数据库上下文</param>
        /// <param name="options">数据库迁移配置项</param>
        /// <returns></returns>
        private static bool CreateVersionTable(DbContext context, MigrationOptions options)
        {
            var builder = context.SugarClient.DynamicBuilder().CreateClass(options.SheetName);
            foreach (var item in VersionSheetFileds.GetSheetFields())
            {
                switch (options.NamingScheme)
                {
                    case NamingScheme.Hump:
                        builder.CreateProperty(item.FieldHumpName, item.FieldType, item.FieldColumn);
                        break;
                    case NamingScheme.Snake:
                        builder.CreateProperty(item.FieldSnakeName, item.FieldType, item.FieldColumn);
                        break;
                }
            }
            //创建类
            var type = builder.BuilderType();//想缓存有typeBilder.WithCache
            //创建表
            context.SugarClient.CodeFirst.InitTables(type);
            return true;
        }

        /// <summary>
        /// 新增已同步到数据库的版本数据
        /// </summary>
        /// <param name="context">数据库上下文</param>
        /// <param name="options">数据库迁移配置项</param>
        /// <returns></returns>
        private static bool InsertVersionData(DbContext context, MigrationOptions options)
        {
            var serial = SparrowVersion.ComputerVersionSeria(options.Major, options.Minor, options.Revision, options.Temporary);
            var version = new Dictionary<string, object>
            {
                { VersionSheetFileds.Id.GetFieldName(options.NamingScheme), $"{SnowFlakeSingle.Instance.NextId()}" },
                { VersionSheetFileds.Major.GetFieldName(options.NamingScheme), options.Major },
                { VersionSheetFileds.Minor.GetFieldName(options.NamingScheme), options.Minor },
                { VersionSheetFileds.Revision.GetFieldName(options.NamingScheme), options.Revision },
                { VersionSheetFileds.Temporary.GetFieldName(options.NamingScheme), options.Temporary },
                { VersionSheetFileds.Name.GetFieldName(options.NamingScheme), options.Name },
                { VersionSheetFileds.Serial.GetFieldName(options.NamingScheme), serial },
                { VersionSheetFileds.Type.GetFieldName(options.NamingScheme), (int)VersionType.Sheet },
                { VersionSheetFileds.CreateTime.GetFieldName(options.NamingScheme), DateTime.Now },
                { VersionSheetFileds.Creator.GetFieldName(options.NamingScheme), "system" },
                { VersionSheetFileds.IsDeleted.GetFieldName(options.NamingScheme), false }
            };
            context.SugarClient.Insertable(version).AS(options.SheetName).ExecuteCommand();
            return true;
        }

        /// <summary>
        /// 判断数据库版本是否需要更新
        /// </summary>
        /// <param name="context">数据库上下文</param>
        /// <param name="options">数据库迁移配置项</param>
        /// <returns></returns>
        private static bool CanUpdateVersion(DbContext context, MigrationOptions options)
        {
            var exist = context.SugarClient.Queryable<object>().AS(options.SheetName)
                .Where($"{VersionSheetFileds.Type.GetFieldName(options.NamingScheme)}=@Type", new { Type = (int)VersionType.Sheet })
                .Where($"{VersionSheetFileds.Name.GetFieldName(options.NamingScheme)}=@Name", new { options.Name })
                .Where($"{VersionSheetFileds.IsDeleted.GetFieldName(options.NamingScheme)}=@IsDeleted", new { IsDeleted = false })
                .Any();
            if (!exist)
            {
                return true;
            }
            var actual_serial = context.SugarClient.Queryable<object>().AS(options.SheetName)
                .Where($"{VersionSheetFileds.Type.GetFieldName(options.NamingScheme)}=@Type", new { Type = (int)VersionType.Sheet })
                .Where($"{VersionSheetFileds.Name.GetFieldName(options.NamingScheme)}=@Name", new { options.Name })
                .Where($"{VersionSheetFileds.IsDeleted.GetFieldName(options.NamingScheme)}=@IsDeleted", new { IsDeleted = false })
                .Max<ulong>(VersionSheetFileds.Serial.GetFieldName(options.NamingScheme));
            return options.ComputerVersionSeria() > actual_serial;
        }

        /// <summary>
        /// 执行迁移
        /// </summary>
        /// <typeparam name="M"></typeparam>
        /// <typeparam name="D"></typeparam>
        /// <param name="options"></param>
        /// <returns></returns>
        internal static bool Execute<M, D>(MigrationOptions options)
            where M : ISparrowDatabaseMigration, new()
            where D : IDbContext, new()
        {
            using var context = new D() as DbContext;
            var migration = new M();
            if (!ExistVersionTable(context, options))
            {
                if (!CreateVersionTable(context, options))
                {
                    return false;
                }
            }
            if (!migration.ExcuteBeforeDatabaseSynchronous(options))
            {
                return false;
            }
            if (CanUpdateVersion(context, options))
            {                
                if (!migration.ExcuteDatabaseSynchronous(options))
                {
                    return false;
                }               
                if (!InsertVersionData(context, options))
                {
                    return false;
                }
            }
            if (!migration.ExcuteAfterDatabaseSynchronous(options))
            {
                return false;
            }
            return migration.ExcuteViewSynchronous(options);
        }
    }
}
