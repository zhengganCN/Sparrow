using Sparrow.Export.NPOI.Enums;

namespace Sparrow.Export.NPOI.Components
{
    /// <summary>
    /// Word标题
    /// </summary>
    public class WordTitle
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 标题格式
        /// </summary>
        public EnumTitle EnumTitle { get; set; } = EnumTitle.Header_1;
        /// <summary>
        /// Word标题
        /// </summary>
        /// <param name="title">标题</param>
        public WordTitle(string title)
        {
            Title = title;
        }
        /// <summary>
        /// Word标题
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="enumTitle">标题格式</param>
        public WordTitle(string title, EnumTitle enumTitle)
        {
            Title = title;
            EnumTitle = enumTitle;
        }
    }
}
