using iText.Kernel.Colors;
using Sparrow.Export.iTextSharp.Models;
using System;

namespace Sparrow.Export.iTextSharp
{
    /// <summary>
    /// 文档属性
    /// </summary>
    public class PdfDocumentProperties
    {
        /// <summary>
        /// 背景色设置委托
        /// </summary>
        /// <param name="pageNumber">页号</param>
        /// <returns></returns>
        public delegate DeviceRgb BackgroundColorFunc(int pageNumber);
        /// <summary>
        /// 字体大小
        /// </summary>
        public int FontSize { get; set; } = 10;
        /// <summary>
        /// 显示页面号码
        /// </summary>
        public bool ShowPageNumber { get; set; } = false;
        /// <summary>
        /// 头部文本
        /// </summary>
        public string HeaderText { get; set; }
        /// <summary>
        /// 水印设置
        /// </summary>
        public WaterMark WaterMark { get; private set; } = new WaterMark();
        internal BackgroundColorFunc BackgroundColor;
        /// <summary>
        /// 设置水印
        /// </summary>
        /// <param name="action"></param>
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
