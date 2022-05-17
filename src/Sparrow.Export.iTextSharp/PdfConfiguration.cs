using iText.IO.Font;
using iText.Kernel.Font;
using System.IO;

namespace Sparrow.Export.iTextSharp
{
    /// <summary>
    /// pdf 配置
    /// </summary>
    public class PdfConfiguration
    {
        internal PdfFont PdfFont { get; private set; }
        public void RegisterPdfFont(string path)
        {
            var file = new FileInfo(path);
            RegisterPdfFont(path, file.Name.Split('.')[0]);
        }

        public void RegisterPdfFont(string path, string name)
        {
            PdfFontFactory.Register(path);
            PdfFont = PdfFontFactory.CreateRegisteredFont(name, PdfEncodings.IDENTITY_H,
               PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED, true);
        }
    }
}
