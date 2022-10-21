using iText.Kernel.Colors;
using iText.Layout.Properties;

namespace Sparrow.Export.iTextSharp
{
    /// <summary>
    /// Pdf属性扩展
    /// </summary>
    public static class PdfPropertiesExtension
    {
        /// <summary>
        /// 设置宽度
        /// </summary>
        /// <typeparam name="T">控件</typeparam>
        /// <param name="properties">控件属性</param>
        /// <param name="width">宽度</param>
        /// <returns></returns>
        public static T SetWidth<T>(this PdfProperties<T> properties, float width) where T : class
        {
            properties.Width = width;
            return properties.Element;
        }
        /// <summary>
        /// 设置高度
        /// </summary>
        /// <typeparam name="T">控件</typeparam>
        /// <param name="properties">控件属性</param>
        /// <param name="height">高度</param>
        /// <returns></returns>
        public static T SetHeight<T>(this PdfProperties<T> properties, float height) where T : class
        {
            properties.Height = height;
            return properties.Element;
        }
        /// <summary>
        /// 设置marginLeft
        /// </summary>
        /// <typeparam name="T">控件</typeparam>
        /// <param name="properties">控件属性</param>
        /// <param name="marginLeft">marginLeft</param>
        /// <returns></returns>
        public static T SetMarginLeft<T>(this PdfProperties<T> properties, float marginLeft) where T : class
        {
            properties.MarginLeft = marginLeft;
            return properties.Element;
        }
        /// <summary>
        /// 设置marginTop
        /// </summary>
        /// <typeparam name="T">控件</typeparam>
        /// <param name="properties">控件属性</param>
        /// <param name="marginTop">marginTop</param>
        /// <returns></returns>
        public static T SetMarginTop<T>(this PdfProperties<T> properties, float marginTop) where T : class
        {
            properties.MarginTop = marginTop;
            return properties.Element;
        }
        /// <summary>
        /// 设置marginRight
        /// </summary>
        /// <typeparam name="T">控件</typeparam>
        /// <param name="properties">控件属性</param>
        /// <param name="marginRight">marginRight</param>
        /// <returns></returns>
        public static T SetMarginRight<T>(this PdfProperties<T> properties, float marginRight) where T : class
        {
            properties.MarginRight = marginRight;
            return properties.Element;
        }
        /// <summary>
        /// 设置marginBottom
        /// </summary>
        /// <typeparam name="T">控件</typeparam>
        /// <param name="properties">控件属性</param>
        /// <param name="marginBottom">marginBottom</param>
        /// <returns></returns>
        public static T SetMarginBottom<T>(this PdfProperties<T> properties, float marginBottom) where T : class
        {
            properties.MarginBottom = marginBottom;
            return properties.Element;
        }
        /// <summary>
        /// 设置paddingLeft
        /// </summary>
        /// <typeparam name="T">控件</typeparam>
        /// <param name="properties">控件属性</param>
        /// <param name="paddingLeft">paddingLeft</param>
        /// <returns></returns>
        public static T SetPaddingLeft<T>(this PdfProperties<T> properties, float paddingLeft) where T : class
        {
            properties.PaddingLeft = paddingLeft;
            return properties.Element;
        }
        /// <summary>
        /// 设置paddingTop
        /// </summary>
        /// <typeparam name="T">控件</typeparam>
        /// <param name="properties">控件属性</param>
        /// <param name="paddingTop">paddingTop</param>
        /// <returns></returns>
        public static T SetPaddingTop<T>(this PdfProperties<T> properties, float paddingTop) where T : class
        {
            properties.PaddingTop = paddingTop;
            return properties.Element;
        }
        /// <summary>
        /// 设置paddingRight
        /// </summary>
        /// <typeparam name="T">控件</typeparam>
        /// <param name="properties">控件属性</param>
        /// <param name="paddingRight">paddingRight</param>
        /// <returns></returns>
        public static T SetPaddingRight<T>(this PdfProperties<T> properties, float paddingRight) where T : class
        {
            properties.PaddingRight = paddingRight;
            return properties.Element;
        }
        /// <summary>
        /// 设置paddingBottom
        /// </summary>
        /// <typeparam name="T">控件</typeparam>
        /// <param name="properties">控件属性</param>
        /// <param name="paddingBottom">paddingBottom</param>
        /// <returns></returns>
        public static T SetPaddingBottom<T>(this PdfProperties<T> properties, float paddingBottom) where T : class
        {
            properties.PaddingBottom = paddingBottom;
            return properties.Element;
        }
        /// <summary>
        /// 设置背景色
        /// </summary>
        /// <typeparam name="T">控件</typeparam>
        /// <param name="properties">控件属性</param>
        /// <param name="backgroundColor">背景色</param>
        /// <returns></returns>
        public static T SetBackgroundColor<T>(this PdfProperties<T> properties, DeviceRgb backgroundColor) where T : class
        {
            properties.BackgroundColor = backgroundColor;
            return properties.Element;
        }
        #region 字体设置
        /// <summary>
        /// 设置字体大小
        /// </summary>
        /// <typeparam name="T">控件</typeparam>
        /// <param name="properties">控件属性</param>
        /// <param name="fontSize">字体大小</param>
        /// <returns></returns>
        public static T SetFontSize<T>(this PdfProperties<T> properties, float fontSize) where T : class
        {
            properties.FontSize = fontSize;
            return properties.Element;
        }

        /// <summary>
        /// 设置字体斜体
        /// </summary>
        /// <typeparam name="T">控件</typeparam>
        /// <param name="properties">控件属性</param>
        /// <param name="fontItalic">字体斜体</param>
        /// <returns></returns>
        public static T SetFontItalic<T>(this PdfProperties<T> properties, bool fontItalic) where T : class
        {
            properties.FontItalic = fontItalic;
            return properties.Element;
        }

        /// <summary>
        /// 设置字体粗体
        /// </summary>
        /// <typeparam name="T">控件</typeparam>
        /// <param name="properties">控件属性</param>
        /// <param name="fontBold">字体粗体</param>
        /// <returns></returns>
        public static T SetFontBold<T>(this PdfProperties<T> properties, bool fontBold) where T : class
        {
            properties.FontBold = fontBold;
            return properties.Element;
        }

        /// <summary>
        /// 设置字体颜色
        /// </summary>
        /// <typeparam name="T">控件</typeparam>
        /// <param name="properties">控件属性</param>
        /// <param name="fontColor">字体颜色</param>
        /// <returns></returns>
        public static T SetFontColor<T>(this PdfProperties<T> properties, DeviceRgb fontColor) where T : class
        {
            properties.FontColor = fontColor;
            return properties.Element;
        }

        /// <summary>
        /// 设置水平位置
        /// </summary>
        /// <typeparam name="T">控件</typeparam>
        /// <param name="properties">控件属性</param>
        /// <param name="textAlignment">水平位置</param>
        /// <returns></returns>
        public static T SetTextAlignment<T>(this PdfProperties<T> properties, TextAlignment textAlignment) where T : class
        {
            properties.TextAlignment = textAlignment;
            return properties.Element;
        }

        /// <summary>
        /// 设置垂直位置
        /// </summary>
        /// <typeparam name="T">控件</typeparam>
        /// <param name="properties">控件属性</param>
        /// <param name="verticalAlignment">垂直位置</param>
        /// <returns></returns>
        public static T SetVerticalAlignment<T>(this PdfProperties<T> properties, VerticalAlignment verticalAlignment) where T : class
        {
            properties.VerticalAlignment = verticalAlignment;
            return properties.Element;
        }
        #endregion
    }
}
