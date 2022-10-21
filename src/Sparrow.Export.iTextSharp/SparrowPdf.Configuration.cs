using iText.IO.Font;
using iText.Kernel.Font;
using System.IO;

namespace Sparrow.Export.iTextSharp
{
    public partial class SparrowPdf
    {
        /// <summary>
        /// 注册字体
        /// </summary>
        /// <param name="path">路径</param>
        public void RegisterFont(string path)
        {
            var file = new FileInfo(path);
            RegisterFont(path, file.Name.Split('.')[0]);
        }

        /// <summary>
        /// 注册字体
        /// </summary>
        /// <param name="path">路径</param>
        /// <param name="name">字体名称</param>
        public void RegisterFont(string path, string name)
        {
            PdfFontFactory.Register(path);
            var encoding = PdfEncodings.IDENTITY_H;
            //嵌入策略
            var strategy = PdfFontFactory.EmbeddingStrategy.PREFER_EMBEDDED;
            PdfFont = PdfFontFactory.CreateRegisteredFont(name, encoding, strategy, true);
            Document.SetFont(PdfFont);
        }


    }
}
