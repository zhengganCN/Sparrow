using iText.IO.Image;
using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf.Canvas;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;

namespace Sparrow.Export.iTextSharp.Events
{
    /// <summary>
    /// 水印绘制事件
    /// </summary>
    public class WaterMarkEvent : IEventHandler
    {
        private readonly WaterMark _mark;
        private readonly ImageWaterMark _imageMark;
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
        /// 水印绘制事件
        /// </summary>
        /// <param name="mark">水印参数</param>
        /// <param name="font">字体</param>
        public WaterMarkEvent(ImageWaterMark mark, PdfFont font)
        {
            _imageMark = mark;
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
            if (_mark != null)
            {
                SetWaterMark(pdfCanvas, pageSize);
            }
            else if (_imageMark != null)
            {
                SetImageWaterMark(pdfCanvas, pageSize);
            }
            pdfCanvas.Release();
        }

        private void SetWaterMark(PdfCanvas pdfCanvas, Rectangle pageSize)
        {
            if (string.IsNullOrWhiteSpace(_mark.Text))
            {
                return;
            }
            var width = pageSize.GetWidth();
            var height = pageSize.GetHeight();
            var avgW = width / _mark.HorizontalWaterMarks;
            var avgH = height / _mark.VerticalWaterMarks;
            var canvas = new Canvas(pdfCanvas, new Rectangle(width, height));
            canvas.SetFont(_font);
            if (_mark.FontColor != null)
            {
                canvas.SetFontColor(_mark.FontColor);
            }
            var halfaAvgW = avgW / 2;
            var halfAvgH = avgH / 2;
            for (int i = 0; i < _mark.HorizontalWaterMarks; i++)
            {
                for (int j = 0; j < _mark.VerticalWaterMarks; j++)
                {
                    var paragraph = new Paragraph(_mark.Text);
                    paragraph.SetOpacity(_mark.Opacity);
                    paragraph.SetFontSize(_mark.FontSize);
                    paragraph.SetRotationAngle(_mark.RotationAngle);
                    canvas.ShowTextAligned(paragraph, (i * avgW) + halfaAvgW, (j * avgH) + halfAvgH, TextAlignment.CENTER, VerticalAlignment.MIDDLE);
                }
            }
        }

        private void SetImageWaterMark(PdfCanvas pdfCanvas, Rectangle pageSize)
        {
            var width = pageSize.GetWidth();
            var height = pageSize.GetHeight();
            var avgW = width / _imageMark.HorizontalWaterMarks;
            var avgH = height / _imageMark.VerticalWaterMarks;
            var canvas = new Canvas(pdfCanvas, new Rectangle(width, height));
            canvas.SetFont(_font);
            var image = new Image(ImageDataFactory.Create(_imageMark.Image));
            var scaleH = image.GetImageScaledHeight() / avgH;
            var scaleW = image.GetImageScaledWidth() / avgW;
            var maxScale = Math.Max(scaleH, scaleW);
            var imageW = (image.GetImageScaledWidth() / maxScale) - 10;
            var imageH = (image.GetImageScaledHeight() / maxScale) - 10;
            image.SetHeight(imageH);
            image.SetWidth(imageW);
            image.SetOpacity(_imageMark.Opacity);
            image.SetRotationAngle(_imageMark.RotationAngle);
            var blankW = width - _imageMark.HorizontalWaterMarks * imageW;
            var blankH = height - _imageMark.VerticalWaterMarks * imageH;
            var avgBlackW = blankW / (_imageMark.HorizontalWaterMarks + 1);
            var avgBlackH = blankH / (_imageMark.VerticalWaterMarks + 1);
            for (int i = 0; i < _imageMark.HorizontalWaterMarks; i++)
            {
                for (int j = 0; j < _imageMark.VerticalWaterMarks; j++)
                {
                    var left = i * imageW + (i + 1) * avgBlackW;
                    var bottom = j * imageH + (j + 1) * avgBlackH;
                    image.SetFixedPosition(left, bottom);
                    canvas.Add(image);
                }
            }
        }
    }
}
