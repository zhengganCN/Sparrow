using Sparrow.Database.Migration;
using SqlSugar;
using System;

namespace Sparrow.Database.SqlSugar
{
    /// <summary>
    /// 版本表
    /// </summary>
    [SugarTable("sparrow_version", TableDescription = "版本表")]
    public class SparrowVersion : ISparrowVersion
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public SparrowVersion()
        {
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public SparrowVersion(ushort major)
        {
            Major = major;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public SparrowVersion(ushort major, ushort minor)
        {
            Major = major;
            Minor = minor;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public SparrowVersion(ushort major, ushort minor, ushort revision)
        {
            Major = major;
            Minor = minor;
            Revision = revision;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public SparrowVersion(ushort major, ushort minor, ushort revision, ushort temporary)
        {
            Major = major;
            Minor = minor;
            Revision = revision;
            Temporary = temporary;
        }
        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, Length = 255, ColumnDescription = "名称")]
        public string Name { get; set; }
        /// <summary>
        /// 主版本号
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "主版本号")]
        public ushort Major { get; set; }
        /// <summary>
        /// 子版本号
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "子版本号")]
        public ushort Minor { get; set; }
        /// <summary>
        /// 修正版本号
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "修正版本号")]
        public ushort Revision { get; set; }
        /// <summary>
        /// 临时版本号
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "临时版本号")]
        public ushort Temporary { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(ColumnDescription = "创建时间")]
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 32, ColumnDescription = "创建人")]
        public string Creator { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        [SugarColumn(IsNullable = true, ColumnDescription = "更新时间")]
        public DateTime? UpdateTime { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 32, ColumnDescription = "更新人")]
        public string Updator { get; set; }
    }
}
