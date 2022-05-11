using iText.IO.Font;
using iText.Kernel.Font;

namespace Sparrow.Export.iTextSharp
{
    /// <summary>
    /// pdf 配置
    /// </summary>
    public class PdfConfiguration
    {
        internal string PdfFontName { get; private set; }
        internal PdfFont SysFont { get; private set; }
        public void RegisterPdfFont(string path, string name)
        {
            PdfFontFactory.Register(path);
            SysFont = PdfFontFactory.CreateRegisteredFont(name, PdfEncodings.IDENTITY_H,
               PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED, true);
            PdfFontName = name;
        }
    }
}
