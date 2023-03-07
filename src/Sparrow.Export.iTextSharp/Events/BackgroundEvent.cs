using iText.Kernel.Events;
using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas;

namespace Sparrow.Export.iTextSharp.Events
{
    /// <summary>
    /// 背景色绘制事件
    /// </summary>
    public class BackgroundEvent : IEventHandler
    {
        private Background _background;
        /// <summary>
        /// 背景色绘制事件
        /// </summary>
        /// <param name="background">背景参数</param>
        public BackgroundEvent(Background background)
        {
            _background = background;
        }

        /// <summary>
        /// 事件处理
        /// </summary>
        /// <param name="event"></param>
        public void HandleEvent(Event @event)
        {
            var documentEvent = (PdfDocumentEvent)@event;
            var pdfDocument = documentEvent.GetDocument();
            var page = documentEvent.GetPage();
            int pageNumber = pdfDocument.GetPageNumber(page);
            var pageSize = page.GetPageSize();
            var pdfStream = page.NewContentStreamBefore();
            var pdfCanvas = new PdfCanvas(pdfStream, page.GetResources(), pdfDocument);
            SetBackgroundColor(pdfCanvas, pageSize, pageNumber);
            pdfCanvas.Release();
        }

        private void SetBackgroundColor(PdfCanvas pdfCanvas, Rectangle pageSize, int pageNumber)
        {
            pdfCanvas.SaveState()
                .SetFillColor(_background.Rgb)
                .Rectangle(pageSize.GetLeft(), pageSize.GetBottom(),
                    pageSize.GetWidth(), pageSize.GetHeight())
                .Fill()
                .RestoreState();
        }
    }
}
