using System.Collections.Generic;

namespace Sparrow.Export.iTextSharp.Components
{
    /// <summary>
    /// Pdf表格
    /// </summary>
    public class PdfTable : PdfProperties<PdfTable>
    {
        /// <summary>
        /// Pdf表格
        /// </summary>
        public PdfTable()
        {
            Element = this;
        }
        /// <summary>
        /// 列数
        /// </summary>
        public int Columns { get; set; }

        public List<List<PdfTableCell>> Cells { get; set; } = new List<List<PdfTableCell>>();
    }
}
