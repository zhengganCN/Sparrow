using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace Sparrow.Export.iTextSharp.Events
{
    /// <summary>
    /// 水印绘制事件
    /// </summary>
    public class WaterMarkEvent : IEventHandler
    {
        private readonly WaterMark _mark;
        private readonly PdfFont _font;
        /// <summary>
        /// 水印绘制事件
        /// </summary>
        /// <param name="mark">水印参数</param>
        /// <param name="font">字体</param>
        public WaterMarkEvent(WaterMark mark, PdfFont font)
        {
            _mark = mark;
            _font = font;
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
            var pageSize = page.GetPageSize();
            var pdfStream = page.NewContentStreamBefore();
            var pdfCanvas = new PdfCanvas(pdfStream, page.GetResources(), pdfDocument);
            SetWaterMark(pdfCanvas, pageSize);
            pdfCanvas.Release();
        }

        private void SetWaterMark(PdfCanvas pdfCanvas, Rectangle pageSize)
        {
            if (string.IsNullOrWhiteSpace(_mark.Text))
            {
                return;
            }
            var h = pageSize.GetWidth() / _mark.HorizontalWaterMarks;
            var v = pageSize.GetHeight() / _mark.VerticalWaterMarks;
            for (int i = 0; i < _mark.HorizontalWaterMarks; i++)
            {
                for (int j = 0; j < _mark.VerticalWaterMarks; j++)
                {
                    var paragraph = new Paragraph(_mark.Text);
                    paragraph.SetOpacity(_mark.Opacity);
                    paragraph.SetFontSize(_mark.FontSize);
                    paragraph.SetRotationAngle(_mark.RotationAngle);
                    var canvas = new Canvas(pdfCanvas, pageSize);
                    if (_mark.FontColor != null)
                    {
                        canvas.SetFontColor(_mark.FontColor);
                    }
                    canvas.SetFont(_font);
                    canvas.ShowTextAligned(paragraph, (h + i * h), (v + j * v), TextAlignment.RIGHT);
                }
            }
        }
    }
}
