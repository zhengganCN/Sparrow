using System.Collections.Generic;

namespace Sparrow.Export.iTextSharp
{
    /// <summary>
    /// 书签
    /// </summary>
    public class PdfBookmark : PdfProperties<PdfBookmark>
    {
        /// <summary>
        /// 目录列表
        /// </summary>
        public static List<Catalogue> Catalogues { get; private set; } = new List<Catalogue>();


    }
}
