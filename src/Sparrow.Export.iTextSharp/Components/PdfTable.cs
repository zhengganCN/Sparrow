using System.Collections.Generic;

namespace Sparrow.Export.iTextSharp.Components
{
    /// <summary>
    /// Pdf表格
    /// </summary>
    public class PdfTable : PdfProperties<PdfTable>
    {
        /// <summary>
        /// 列数
        /// </summary>
        public int Columns { get; set; }
        /// <summary>
        /// 列宽
        /// </summary>
        public float[] ColumnWidths { get; set; }
        /// <summary>
        /// 表格单元格
        /// </summary>
        public List<List<PdfTableCell>> Cells { get; private set; } = new List<List<PdfTableCell>>();

        /// <summary>
        /// Pdf表格
        /// </summary>
        public PdfTable()
        {
            Element = this;
        }

        /// <summary>
        /// Pdf表格
        /// </summary>
        public PdfTable(int columns)
        {
            Element = this;
            Columns = columns;
        }

        /// <summary>
        /// Pdf表格
        /// </summary>
        public PdfTable(float[] columnWidths)
        {
            Element = this;
            Columns = columnWidths.Length;
            ColumnWidths = columnWidths;
        }
    }
}
