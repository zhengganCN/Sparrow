using Sparrow.Export.iTextSharp.Enums;

namespace Sparrow.Export.iTextSharp.Components
{
    /// <summary>
    /// Pdf标题
    /// </summary>
    public class PdfTitle : PdfProperties<PdfTitle>
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 标题样式
        /// </summary>
        public H H { get; private set; }
        /// <summary>
        /// Pdf标题
        /// </summary>
        public PdfTitle()
        {
            Init(string.Empty);
        }
        /// <summary>
        /// Pdf标题
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="h">标题样式</param>
        public PdfTitle(string title, H h = H.H1)
        {
            Init(title, h);
        }

        private void Init(string title, H h = H.H1)
        {
            Title = title;
            FontSize = (int)h;
            Element = this;
        }
    }
}
