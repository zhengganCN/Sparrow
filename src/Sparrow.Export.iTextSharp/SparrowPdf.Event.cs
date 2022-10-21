using iText.Kernel.Events;
using iText.Layout.Element;
using iText.Layout.Properties;
using Sparrow.Export.iTextSharp.Events;

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
        public SparrowPdf SetHeader()
        {
            var handle = new HeaderEvent();
            PdfDocument.AddEventHandler(PdfDocumentEvent.INSERT_PAGE, handle);
            return this;
        }

        /// <summary>
        /// 设置底部样式
        /// </summary>
        /// <returns></returns>
        public SparrowPdf SetFooter(Footer footer)
        {
            var handle = new FooterEvent(footer);
            PdfDocument.AddEventHandler(PdfDocumentEvent.INSERT_PAGE, handle);
            return this;
        }
    }
}
