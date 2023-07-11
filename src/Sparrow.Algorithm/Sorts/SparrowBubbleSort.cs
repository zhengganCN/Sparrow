using System;

namespace Sparrow.Algorithm.Sorts
{
    /// <summary>
    /// 冒泡排序
    /// </summary>
    public static class SparrowBubbleSort
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="array">待排序数组</param>
        /// <returns></returns>
        public static void Sort<T>(T[] array) where T : IComparable
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        // 交换array[j]和array[j + 1]的值
                        (array[j + 1], array[j]) = (array[j], array[j + 1]);
                    }
                }
            }
        }
    }
}
