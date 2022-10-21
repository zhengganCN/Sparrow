using iText.Kernel.Events;
using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas;

namespace Sparrow.Export.iTextSharp.Events
{
    /// <summary>
    /// Pdf背景色事件处理程序
    /// </summary>
    public class HeaderEvent : IEventHandler
    {
        //private PdfDocumentProperties Sparrow { get; set; }
        ///// <summary>
        ///// Pdf背景色事件处理程序
        ///// </summary>
        ///// <param name="sparrow"></param>
        //public PdfBackgroundEventHandler(PdfDocumentProperties sparrow)
        //{
        //    Sparrow = sparrow;
        //}
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

            SetHeaderFooter(pdfCanvas, pageSize, pageNumber);

            pdfCanvas.Release();

        }



        private void SetHeaderFooter(PdfCanvas pdfCanvas, Rectangle pageSize, int pageNumber)
        {
            //pdfCanvas.BeginText()
            //    //.SetFontAndSize(SparrowPdf.Font, 9)
            //    .MoveText(pageSize.GetWidth() / 2 - 60, pageSize.GetTop() - 20)
            //    .ShowText(string.IsNullOrWhiteSpace(Sparrow.HeaderText) ? "" : Sparrow.HeaderText)
            //    .MoveText(60, -pageSize.GetTop() + 30)
            //    .ShowText(pageNumber.ToString())
            //    .EndText();
        }



    }
}
