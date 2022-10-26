using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas;

namespace Sparrow.Export.iTextSharp.Events
{
    /// <summary>
    /// Pdf背景色事件处理程序
    /// </summary>
    public class HeaderEvent : IEventHandler
    {
        private readonly Header _header;
        private PdfFont _font;
        /// <summary>
        /// 页面底部绘制事件
        /// </summary>
        /// <param name="header">首部参数</param>
        /// <param name="font">字体</param>
        public HeaderEvent(Header header, PdfFont font)
        {
            _header = header;
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
            if (_header.PageNumber.IsShow)
            {
                var text = _header.PageNumber.DefinePageText(pageNumber);
                var count = text.Length;
                canvas.BeginText();
                canvas.SetFontAndSize(_font, _header.PageNumber.FontSize);
                var x = _header.PageNumber.StartX(rectangle, count);
                var y = _header.PageNumber.StartY(rectangle);
                canvas.MoveText(x, y).ShowText(text);
                canvas.EndText();
            }
        }

    }
}
