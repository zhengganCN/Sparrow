using Microsoft.Extensions.Options;
using Sparrow.Database.SqlSugar.Migrations;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparrow.Database.SqlSugar.Extensions
{
    /// <summary>
    /// DbContext扩展
    /// </summary>
    public static class SparrowDbContextExtensions
    {
        /// <summary>
        /// 获取并实例化仓储类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context"></param>
        /// <returns></returns>
        public static T Repository<T>(this DbContext context) where T : AbstractSparrowRepository, new()
        {
            var repository = new T
            {
                Context = context
            };
            return repository;
        }

        internal static void InsertVersionMigrationData(this DbContext context, Dictionary<string, object> version, MigrationOptions options)
        {
            context.SugarClient.Insertable(version).AS(options.SheetName).ExecuteCommand();
        }

        /// <summary>
        /// 迁移数据库视图
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="context">数据库上下文</param>
        /// <param name="options">迁移选项</param>
        /// <returns></returns>
        public static void InitView<T>(this DbContext context, MigrationOptions options) where T : AbstractSparrowView, new()
        {
            var define = new T();
            var sql = define.DefineView(context, out string name, out SparrowVersion version);
            var actual_serial = context.SugarClient.Queryable<object>().AS(options.SheetName)
                .Where($"{VersionSheetFileds.Type.GetFieldName(options.NamingScheme)}=@Type", new { Type = (int)VersionType.View })
                .Where($"{VersionSheetFileds.Name.GetFieldName(options.NamingScheme)}=@Name", new { Name = name })
                .Where($"{VersionSheetFileds.Deleted.GetFieldName(options.NamingScheme)}=@Deleted", new { Deleted = "N" })
                .Max<ulong>(VersionSheetFileds.Serial.GetFieldName(options.NamingScheme));
            var s = context.SugarClient.Queryable<object>().AS(options.SheetName)
               .Where($"{VersionSheetFileds.Type.GetFieldName(options.NamingScheme)}=@Type", new { Type = (int)VersionType.View })
               .Where($"{VersionSheetFileds.Name.GetFieldName(options.NamingScheme)}=@Name", new { Name = name })
               .Where($"{VersionSheetFileds.Deleted.GetFieldName(options.NamingScheme)}=@Deleted", new { Deleted = "N" })
               .ToSqlString();
            var serial = version.ComputerVersionSeria();
            if (serial > actual_serial)
            {
                var id = SnowFlakeSingle.Instance.NextId();
                var view_version = new Dictionary<string, object>
                {
                    { VersionSheetFileds.Id.GetFieldName(options.NamingScheme), id },
                    { VersionSheetFileds.Major.GetFieldName(options.NamingScheme), (long)version.Major },
                    { VersionSheetFileds.Minor.GetFieldName(options.NamingScheme), (long)version.Minor },
                    { VersionSheetFileds.Revision.GetFieldName(options.NamingScheme), (long)version.Revision },
                    { VersionSheetFileds.Temporary.GetFieldName(options.NamingScheme), (long)version.Temporary },
                    { VersionSheetFileds.Name.GetFieldName(options.NamingScheme), name },
                    { VersionSheetFileds.Type.GetFieldName(options.NamingScheme), (int)VersionType.View },
                    { VersionSheetFileds.Serial.GetFieldName(options.NamingScheme),  (long)serial },
                    { VersionSheetFileds.Content.GetFieldName(options.NamingScheme), sql },
                    { VersionSheetFileds.CreateTime.GetFieldName(options.NamingScheme), DateTime.Now },
                    { VersionSheetFileds.Creator.GetFieldName(options.NamingScheme), "system" },
                    { VersionSheetFileds.Deleted.GetFieldName(options.NamingScheme), "N" }
                };

                context.InsertVersionMigrationData(view_version, options);
                bool success;
                try
                {
                    var views = context.SugarClient.DbMaintenance.GetViewInfoList(false);
                    if (views.Where(e => e.Name.ToLower() == name.ToLower()).Any())
                    {
                        context.SugarClient.DbMaintenance.DropView(name);
                    }
                    context.SugarClient.Ado.ExecuteCommand($"create view {name} as \r\n" + sql);
                    success = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    success = false;
                }
                if (success == false)
                {
                    context.SugarClient.Updateable<object>().AS(options.SheetName)
                        .SetColumns(VersionSheetFileds.Deleted.GetFieldName(options.NamingScheme), "Y")
                        .Where($"{VersionSheetFileds.Id.GetFieldName(options.NamingScheme)}=@Id", new { Id = id })
                        .ExecuteCommand();
                }
            }
        }
    }
}
