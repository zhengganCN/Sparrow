using iText.Kernel.Events;
using Sparrow.Export.iTextSharp.Events;
using System;

namespace Sparrow.Export.iTextSharp
{
    public partial class SparrowPdf
    {
        /// <summary>
        /// 设置背景
        /// </summary>
        /// <returns></returns>
        public SparrowPdf SetBackground(Background background)
        {
            var handle = new BackgroundEvent(background);
            PdfDocument.AddEventHandler(PdfDocumentEvent.INSERT_PAGE, handle);
            return this;
        }
        /// <summary>
        /// 设置水印
        /// </summary>
        /// <param name="mark">水印参数</param>
        /// <returns></returns>
        public SparrowPdf SetWaterMark(WaterMark mark)
        {
            var handle = new WaterMarkEvent(mark, PdfFont);
            PdfDocument.AddEventHandler(PdfDocumentEvent.INSERT_PAGE, handle);
            return this;
        }



        /// <summary>
        /// 设置头部样式
        /// </summary>
        /// <returns></returns>
        public SparrowPdf SetHeader(Action<Header> action)
        {
            action.Invoke(PageHeader);
            var handle = new HeaderEvent(PageHeader, PdfFont);
            PdfDocument.AddEventHandler(PdfDocumentEvent.INSERT_PAGE, handle);
            return this;
        }

        /// <summary>
        /// 设置底部样式
        /// </summary>
        /// <returns></returns>
        public SparrowPdf SetFooter(Action<Footer> action)
        {
            action.Invoke(PageFooter);
            var handle = new FooterEvent(PageFooter, PdfFont);
            PdfDocument.AddEventHandler(PdfDocumentEvent.INSERT_PAGE, handle);
            return this;
        }
    }
}
