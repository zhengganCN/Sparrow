using iText.Kernel.Events;
using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace Sparrow.Export.iTextSharp.Events
{
    /// <summary>
    /// Pdf背景色事件处理程序
    /// </summary>
    public class PdfBackgroundEventHandler : IEventHandler
    {
        private PdfDocumentProperties Sparrow { get; set; }
        /// <summary>
        /// Pdf背景色事件处理程序
        /// </summary>
        /// <param name="sparrow"></param>
        public PdfBackgroundEventHandler(PdfDocumentProperties sparrow)
        {
            Sparrow = sparrow;
        }
        /// <summary>
        /// 事件处理
        /// </summary>
        /// <param name="event"></param>
        public void HandleEvent(Event @event)
        {
            if (Sparrow is null)
            {
                return;
            }
            var documentEvent = (PdfDocumentEvent)@event;
            var pdfDocument = documentEvent.GetDocument();
            var page = documentEvent.GetPage();
            int pageNumber = pdfDocument.GetPageNumber(page);
            var pageSize = page.GetPageSize();
            var pdfStream = page.NewContentStreamBefore();
            var pdfCanvas = new PdfCanvas(pdfStream, page.GetResources(), pdfDocument);

            SetBackgroundColor(pdfCanvas, pageSize, pageNumber);
            SetHeaderFooter(pdfCanvas, pageSize, pageNumber);
            SetWaterMark(pdfCanvas, pageSize);

            pdfCanvas.Release();

        }

        private void SetBackgroundColor(PdfCanvas pdfCanvas, Rectangle pageSize, int pageNumber)
        {
            if (Sparrow.BackgroundColor is null)
            {
                return;
            }
            var rgb = Sparrow.BackgroundColor.Invoke(pageNumber);
            pdfCanvas.SaveState()
                .SetFillColor(rgb)
                .Rectangle(pageSize.GetLeft(), pageSize.GetBottom(),
                    pageSize.GetWidth(), pageSize.GetHeight())
                .Fill()
                .RestoreState();
        }

        private void SetHeaderFooter(PdfCanvas pdfCanvas, Rectangle pageSize, int pageNumber)
        {
            pdfCanvas.BeginText()
                .SetFontAndSize(Pdf.Configuration.PdfFont, 9)
                .MoveText(pageSize.GetWidth() / 2 - 60, pageSize.GetTop() - 20)
                .ShowText(string.IsNullOrWhiteSpace(Sparrow.HeaderText) ? "" : Sparrow.HeaderText)
                .MoveText(60, -pageSize.GetTop() + 30)
                .ShowText(pageNumber.ToString())
                .EndText();
        }

        private void SetWaterMark(PdfCanvas pdfCanvas, Rectangle pageSize)
        {
            if (string.IsNullOrWhiteSpace(Sparrow.WaterMark.Text))
            {
                return;
            }
            var h = pageSize.GetWidth() / Sparrow.WaterMark.HorizontalWaterMarks;
            var v = pageSize.GetHeight() / Sparrow.WaterMark.VerticalWaterMarks;
            for (int i = 0; i < Sparrow.WaterMark.HorizontalWaterMarks; i++)
            {
                for (int j = 0; j < Sparrow.WaterMark.VerticalWaterMarks; j++)
                {
                    var paragraph = new Paragraph(Sparrow.WaterMark.Text);
                    paragraph.SetOpacity(Sparrow.WaterMark.Opacity);
                    paragraph.SetFontSize(Sparrow.WaterMark.FontSize);
                    paragraph.SetRotationAngle(Sparrow.WaterMark.RotationAngle);
                    var canvas = new Canvas(pdfCanvas, pageSize);
                    if (Sparrow.WaterMark.FontColor != null)
                    {
                        canvas.SetFontColor(Sparrow.WaterMark.FontColor);
                    }
                    canvas.SetFont(Pdf.Configuration.PdfFont);
                    canvas.ShowTextAligned(paragraph, (h + i * h), (v + j * v), TextAlignment.RIGHT);
                }
            }
        }

    }
}
