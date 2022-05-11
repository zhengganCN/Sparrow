using System;

namespace Sparrow.Export.iTextSharp
{
    /// <summary>
    /// 初始化
    /// </summary>
    public class PdfInitialization
    {
        public static PdfConfiguration Configuration = new PdfConfiguration();

        public static void Initialization(Action<PdfConfiguration> action)
        {
            action?.Invoke(Configuration);
        }
    }
}
