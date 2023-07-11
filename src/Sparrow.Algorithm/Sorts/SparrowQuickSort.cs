using System;

namespace Sparrow.Algorithm.Sorts
{
    /// <summary>
    /// 快速排序
    /// </summary>
    internal class SparrowQuickSort
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="array">待排序数组</param>
        /// <returns></returns>
        public static void Sort<T>(T[] array) where T : IComparable
        {
            Sort(array, 0, array.Length - 1);
        }

        // 快速排序函数
        private static T[] Sort<T>(T[] array, int low, int high) where T : IComparable
        {
            if (low < high)
            {
                int pivot = Partition(array, low, high);
                Sort(array, low, pivot - 1);
                Sort(array, pivot + 1, high);
            }
            return array;
        }

        // 划分函数
        private static int Partition<T>(T[] array, int low, int high) where T : IComparable
        {
            T pivot = array[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (array[j].CompareTo(pivot) < 0)
                {
                    i++;
                    Swap(array, i, j);
                }
            }
            Swap(array, i + 1, high);
            return i + 1;
        }

        // 交换函数
        private static void Swap<T>(T[] array, int i, int j)
        {
            (array[j], array[i]) = (array[i], array[j]);
        }
    }
}
