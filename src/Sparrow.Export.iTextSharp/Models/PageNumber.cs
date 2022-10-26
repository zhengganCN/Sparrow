using Rectangle = iText.Kernel.Geom.Rectangle;

namespace Sparrow.Export.iTextSharp
{
    /// <summary>
    /// 页码参数
    /// </summary>
    public class PageNumber
    {
        /// <summary>
        /// 是否是页首
        /// </summary>
        internal bool IsHeader = false;
        /// <summary>
        /// 页码参数
        /// </summary>
        /// <param name="isHeader">是否是页首</param>
        public PageNumber(bool isHeader)
        {
            IsHeader = isHeader;
        }

        /// <summary>
        /// 是否显示，默认不显示
        /// </summary>
        public bool IsShow { get; set; } = false;
        /// <summary>
        /// 字体与边缘距离
        /// </summary>
        public double Margin { get; set; } = 20;
        /// <summary>
        /// 字体大小，默认为 10
        /// </summary>
        public int FontSize { get; set; } = 10;
        /// <summary>
        /// 文本位置
        /// </summary>
        public EnumTextAlign TextAlign { get; set; } = EnumTextAlign.Center;
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
        internal double StartX(Rectangle rectangle, int textCount)
        {
            var w = rectangle.GetWidth();
            double x = 0;
            switch (TextAlign)
            {
                case EnumTextAlign.Left:
                    x = Margin;
                    break;
                case EnumTextAlign.Center:
                    var center = rectangle.GetWidth() / 2;
                    if (textCount % 2 != 0)
                    {
                        x = center - (FontSize / 2) - ((textCount - 1) / 2 * FontSize);
                    }
                    else
                    {
                        x = center - (textCount / 2 * FontSize);
                    }
                    break;
                case EnumTextAlign.Right:
                    x = w - Margin - (textCount * FontSize);
                    break;
            }
            return x;
        }

        internal double StartY(Rectangle rectangle)
        {
            var h = rectangle.GetHeight();
            double y;
            if (IsHeader)
            {
                y = h - Margin;
            }
            else
            {
                y = Margin;
            }
            return y;
        }

        /// <summary>
        /// 文本位置
        /// </summary>
        public enum EnumTextAlign
        {
            /// <summary>
            /// 左
            /// </summary>
            Left,
            /// <summary>
            /// 居中
            /// </summary>
            Center,
            /// <summary>
            /// 右
            /// </summary>
            Right
        }
    }
}
