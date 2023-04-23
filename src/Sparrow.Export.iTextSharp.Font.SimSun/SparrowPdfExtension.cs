using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.Export.iTextSharp.Font.SimSun
{
    public static class SparrowPdfExtension
    {
        public static void RegisterFontSimSun(this SparrowPdf pdf)
        {
            pdf.RegisterFont(Resource1.simsun)
        }
    }
}
