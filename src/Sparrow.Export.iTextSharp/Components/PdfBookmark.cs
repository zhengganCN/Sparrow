using Sparrow.Export.iTextSharp.Models;
using System.Collections.Generic;

namespace Sparrow.Export.iTextSharp.Components
{
    public class PdfBookmark : PdfProperties<PdfBookmark>
    {
        public static List<Catalogue> Catalogues { get; private set; } = new List<Catalogue>();


    }
}
