namespace Sparrow.StandardResult
{
    /// <summary>
    /// 分页参数接口
    /// </summary>
    public interface IPagination
    {
        /// <summary>
        /// 页码
        /// </summary>
        /// <returns></returns>
        int GetPageIndex();
        /// <summary>
        /// 数量
        /// </summary>
        int GetPageSize();
    }
}
