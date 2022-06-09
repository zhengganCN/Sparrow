using iText.Kernel.Colors;
using iText.Kernel.Events;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Sparrow.Export.iTextSharp.Components;
using Sparrow.Export.iTextSharp.Events;
using System;
using System.IO;

namespace Sparrow.Export.iTextSharp
{
    /// <summary>
    /// Pdf
    /// </summary>
    public partial class Pdf : IDisposable
    {
        private static readonly string PdfFileName = Guid.NewGuid().ToString() + ".pdf";
        /// <summary>
        /// Pdf配置
        /// </summary>
        public static readonly PdfConfiguration Configuration = new PdfConfiguration();
        /// <summary>
        /// 文档
        /// </summary>
        public Document Document { get; private set; }
        /// <summary>
        /// 页面尺寸
        /// </summary>
        public PageSize PageSize { get; private set; }
        private FileStream FileStream { get; set; } = File.Create(PdfFileName);
        private PdfWriter PdfWriter { get; set; }
        private PdfDocument PdfDocument { get; set; }
        /// <summary>
        /// Pdf
        /// </summary>
        /// <param name="pageSize"></param>
        public Pdf(PageSize pageSize)
        {
            Init(pageSize, new PdfDocumentProperties());
        }
        /// <summary>
        /// Pdf
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="sparrow"></param>
        public Pdf(PageSize pageSize, PdfDocumentProperties sparrow)
        {
            Init(pageSize, sparrow);
        }

        private void Init(PageSize pageSize, PdfDocumentProperties sparrow)
        {
            PageSize = pageSize;
            FileStream.Write(EmptyPdf.Bytes, 0, EmptyPdf.Bytes.Length);
            PdfWriter = new PdfWriter(FileStream);
            PdfDocument = new PdfDocument(PdfWriter);
            Document = new Document(PdfDocument, pageSize);
            var handle = new PdfBackgroundEventHandler(sparrow);
            PdfDocument.AddEventHandler(PdfDocumentEvent.END_PAGE, handle);
            Document.SetFont(Configuration.PdfFont).SetFontSize(sparrow.FontSize);
        }

        /// <summary>
        /// 初始化pdf设置
        /// </summary>
        public static void Init(Action<PdfConfiguration> action)
        {
            action?.Invoke(Configuration);
        }

        private void BaseSave()
        {
            SetPdfBookmark();
            Document.Close();
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public byte[] Save()
        {
            BaseSave();
            return File.ReadAllBytes(PdfFileName);
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="path">路径</param>
        public void Save(string path)
        {
            BaseSave();
            File.Move(PdfFileName, path);
        }

        private static void SetProperties<T1, T2>(BlockElement<T1> element, PdfProperties<T2> properties) where T1 : IElement where T2 : class, new()
        {
            if (properties.BackgroundColor != null)
            {
                var color = Color.ConvertRgbToCmyk(properties.BackgroundColor);
                element.SetBackgroundColor(color);
            }
            if (properties.Width.HasValue)
            {
                element.SetWidth(properties.Width.Value);
            }
            if (properties.Height.HasValue)
            {
                element.SetHeight(properties.Height.Value);
            }
            SetPdfBlockElementFont(element, properties);
            SetPdfBlockElementMargin(element, properties);
            SetPdfBlockElementPadding(element, properties);
        }

        private static void SetPdfBlockElementFont<T1, T2>(BlockElement<T1> element, PdfProperties<T2> properties) where T1 : IElement where T2 : class, new()
        {
            element.SetTextAlignment(properties.TextAlignment);
            element.SetVerticalAlignment(properties.VerticalAlignment);
            if (properties.FontItalic)
            {
                element.SetItalic();
            }
            if (properties.FontColor != null)
            {
                var color = Color.ConvertRgbToCmyk(properties.FontColor);
                element.SetFontColor(color);
            }
            if (properties.FontSize.HasValue)
            {
                element.SetFontSize(properties.FontSize.Value);
            }
            if (properties.FontBold)
            {
                element.SetBold();
            }
        }

        private static void SetPdfBlockElementMargin<T1, T2>(BlockElement<T1> element, PdfProperties<T2> properties) where T1 : IElement where T2 : class, new()
        {
            if (properties.MarginLeft.HasValue)
            {
                element.SetMarginLeft(properties.MarginLeft.Value);
            }
            if (properties.MarginTop.HasValue)
            {
                element.SetMarginTop(properties.MarginTop.Value);
            }
            if (properties.MarginRight.HasValue)
            {
                element.SetMarginRight(properties.MarginRight.Value);
            }
            if (properties.MarginBottom.HasValue)
            {
                element.SetMarginBottom(properties.MarginBottom.Value);
            }
        }

        private static void SetPdfBlockElementPadding<T1, T2>(BlockElement<T1> element, PdfProperties<T2> properties) where T1 : IElement where T2 : class, new()
        {
            if (properties.PaddingLeft.HasValue)
            {
                element.SetPaddingLeft(properties.PaddingLeft.Value);
            }
            if (properties.PaddingTop.HasValue)
            {
                element.SetPaddingTop(properties.PaddingTop.Value);
            }
            if (properties.PaddingRight.HasValue)
            {
                element.SetPaddingRight(properties.PaddingRight.Value);
            }
            if (properties.PaddingBottom.HasValue)
            {
                element.SetPaddingBottom(properties.PaddingBottom.Value);
            }
        }

        /// <summary>
        /// 销毁
        /// </summary>
        public void Dispose()
        {
            Document.Close();
            if (File.Exists(PdfFileName))
            {
                File.Delete(PdfFileName);
            }
        }
    }
}
