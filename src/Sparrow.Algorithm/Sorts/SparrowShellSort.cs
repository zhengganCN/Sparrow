using System;

namespace Sparrow.Algorithm.Sorts
{
    /// <summary>
    /// 希尔排序
    /// </summary>
    internal class SparrowShellSort
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
            // 使用Knuth序列来确定间隔
            int gap = 1;
            while (gap < n / 3)
            {
                gap = 3 * gap + 1;
            }
            while (gap >= 1)
            {
                // 使用插入排序对每个间隔进行排序
                for (int i = gap; i < n; i++)
                {
                    T temp = array[i];
                    int j = i;

                    while (j >= gap && array[j - gap].CompareTo(temp) > 0)
                    {
                        array[j] = array[j - gap];
                        j -= gap;
                    }
                    array[j] = temp;
                }
                gap /= 3;
            }
        }
    }
}
