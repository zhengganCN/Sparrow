using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using System;
using System.IO;

namespace Sparrow.Export.iTextSharp
{
    public class Pdf : IDisposable
    {
        public Document Document { get; private set; }
        private static readonly string PdfFileName = Guid.NewGuid().ToString() + ".pdf";


        private FileStream FileStream { get; set; } = File.Create(PdfFileName);
        private PdfWriter PdfWriter { get; set; }
        private PdfDocument PdfDocument { get; set; }
        public Pdf(PageSize pageSize, float fontSize = 10)
        {
            FileStream.Write(EmptyPdf.Bytes, 0, EmptyPdf.Bytes.Length);
            PdfWriter = new PdfWriter(FileStream);
            PdfDocument = new PdfDocument(PdfWriter);
            Document = new Document(PdfDocument, pageSize);
            Document.SetFont(PdfInitialization.Configuration.SysFont).SetFontSize(fontSize);
        }

        public byte[] Save()
        {
            Document.Close();
            var buffer = File.ReadAllBytes(PdfFileName);
            return buffer;
        }

        public void Save(string path)
        {
            Document.Close();
            File.Move(PdfFileName, path);
        }

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
