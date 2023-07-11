namespace Sparrow.Algorithm.Enums
{
    /// <summary>
    /// 不稳定的排序算法
    /// </summary>
    public enum InstabilitySortAlgorithm
    {
        /// <summary>
        /// 选择排序
        /// </summary>
        /// <remarks>
        /// 优点：实现简单，不占用额外的内存空间。<br></br>
        /// 缺点：时间复杂度为O(n^2)，不适用于大规模数据排序，每次只能确定一个元素的位置。 
        /// </remarks>
        SelectionSort = 2,
        /// <summary>
        /// 快速排序
        /// </summary>
        /// <remarks>
        /// 优点：平均情况下效率较高，时间复杂度为O(nlogn)，适用于大规模数据排序。<br></br>
        /// 缺点：最坏情况下时间复杂度为O(n^2)，对于基本有序的数据排序效果较差。 
        /// </remarks>
        QuickSort = 4,
        /// <summary>
        /// 堆排序
        /// </summary>
        /// <remarks>
        /// 优点：稳定且效率较高，时间复杂度为O(nlogn)，适用于大规模数据排序。<br></br>
        /// 缺点：需要额外的内存空间来存储堆，空间复杂度较高。 
        /// </remarks>
        HeapSort = 6,
        /// <summary>
        /// 希尔排序
        /// </summary>
        /// <remarks>
        /// 优点：对于中等规模数据排序效果较好，时间复杂度为O(nlogn)。<br></br>
        /// 缺点：实现较复杂，不稳定。
        /// </remarks>
        ShellSort = 7,
    }
}
