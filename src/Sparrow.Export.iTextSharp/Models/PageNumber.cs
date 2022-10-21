namespace Sparrow.Export.iTextSharp
{
    /// <summary>
    /// 页码参数
    /// </summary>
    public class PageNumber
    {
        /// <summary>
        /// 是否显示
        /// </summary>
        public bool IsShow { get; set; } = true;
        /// <summary>
        /// 页面文本委托
        /// </summary>
        /// <param name="num">页码</param>
        /// <returns></returns>
        public delegate string PageTextDelegate(int num);
        /// <summary>
        /// 自定义页面文本
        /// </summary>
        public PageTextDelegate DefinePageText { get; set; } = (num) =>
        {
            return $"{num}";
        };
    }
}
