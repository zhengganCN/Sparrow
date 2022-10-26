using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using System;
using System.IO;

namespace Sparrow.Export.iTextSharp
{
    /// <summary>
    /// Pdf文档
    /// </summary>
    public partial class SparrowPdf : IDisposable
    {
        private readonly string FileName = Guid.NewGuid().ToString() + ".pdf";
        /// <summary>
        /// 文档
        /// </summary>
        public Document Document { get; private set; }

        private PdfDocument PdfDocument { get; set; }
        /// <summary>
        /// 字体
        /// </summary>
        public PdfFont PdfFont { get; private set; }
        /// <summary>
        /// 显示页面号码
        /// </summary>
        public bool ShowPageNumber { get; set; } = false;
        /// <summary>
        /// 头部文本
        /// </summary>
        public string HeaderText { get; set; }
        /// <summary>
        /// 页面尺寸
        /// </summary>
        public PageSize PageSize { get; private set; }
        internal Header PageHeader { get; private set; } = new Header();
        internal Footer PageFooter { get; private set; } = new Footer();
        /// <summary>
        /// Pdf文档
        /// </summary>
        /// <param name="pageSize"></param>
        public SparrowPdf(PageSize pageSize)
        {
            PageSize = pageSize;
            var file = File.Create(FileName);
            file.Write(EmptyPdf.Bytes, 0, EmptyPdf.Bytes.Length);
            var writer = new PdfWriter(file);
            PdfDocument = new PdfDocument(writer);
            Document = new Document(PdfDocument, pageSize);
        }

        /// <summary>
        /// 销毁
        /// </summary>
        public void Dispose()
        {
            Document.Close();
            if (File.Exists(FileName))
            {
                File.Delete(FileName);
            }
        }
    }
}
