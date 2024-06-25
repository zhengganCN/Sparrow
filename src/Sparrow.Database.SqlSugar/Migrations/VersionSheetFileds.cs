using Sparrow.Database.EntityInfo;
using SqlSugar;
using System;
using System.Collections.Generic;

namespace Sparrow.Database.SqlSugar.Migrations
{
    /// <summary>
    /// 版本表-表字段
    /// </summary>
    public static class VersionSheetFileds
    {
        /// <summary>
        /// 主键
        /// </summary>
        public static SheetField Id = new SheetField
        {
            FieldHumpName = "Id",
            FieldSnakeName = "id",
            FieldType = typeof(long),
            FieldColumn = new SugarColumn { IsPrimaryKey = true, Length = 32, ColumnDescription = "主键" }
        };
        /// <summary>
        /// 名称
        /// </summary>
        public static SheetField Name = new SheetField
        {
            FieldHumpName = "Name",
            FieldSnakeName = "name",
            FieldType = typeof(string),
            FieldColumn = new SugarColumn { IsNullable = false, Length = 255, ColumnDescription = "名称" }
        };
        /// <summary>
        /// 版本类型
        /// </summary>
        public static SheetField Type = new SheetField
        {
            FieldHumpName = "Type",
            FieldSnakeName = "type",
            FieldType = typeof(int),
            FieldColumn = new SugarColumn { IsNullable = false, ColumnDescription = "版本类型" }
        };
        /// <summary>
        /// 主版本号
        /// </summary>
        public static SheetField Major = new SheetField
        {
            FieldHumpName = "Major",
            FieldSnakeName = "major",
            FieldType = typeof(ulong),
            FieldColumn = new SugarColumn { IsNullable = false, ColumnDescription = "主版本号" }
        };
        /// <summary>
        /// 子版本号
        /// </summary>
        public static SheetField Minor = new SheetField
        {
            FieldHumpName = "Minor",
            FieldSnakeName = "minor",
            FieldType = typeof(ulong),
            FieldColumn = new SugarColumn { IsNullable = false, ColumnDescription = "子版本号" }
        };
        /// <summary>
        /// 修正版本号
        /// </summary>
        public static SheetField Revision = new SheetField
        {
            FieldHumpName = "Revision",
            FieldSnakeName = "revision",
            FieldType = typeof(ulong),
            FieldColumn = new SugarColumn { IsNullable = false, ColumnDescription = "修正版本号" }
        };
        /// <summary>
        /// 临时版本号
        /// </summary>
        public static SheetField Temporary = new SheetField
        {
            FieldHumpName = "Temporary",
            FieldSnakeName = "temporary",
            FieldType = typeof(ulong),
            FieldColumn = new SugarColumn { IsNullable = false, ColumnDescription = "临时版本号" }
        };
        /// <summary>
        /// 序列
        /// </summary>
        public static SheetField Serial = new SheetField
        {
            FieldHumpName = "Serial",
            FieldSnakeName = "serial",
            FieldType = typeof(ulong),
            FieldColumn = new SugarColumn { IsNullable = false, ColumnDescription = "序列" }
        };
        /// <summary>
        /// 内容
        /// </summary>
        public static SheetField Content = new SheetField
        {
            FieldHumpName = "Content",
            FieldSnakeName = "content",
            FieldType = typeof(string),
            FieldColumn = new SugarColumn { IsNullable = true, Length = 10000, ColumnDescription = "内容" }
        };
        /// <summary>
        /// 创建时间
        /// </summary>
        public static SheetField CreateTime = new SheetField
        {
            FieldHumpName = nameof(BaseEntity.CreateTime),
            FieldSnakeName = nameof(base_entity.create_time),
            FieldType = typeof(DateTime?),
            FieldColumn = new SugarColumn { IsNullable = false, ColumnDescription = "创建时间" }
        };
        /// <summary>
        /// 创建人
        /// </summary>
        public static SheetField Creator = new SheetField
        {
            FieldHumpName = nameof(BaseEntity.Creator),
            FieldSnakeName = nameof(base_entity.creator),
            FieldType = typeof(string),
            FieldColumn = new SugarColumn { IsNullable = true, Length = 32, ColumnDescription = "创建人" }
        };
        /// <summary>
        /// 更新时间
        /// </summary>
        public static SheetField UpdateTime = new SheetField
        {
            FieldHumpName = nameof(BaseEntity.UpdateTime),
            FieldSnakeName = nameof(base_entity.update_time),
            FieldType = typeof(DateTime?),
            FieldColumn = new SugarColumn { IsNullable = true, ColumnDescription = "更新时间" }
        };
        /// <summary>
        /// 更新人
        /// </summary>
        public static SheetField Updator = new SheetField
        {
            FieldHumpName = nameof(BaseEntity.Updator),
            FieldSnakeName = nameof(base_entity.updator),
            FieldType = typeof(string),
            FieldColumn = new SugarColumn { IsNullable = true, Length = 32, ColumnDescription = "更新人" }
        };
        /// <summary>
        /// 删除时间
        /// </summary>
        public static SheetField DeleteTime = new SheetField
        {
            FieldHumpName = nameof(BaseEntity.DeleteTime),
            FieldSnakeName = nameof(base_entity.delete_time),
            FieldType = typeof(DateTime?),
            FieldColumn = new SugarColumn { IsNullable = true, ColumnDescription = "删除时间" }
        };
        /// <summary>
        /// 删除人
        /// </summary>
        public static SheetField Deletor = new SheetField
        {
            FieldHumpName = nameof(BaseEntity.Deletor),
            FieldSnakeName = nameof(base_entity.deletor),
            FieldType = typeof(string),
            FieldColumn = new SugarColumn { IsNullable = true, Length = 32, ColumnDescription = "删除人" }
        };
        /// <summary>
        /// 删除标识
        /// </summary>
        public static SheetField Deleted = new SheetField
        {
            FieldHumpName = "Deleted",
            FieldSnakeName = "deleted",
            FieldType = typeof(string),
            FieldColumn = new SugarColumn { IsNullable = false, Length = 1, ColumnDescription = "删除标识" }
        };
        /// <summary>
        /// 获取版本表所有字段
        /// </summary>
        /// <returns></returns>
        public static List<SheetField> GetSheetFields()
        {
            var list = new List<SheetField>
            {
                Id,Name,Major,Minor,Revision,Temporary,Serial,Content,Type,
                CreateTime,Creator,UpdateTime,Updator,DeleteTime,Deletor,Deleted
            };
            return list;
        }
    }
}
