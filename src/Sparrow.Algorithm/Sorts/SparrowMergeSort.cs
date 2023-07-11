using System;

namespace Sparrow.Algorithm.Sorts
{
    /// <summary>
    /// 归并排序
    /// </summary>
    internal class SparrowMergeSort
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="array">待排序数组</param>
        /// <returns></returns>
        public static void Sort<T>(T[] array) where T : IComparable
        {
            if (array.Length < 2)
                return;
            int mid = array.Length / 2;
            T[] left = new T[mid];
            T[] right = new T[array.Length - mid];
            for (int i = 0; i < mid; i++)
                left[i] = array[i];
            for (int i = mid; i < array.Length; i++)
                right[i - mid] = array[i];
            Sort(left);
            Sort(right);
            Merge(left, right, array);
        }

        // 合并两个有序数组
        public static void Merge<T>(T[] left, T[] right, T[] array) where T : IComparable
        {
            int i = 0, j = 0, k = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i].CompareTo(right[j]) <= 0)
                {
                    array[k] = left[i];
                    i++;
                }
                else
                {
                    array[k] = right[j];
                    j++;
                }
                k++;
            }

            while (i < left.Length)
            {
                array[k] = left[i];
                i++;
                k++;
            }

            while (j < right.Length)
            {
                array[k] = right[j];
                j++;
                k++;
            }
        }
    }
}
