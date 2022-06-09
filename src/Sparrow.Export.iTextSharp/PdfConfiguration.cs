using iText.IO.Font;
using iText.Kernel.Font;
using System.IO;

namespace Sparrow.Export.iTextSharp
{
    /// <summary>
    /// pdf配置
    /// </summary>
    public class PdfConfiguration
    {
        internal PdfFont PdfFont { get; private set; }
        /// <summary>
        /// 注册字体
        /// </summary>
        /// <param name="path">路径</param>
        public void RegisterPdfFont(string path)
        {
            var file = new FileInfo(path);
            RegisterPdfFont(path, file.Name.Split('.')[0]);
        }

        /// <summary>
        /// 注册字体
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="name">字体名称</param>
        public void RegisterPdfFont(string path, string name)
        {
            PdfFontFactory.Register(path);
            PdfFont = PdfFontFactory.CreateRegisteredFont(name, PdfEncodings.IDENTITY_H,
               PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED, true);
        }
    }
}
