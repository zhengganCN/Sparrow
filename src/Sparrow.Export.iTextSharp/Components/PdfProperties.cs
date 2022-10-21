using iText.Kernel.Colors;
using iText.Layout.Properties;

namespace Sparrow.Export.iTextSharp
{
    /// <summary>
    /// 属性
    /// </summary>
    /// <typeparam name="T">控件</typeparam>
    public class PdfProperties<T>
    {
        /// <summary>
        /// 元素
        /// </summary>
        internal T Element { get; set; }
        /// <summary>
        /// MarginLeft
        /// </summary>
        public float? MarginLeft { get; set; }
        /// <summary>
        /// MarginTop
        /// </summary>
        public float? MarginTop { get; set; }
        /// <summary>
        /// MarginRight
        /// </summary>
        public float? MarginRight { get; set; }
        /// <summary>
        /// MarginBottom
        /// </summary>
        public float? MarginBottom { get; set; }
        /// <summary>
        /// PaddingLeft
        /// </summary>
        public float? PaddingLeft { get; set; }
        /// <summary>
        /// PaddingTop
        /// </summary>
        public float? PaddingTop { get; set; }
        /// <summary>
        /// PaddingRight
        /// </summary>
        public float? PaddingRight { get; set; }
        /// <summary>
        /// PaddingBottom
        /// </summary>
        public float? PaddingBottom { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        public float? Width { get; set; }
        /// <summary>
        /// 高度
        /// </summary>
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
