using iText.Kernel.Colors;
using Sparrow.Export.iTextSharp.Models;
using System;

namespace Sparrow.Export.iTextSharp
{
    public class SparrowPdfDocument
    {
        /// <summary>
        /// 背景色设置委托
        /// </summary>
        /// <param name="pageNumber">页号</param>
        /// <returns></returns>
        public delegate DeviceRgb BackgroundColorFunc(int pageNumber);
        public int FontSize { get; set; } = 10;
        public bool ShowPageNumber { get; set; } = false;
        public string HeaderText { get; set; }
        public WaterMark WaterMark { get; private set; } = new WaterMark();
        internal BackgroundColorFunc BackgroundColor;
        public void SetWaterMark(Action<WaterMark> action)
        {
            action?.Invoke(WaterMark);
        }
        /// <summary>
        /// 设置页面背景色
        /// </summary>
        /// <param name="func">输入参数为页号，输出参数为rgb</param>
        public void SetBackgroundColor(BackgroundColorFunc func)
        {
            BackgroundColor = func;
        }
    }
}
