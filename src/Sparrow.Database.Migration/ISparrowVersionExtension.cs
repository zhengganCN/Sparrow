using System;
using System.Collections.Generic;

namespace Sparrow.Database.Migration
{
    /// <summary>
    /// <see cref="ISparrowVersion"/>扩展
    /// </summary>
    public static class ISparrowVersionExtension
    {
        /// <summary>
        /// 比较版本号大小
        /// </summary>
        /// <param name="version1">原比较</param>
        /// <param name="version2">待比较</param>
        /// <returns>相等返回0,大于返回1，小于返回-1</returns>
        public static int Compare(this ISparrowVersion version1, ISparrowVersion version2)
        {
            var list1 = new List<byte>(8);
            list1.AddRange(BitConverter.GetBytes(version1.Temporary));
            list1.AddRange(BitConverter.GetBytes(version1.Revision));
            list1.AddRange(BitConverter.GetBytes(version1.Minor));
            list1.AddRange(BitConverter.GetBytes(version1.Major));
            var list2 = new List<byte>(8);
            list2.AddRange(BitConverter.GetBytes(version2.Temporary));
            list2.AddRange(BitConverter.GetBytes(version2.Revision));
            list2.AddRange(BitConverter.GetBytes(version2.Minor));
            list2.AddRange(BitConverter.GetBytes(version2.Major));
            var result1 = BitConverter.ToUInt64(list1.ToArray(), 0);
            var result2 = BitConverter.ToUInt64(list2.ToArray(), 0);
            if (result1 == result2)
            {
                return 0;
            }
            return result1 > result2 ? 1 : -1;
        }
    }
}
