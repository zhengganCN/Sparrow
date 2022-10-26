using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas;

namespace Sparrow.Export.iTextSharp.Events
{
    /// <summary>
    /// 页面底部绘制事件
    /// </summary>
    public class FooterEvent : IEventHandler
    {
        private readonly Footer _footer;
        private PdfFont _font;
        /// <summary>
        /// 页面底部绘制事件
        /// </summary>
        /// <param name="footer">底部参数</param>
        /// <param name="font">字体</param>
        public FooterEvent(Footer footer, PdfFont font)
        {
            _footer = footer;
            _font = font;
        }

        /// <summary>
        /// 事件处理
        /// </summary>
        /// <param name="event"></param>
        public void HandleEvent(Event @event)
        {
            var documentEvent = (PdfDocumentEvent)@event;
            var document = documentEvent.GetDocument();
            if (_font is null)
            {
                _font = document.GetDefaultFont();
            }
            var page = documentEvent.GetPage();
            int pageNumber = document.GetPageNumber(page);
            var rectangle = page.GetPageSize();
            var stream = page.NewContentStreamBefore();
            var canvas = new PdfCanvas(stream, page.GetResources(), document);
            SetPageNumber(canvas, rectangle, pageNumber);
            canvas.Release();

        }

        /// <summary>
        /// 设置页码
        /// </summary>
        /// <returns></returns>
        public void SetPageNumber(PdfCanvas canvas, Rectangle rectangle, int pageNumber)
        {
            if (_footer.PageNumber.IsShow)
            {
                var text = _footer.PageNumber.DefinePageText(pageNumber);
                var count = text.Length;
                canvas.BeginText();
                canvas.SetFontAndSize(_font, _footer.PageNumber.FontSize);
                var x = _footer.PageNumber.StartX(rectangle, count);
                var y = _footer.PageNumber.StartY(rectangle);
                canvas.MoveText(x, y).ShowText(text);
                canvas.EndText();
            }
        }

    }
}
