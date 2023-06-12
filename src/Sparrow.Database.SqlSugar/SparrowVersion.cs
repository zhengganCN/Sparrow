using SqlSugar;
using System;
using System.Collections.Generic;

namespace Sparrow.Database.SqlSugar
{
    /// <summary>
    /// 版本表
    /// </summary>
    [SugarTable("sparrow_version", TableDescription = "版本表")]
    public class SparrowVersion
    {
        /// <summary>
        /// 主键
        /// </summary>
        [SugarColumn(IsPrimaryKey = true, Length = 36, ColumnDescription = "主键")]
        public string Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(Length = 255, ColumnDescription = "名称")]
        public string Name { get; set; }
        /// <summary>
        /// 主版本号
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "主版本号")]
        public ushort MajorVersion { get; set; }
        /// <summary>
        /// 子版本号
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "子版本号")]
        public ushort MinorVersion { get; set; }
        /// <summary>
        /// 修正版本号
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "修正版本号")]
        public ushort RevisionVersion { get; set; }
        /// <summary>
        /// 临时版本号
        /// </summary>
        [SugarColumn(IsNullable = false, ColumnDescription = "临时版本号")]
        public ushort TemporaryVersion { get; set; }
        /// <summary>
        /// 删除标识
        /// </summary>
        [SugarColumn(ColumnDescription = "删除标识")]
        public bool IsDeleted { get; set; }
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
        /// 删除时间
        /// </summary>
        [SugarColumn(IsNullable = true, ColumnDescription = "删除时间")]
        public DateTime? DeleteTime { get; set; }
        /// <summary>
        /// 删除人
        /// </summary>
        [SugarColumn(IsNullable = true, Length = 32, ColumnDescription = "删除人")]
        public string Deletor { get; set; }
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
        /// <summary>
        /// 比较版本号大小
        /// </summary>
        /// <param name="version">待比较</param>
        /// <returns>相等返回0,大于返回1，小于返回-1</returns>
        public int Compare(SparrowVersion version)
        {
            var list1 = new List<byte>(8);
            list1.AddRange(BitConverter.GetBytes(TemporaryVersion));
            list1.AddRange(BitConverter.GetBytes(RevisionVersion));
            list1.AddRange(BitConverter.GetBytes(MinorVersion));
            list1.AddRange(BitConverter.GetBytes(MajorVersion));
            var list2 = new List<byte>(8);
            list2.AddRange(BitConverter.GetBytes(version.TemporaryVersion));
            list2.AddRange(BitConverter.GetBytes(version.RevisionVersion));
            list2.AddRange(BitConverter.GetBytes(version.MinorVersion));
            list2.AddRange(BitConverter.GetBytes(version.MajorVersion));
            var result1 = BitConverter.ToUInt64(list1.ToArray());
            var result2 = BitConverter.ToUInt64(list2.ToArray());
            if (result1 == result2)
            {
                return 0;
            }
            return result1 > result2 ? 1 : -1;
        }
    }
}
