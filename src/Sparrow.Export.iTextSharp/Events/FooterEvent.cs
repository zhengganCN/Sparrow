using iText.Kernel.Events;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace Sparrow.Export.iTextSharp.Events
{
    /// <summary>
    /// 页面底部绘制事件
    /// </summary>
    public class FooterEvent : IEventHandler
    {
        private readonly Footer _footer;
        /// <summary>
        /// 页面底部绘制事件
        /// </summary>
        /// <param name="footer">底部参数</param>
        public FooterEvent(Footer footer)
        {
            _footer = footer;
        }

        /// <summary>
        /// 事件处理
        /// </summary>
        /// <param name="event"></param>
        public void HandleEvent(Event @event)
        {
            var documentEvent = (PdfDocumentEvent)@event;
            var document = documentEvent.GetDocument();
            var page = documentEvent.GetPage();
            int pageNumber = document.GetPageNumber(page);
            var pageSize = page.GetPageSize();
            var stream = page.NewContentStreamBefore();
            var canvas = new PdfCanvas(stream, page.GetResources(), document);

            SetHeaderFooter(canvas, pageSize, pageNumber);
            SetPageNumber(canvas, pageSize, pageNumber);
            canvas.Release();

        }

        /// <summary>
        /// 设置页码
        /// </summary>
        /// <returns></returns>
        public void SetPageNumber(PdfCanvas canvas, Rectangle pageSize, int pageNumber)
        {
            if (_footer.IsShow)
            {
                var h = pageSize.GetHeight();
                var w = pageSize.GetWidth();
                var text = _footer.DefinePageText(pageNumber);
                canvas.BeginText()
                    //.SetFontAndSize(SparrowPdf.Font, 9)
                    .MoveText(pageSize.GetWidth() / 2 - 60, pageSize.GetTop() - 20)
                    .ShowText(text)
                    .MoveText(60, -pageSize.GetTop() + 30)
                    .ShowText(pageNumber.ToString())
                    .EndText();
            }
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
