using Sparrow.Algorithm.Enums;
using System;

namespace Sparrow.Algorithm.Sorts
{
    /// <summary>
    /// 排序
    /// </summary>
    public class SparrowSort
    {
        private static T[] DeepCopy<T>(T[] array)
        {
            return (T[])array.Clone();
        }
        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="T">比较类型</typeparam>
        public static T[] Sort<T>(T[] array, SortAlgorithm sort = SortAlgorithm.QuickSort) where T : IComparable
        {
            var list = DeepCopy(array);
            switch (sort)
            {
                case SortAlgorithm.BubbleSort:
                    SparrowBubbleSort.Sort(list);
                    break;
                case SortAlgorithm.SelectionSort:
                    SparrowSelectionSort.Sort(list);
                    break;
                case SortAlgorithm.InsertionSort:
                    SparrowInsertionSort.Sort(list);
                    break;
                case SortAlgorithm.QuickSort:
                    SparrowQuickSort.Sort(list);
                    break;
                case SortAlgorithm.MergeSort:
                    SparrowMergeSort.Sort(list);
                    break;
                case SortAlgorithm.HeapSort:
                    SparrowHeapSort.Sort(list);
                    break;
                case SortAlgorithm.ShellSort:
                    SparrowShellSort.Sort(list);
                    break;
            }
            return list;
        }
        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="T">比较类型</typeparam>
        public static T[] Sort<T>(T[] array, InstabilitySortAlgorithm sort) where T : IComparable
        {
            var list = DeepCopy(array);
            switch (sort)
            {
                case InstabilitySortAlgorithm.SelectionSort:
                    SparrowSelectionSort.Sort(list);
                    break;
                case InstabilitySortAlgorithm.QuickSort:
                    SparrowQuickSort.Sort(list);
                    break;
                case InstabilitySortAlgorithm.HeapSort:
                    SparrowHeapSort.Sort(list);
                    break;
                case InstabilitySortAlgorithm.ShellSort:
                    SparrowShellSort.Sort(list);
                    break;
            }
            return list;
        }
        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="T">比较类型</typeparam>
        public static T[] Sort<T>(T[] array, StabilitySortAlgorithm sort) where T : IComparable
        {
            var list = DeepCopy(array);
            switch (sort)
            {
                case StabilitySortAlgorithm.BubbleSort:
                    SparrowBubbleSort.Sort(list);
                    break;
                case StabilitySortAlgorithm.InsertionSort:
                    SparrowInsertionSort.Sort(list);
                    break;
                case StabilitySortAlgorithm.MergeSort:
                    SparrowMergeSort.Sort(list);
                    break;
            }
            return list;
        }
    }
}
