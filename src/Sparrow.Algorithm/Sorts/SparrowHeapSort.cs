using System;

namespace Sparrow.Algorithm.Sorts
{
    /// <summary>
    /// 堆排序
    /// </summary>
    public class SparrowHeapSort
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
            // 构建最大堆（从最后一个非叶子节点开始）
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                Heapify(array, n, i);
            }
            // 依次将最大元素移动到数组末尾，并重新调整堆
            for (int i = n - 1; i > 0; i--)
            {
                // 将当前最大元素（根节点）与末尾元素交换
                (array[i], array[0]) = (array[0], array[i]);
                // 调整堆，使剩余元素重新满足堆的性质
                Heapify(array, i, 0);
            }
        }

        private static void Heapify<T>(T[] arr, int n, int i) where T : IComparable
        {
            int largest = i; // 初始化最大元素为当前节点
            int left = 2 * i + 1; // 左子节点索引
            int right = 2 * i + 2; // 右子节点索引
            // 如果左子节点大于当前最大元素，则更新最大元素索引
            if (left < n && arr[left].CompareTo(arr[largest]) > 0)
            {
                largest = left;
            }
            // 如果右子节点大于当前最大元素，则更新最大元素索引
            if (right < n && arr[right].CompareTo(arr[largest]) > 0)
            {
                largest = right;
            }
            // 如果最大元素不是当前节点，则交换当前节点与最大元素，并递归调整子树
            if (largest != i)
            {
                (arr[largest], arr[i]) = (arr[i], arr[largest]);
                Heapify(arr, n, largest);
            }
        }
    }
}
