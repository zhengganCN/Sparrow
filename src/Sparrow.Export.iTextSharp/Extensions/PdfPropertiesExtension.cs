using iText.Kernel.Colors;
using iText.Layout.Properties;
using Sparrow.Export.iTextSharp.Components;

namespace Sparrow.Export.iTextSharp
{
    public static class PdfPropertiesExtension
    {
        public static PdfProperties<T> SetWidth<T>(this PdfProperties<T> properties, float width) where T : class, new()
        {
            properties.Width = width;
            return properties;
        }
        public static PdfProperties<T> SetHeight<T>(this PdfProperties<T> properties, float height) where T : class, new()
        {
            properties.Height = height;
            return properties;
        }
        public static PdfProperties<T> SetMarginLeft<T>(this PdfProperties<T> properties, float marginLeft) where T : class, new()
        {
            properties.MarginLeft = marginLeft;
            return properties;
        }
        public static PdfProperties<T> SetMarginTop<T>(this PdfProperties<T> properties, float marginTop) where T : class, new()
        {
            properties.MarginTop = marginTop;
            return properties;
        }
        public static PdfProperties<T> SetMarginRight<T>(this PdfProperties<T> properties, float marginRight) where T : class, new()
        {
            properties.MarginRight = marginRight;
            return properties;
        }
        public static PdfProperties<T> SetMarginBottom<T>(this PdfProperties<T> properties, float marginBottom) where T : class, new()
        {
            properties.MarginBottom = marginBottom;
            return properties;
        }
        public static PdfProperties<T> SetPaddingLeft<T>(this PdfProperties<T> properties, float paddingLeft) where T : class, new()
        {
            properties.PaddingLeft = paddingLeft;
            return properties;
        }
        public static PdfProperties<T> SetPaddingTop<T>(this PdfProperties<T> properties, float paddingTop) where T : class, new()
        {
            properties.PaddingTop = paddingTop;
            return properties;
        }
        public static PdfProperties<T> SetPaddingRight<T>(this PdfProperties<T> properties, float paddingRight) where T : class, new()
        {
            properties.PaddingRight = paddingRight;
            return properties;
        }
        public static PdfProperties<T> SetPaddingBottom<T>(this PdfProperties<T> properties, float paddingBottom) where T : class, new()
        {
            properties.PaddingBottom = paddingBottom;
            return properties;
        }
        /// <summary>
        /// 设置背景色
        /// </summary>
        public static PdfProperties<T> SetBackgroundColor<T>(this PdfProperties<T> properties, DeviceRgb backgroundColor) where T : class, new()
        {
            properties.BackgroundColor = backgroundColor;
            return properties;
        }
        #region 字体设置
        /// <summary>
        /// 设置字体大小
        /// </summary>
        public static PdfProperties<T> SetFontSize<T>(this PdfProperties<T> properties, float fontSize) where T : class, new()
        {
            properties.FontSize = fontSize;
            return properties;
        }

        /// <summary>
        /// 设置字体斜体
        /// </summary>
        public static PdfProperties<T> SetFontItalic<T>(this PdfProperties<T> properties, bool fontItalic) where T : class, new()
        {
            properties.FontItalic = fontItalic;
            return properties;
        }

        /// <summary>
        /// 设置字体粗体
        /// </summary>
        public static PdfProperties<T> SetFontBold<T>(this PdfProperties<T> properties, bool fontBold) where T : class, new()
        {
            properties.FontBold = fontBold;
            return properties;
        }

        /// <summary>
        /// 设置字体颜色
        /// </summary>
        public static PdfProperties<T> SetFontColor<T>(this PdfProperties<T> properties, DeviceRgb fontColor) where T : class, new()
        {
            properties.FontColor = fontColor;
            return properties;
        }

        /// <summary>
        /// 设置水平位置
        /// </summary>
        public static PdfProperties<T> SetTextAlignment<T>(this PdfProperties<T> properties, TextAlignment textAlignment) where T : class, new()
        {
            properties.TextAlignment = textAlignment;
            return properties;
        }

        /// <summary>
        /// 设置垂直位置
        /// </summary>
        public static PdfProperties<T> SetVerticalAlignment<T>(this PdfProperties<T> properties, VerticalAlignment verticalAlignment) where T : class, new()
        {
            properties.VerticalAlignment = verticalAlignment;
            return properties;
        }
        #endregion
    }
}
