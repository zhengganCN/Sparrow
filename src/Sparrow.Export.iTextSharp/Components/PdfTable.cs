using System.Collections.Generic;

namespace Sparrow.Export.iTextSharp.Components
{
    public class PdfTable : PdfProperties<PdfTable>
    {
        public PdfTable()
        {
            Element = this;
        }
        public int Columns { get; set; }
        public List<List<PdfTableCell>> Cells { get; set; } = new List<List<PdfTableCell>>();
    }
}
