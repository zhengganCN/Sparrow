namespace Sparrow.StandardResult.Web
{
    /// <summary>
    /// web结果返回可选项
    /// </summary>
    public class StandardResultWebOptions
    {
        /// <summary>
        /// 是否使用<see cref="Standard"/>的Code属性的值替换Response的StatusCode的值，默认为false
        /// </summary>
        public bool UseStandardCodeReplaceResponseCode { get; set; } = false;
    }
}
