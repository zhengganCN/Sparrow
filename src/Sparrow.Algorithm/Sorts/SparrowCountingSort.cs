using System;

namespace Sparrow.Algorithm.Sorts
{
    /// <summary>
    /// 计数排序
    /// </summary>
    internal class SparrowCountingSort
    {
        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="array">待排序数组</param>
        /// <returns></returns>
        public static int[] Sort<T>(int[] array) where T : IComparable
        {
            int length = array.Length;

            // 查找数组中的最大值
            int max = array[0];
            for (int i = 1; i < length; i++)
            {
                if (array[i].CompareTo(max) > 0)
                    max = array[i];
            }

            // 创建计数数组并初始化为0
            int[] count = new int[max + 1];
            for (int i = 0; i <= max; i++)
            {
                count[i] = 0;
            }

            // 计算每个元素的出现次数
            for (int i = 0; i < length; i++)
            {
                count[array[i]]++;
            }

            // 计算每个元素的累计次数
            for (int i = 1; i <= max; i++)
            {
                count[i] += count[i - 1];
            }
            // 创建临时数组存储排序结果
            int[] sortedArray = new int[length];
            // 根据计数数组将元素放到正确的位置上
            for (int i = length - 1; i >= 0; i--)
            {
                sortedArray[count[array[i]] - 1] = array[i];
                count[array[i]]--;
            }
            // 将排序结果复制回原始数组
            for (int i = 0; i < length; i++)
            {
                array[i] = sortedArray[i];
            }
            return array;
        }
    }
}
