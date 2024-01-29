using System;

namespace Sparrow.Database.SqlSugar.Models
{
    /// <summary>
    /// 迁移选项
    /// </summary>
    public class Migration
    {
        /// <summary>
        /// 无参构造函数
        /// </summary>
        public Migration()
        {
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public Migration(ushort major, string name = "database")
        {
            this.major = major;
            this.name = name;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public Migration(ushort major, ushort minor, string name = "database")
        {
            this.major = major;
            this.minor = minor;
            this.name = name;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public Migration(ushort major, ushort minor, ushort revision, string name = "database")
        {
            this.major = major;
            this.minor = minor;
            this.revision = revision;
            this.name = name;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public Migration(ushort major, ushort minor, ushort revision, ushort temporary, string name = "database")
        {
            this.major = major;
            this.minor = minor;
            this.revision = revision;
            this.temporary = temporary;
            this.name = name;
        }
        /// <summary>
        /// 表名
        /// </summary>
        internal string table_name { get; set; }
        /// <summary>
        /// 主版本号
        /// </summary>
        public ushort major { get; set; }
        /// <summary>
        /// 子版本号
        /// </summary>
        public ushort minor { get; set; }
        /// <summary>
        /// 修正版本号
        /// </summary>
        public ushort revision { get; set; }
        /// <summary>
        /// 临时版本号
        /// </summary>
        public ushort temporary { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 比较版本号大小
        /// </summary>
        /// <param name="version">待比较版本</param>
        /// <returns>相等返回0,大于返回1，小于返回-1</returns>
        public int Compare(Migration version)
        {
            var result1 = ComputerVersionSeria(major, minor, revision, temporary);
            var result2 = ComputerVersionSeria(version.major, version.minor, version.revision, version.temporary);
            if (result1 == result2)
            {
                return 0;
            }
            return result1 > result2 ? 1 : -1;
        }
        /// <summary>
        /// 计算版本序列值
        /// </summary>
        /// <returns></returns>
        public ulong ComputerVersionSeria()
        {
            return ComputerVersionSeria(major, minor, revision, temporary);
        }
        /// <summary>
        /// 计算版本序列值
        /// </summary>
        /// <returns></returns>
        public static ulong ComputerVersionSeria(ushort major, ushort minor, ushort revision, ushort temporary)
        {
            var bytes = new byte[8];
            BitConverter.GetBytes(major).CopyTo(bytes, 6);
            BitConverter.GetBytes(minor).CopyTo(bytes, 4);
            BitConverter.GetBytes(revision).CopyTo(bytes, 2);
            BitConverter.GetBytes(temporary).CopyTo(bytes, 0);
            return BitConverter.ToUInt64(bytes, 0);
        }
    }
}
