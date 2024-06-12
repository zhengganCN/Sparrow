namespace Sparrow.StandardResult
{
    /// <summary>
    /// 标准格式化接口
    /// </summary>
    public interface IStandardFormat
    {
        /// <summary>
        /// 标准格式化
        /// </summary>
        /// <returns></returns>
        object StandardFormat();
        /// <summary>
        /// 标准格式化
        /// </summary>
        /// <returns></returns>
        object StandardFormat(string key);
    }
}
