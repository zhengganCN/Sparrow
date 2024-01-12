using System;

namespace Sparrow.Database.SqlSugar
{
    /// <summary>
    /// 静态类
    /// </summary>
    public static class SparrowVersionStatic
    {
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
