namespace Sparrow.Algorithm.Enums
{
    /// <summary>
    /// 稳定的排序算法
    /// </summary>
    public enum StabilitySortAlgorithm
    {
        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <remarks>
        /// 优点：实现简单，代码易于理解和实现。<br></br>
        /// 缺点：效率较低，时间复杂度为O(n^2)，不适用于大规模数据排序。 
        /// </remarks>
        BubbleSort = 1,
        /// <summary>
        /// 插入排序
        /// </summary>
        /// <remarks>
        /// 优点：对于小规模或基本有序的数据排序效果较好，实现简单。<br></br>
        /// 缺点：时间复杂度为O(n^2)，对于大规模数据排序效率较低。 
        /// </remarks>
        InsertionSort = 3,
        /// <summary>
        /// 归并排序
        /// </summary>
        /// <remarks>  
        /// 优点：稳定且效率较高，时间复杂度为O(nlogn)，适用于大规模数据排序。<br></br>
        /// 缺点：需要额外的内存空间来存储临时数组，空间复杂度较高。
        /// </remarks>
        MergeSort = 5
    }
}
