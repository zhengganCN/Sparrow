using Sparrow.Database.EntityInfo;
using SqlSugar;

namespace Sparrow.Database.SqlSugar.Models
{
    /// <summary>
    /// 版本表
    /// </summary>
#pragma warning disable IDE1006 // 命名样式
    public class sparrow_version : base_entity
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public sparrow_version()
        {
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public sparrow_version(ushort major, string name = "database")
        {
            this.major = major;
            this.name = name;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public sparrow_version(ushort major, ushort minor, string name = "database")
        {
            this.major = major;
            this.minor = minor;
            this.name = name;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public sparrow_version(ushort major, ushort minor, ushort revision, string name = "database")
        {
            this.major = major;
            this.minor = minor;
            this.revision = revision;
            this.name = name;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public sparrow_version(ushort major, ushort minor, ushort revision, ushort temporary, string name = "database")
        {
            this.major = major;
            this.minor = minor;
            this.revision = revision;
            this.temporary = temporary;
            this.name = name;
        }
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, ColumnDescription = "主键")]
        public long id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(IsNullable = false, Length = 255, ColumnDescription = "名称")]
        public string name { get; set; } = "database";
        /// <summary>
        /// 主版本号
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "主版本号")]
        public ushort major { get; set; }
        /// <summary>
        /// 子版本号
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "子版本号")]
        public ushort minor { get; set; }
        /// <summary>
        /// 修正版本号
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "修正版本号")]
        public ushort revision { get; set; }
        /// <summary>
        /// 临时版本号
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "临时版本号")]
        public ushort temporary { get; set; }
        /// <summary>
        /// 序列
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "序列")]
        public ulong serial { get; set; }
        /// <summary>
        /// 比较版本号大小
        /// </summary>
        /// <param name="version">待比较版本</param>
        /// <returns>相等返回0,大于返回1，小于返回-1</returns>
        public int Compare(sparrow_version version)
        {
            var result1 = SparrowVersionStatic.ComputerVersionSeria(major, minor, revision, temporary);
            var result2 = SparrowVersionStatic.ComputerVersionSeria(version.major, version.minor, version.revision, version.temporary);
            if (result1 == result2)
            {
                return 0;
            }
            return result1 > result2 ? 1 : -1;
        }
    }
#pragma warning restore IDE1006 // 命名样式
}
