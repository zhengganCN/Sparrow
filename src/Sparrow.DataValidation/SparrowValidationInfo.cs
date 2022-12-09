namespace Sparrow.DataValidation
{
    /// <summary>
    /// 验证结果信息
    /// </summary>
    public class SparrowValidationInfo
    {
        /// <summary>
        /// 字段
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string[] Errors { get; set; }
    }
}
