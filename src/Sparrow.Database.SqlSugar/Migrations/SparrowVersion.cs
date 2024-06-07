using System;

namespace Sparrow.Database.SqlSugar.Migrations
{
    /// <summary>
    /// 版本
    /// </summary>
    public class SparrowVersion
    {
        /// <summary>
        /// 主版本号
        /// </summary>
        public ushort Major { get; set; }
        /// <summary>
        /// 子版本号
        /// </summary>
        public ushort Minor { get; set; }
        /// <summary>
        /// 修正版本号
        /// </summary>
        public ushort Revision { get; set; }
        /// <summary>
        /// 临时版本号
        /// </summary>
        public ushort Temporary { get; set; }

        /// <summary>
        /// 比较版本号大小
        /// </summary>
        /// <param name="version">待比较版本</param>
        /// <returns>相等返回0,大于返回1，小于返回-1</returns>
        public int Compare(SparrowVersion version)
        {
            var result1 = ComputerVersionSeria(Major, Minor, Revision, Temporary);
            var result2 = ComputerVersionSeria(version.Major, version.Minor, version.Revision, version.Temporary);
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
            return ComputerVersionSeria(Major, Minor, Revision, Temporary);
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
