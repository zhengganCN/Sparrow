using iText.Kernel.Colors;
using iText.Layout.Properties;

namespace Sparrow.Export.iTextSharp.Components
{
    public class PdfProperties<T> where T : class, new()
    {
        public T Element { get; set; }
        public float? MarginLeft { get; set; }
        public float? MarginTop { get; set; }
        public float? MarginRight { get; set; }
        public float? MarginBottom { get; set; }
        public float? PaddingLeft { get; set; }
        public float? PaddingTop { get; set; }
        public float? PaddingRight { get; set; }
        public float? PaddingBottom { get; set; }
        public float? Width { get; set; }
        public float? Height { get; set; }
        /// <summary>
        /// 背景色
        /// </summary>
        public DeviceRgb BackgroundColor { get; set; }
        #region 字体设置
        /// <summary>
        /// 字体大小
        /// </summary>
        public float? FontSize { get; set; }
        /// <summary>
        /// 字体斜体
        /// </summary>
        public bool FontItalic { get; set; } = false;
        /// <summary>
        /// 字体粗体
        /// </summary>
        public bool FontBold { get; set; } = false;
        /// <summary>
        /// 字体颜色
        /// </summary>
        public DeviceRgb FontColor { get; set; }
        #endregion
        /// <summary>
        /// 默认值是 center
        /// </summary>
        public TextAlignment TextAlignment { get; set; } = TextAlignment.CENTER;
        /// <summary>
        /// 默认值是 middle
        /// </summary>
        public VerticalAlignment VerticalAlignment { get; set; } = VerticalAlignment.MIDDLE;
    }
}
