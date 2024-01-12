using Sparrow.Database.EntityInfo;
using SqlSugar;

namespace Sparrow.Database.SqlSugar.Models
{
    /// <summary>
    /// 版本表
    /// </summary>
    public class SparrowVersion : BaseEntity
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
        public SparrowVersion(ushort major, string name = "database")
        {
            Major = major;
            Name = name;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public SparrowVersion(ushort major, ushort minor, string name = "database")
        {
            Major = major;
            Minor = minor;
            Name = name;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public SparrowVersion(ushort major, ushort minor, ushort revision, string name = "database")
        {
            Major = major;
            Minor = minor;
            Revision = revision;
            Name = name;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public SparrowVersion(ushort major, ushort minor, ushort revision, ushort temporary, string name = "database")
        {
            Major = major;
            Minor = minor;
            Revision = revision;
            Temporary = temporary;
            Name = name;
        }
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, ColumnDescription = "主键")]
        public long Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(IsNullable = false, Length = 255, ColumnDescription = "名称")]
        public string Name { get; set; } = "database";
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
        /// 序列
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "序列")]
        public ulong Serial { get; set; }
        /// <summary>
        /// 比较版本号大小
        /// </summary>
        /// <param name="version">待比较版本</param>
        /// <returns>相等返回0,大于返回1，小于返回-1</returns>
        public int Compare(SparrowVersion version)
        {
            var result1 = SparrowVersionStatic.ComputerVersionSeria(Major, Minor, Revision, Temporary);
            var result2 = SparrowVersionStatic.ComputerVersionSeria(version.Major, version.Minor, version.Revision, version.Temporary);
            if (result1 == result2)
            {
                return 0;
            }
            return result1 > result2 ? 1 : -1;
        }
    }
}
