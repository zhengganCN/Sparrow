using System;

namespace Sparrow.Algorithm.Sorts
{
    /// <summary>
    /// 基数排序
    /// </summary>
    internal class SparrowRadixSort
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="array">待排序数组</param>
        /// <returns></returns>
        public static int[] Sort(int[] array)
        {
            var n = array.Length;
            int max = GetMax(array, n);

            // 根据每个位数进行排序
            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                CountSort(array, n, exp);
            }
            return array;
        }


        // 获取数组中的最大值
        private static T GetMax<T>(T[] array, int n) where T : IComparable
        {
            T max = array[0];
            for (int i = 1; i < n; i++)
            {
                if (array[i].CompareTo(max) > 0)
                    max = array[i];
            }
            return max;
        }

        // 使用计数排序根据指定的位数对数组进行排序
        private static void CountSort(int[] array, int n, int exp)
        {
            int[] output = new int[n];
            int[] count = new int[10];

            // 将计数数组初始化为0
            for (int i = 0; i < 10; i++)
            {
                count[i] = 0;
            }

            // 统计每个数字出现的次数
            for (int i = 0; i < n; i++)
            {
                count[(array[i] / exp) % 10]++;
            }

            // 计算每个数字的累计次数
            for (int i = 1; i < 10; i++)
            {
                count[i] += count[i - 1];
            }

            // 根据计数数组将元素放到正确的位置上
            for (int i = n - 1; i >= 0; i--)
            {
                output[count[(array[i] / exp) % 10] - 1] = array[i];
                count[(array[i] / exp) % 10]--;
            }

            // 将排序结果复制回原始数组
            for (int i = 0; i < n; i++)
            {
                array[i] = output[i];
            }
        }
    }
}
