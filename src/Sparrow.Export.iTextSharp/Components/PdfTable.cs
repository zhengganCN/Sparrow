using System.Collections.Generic;

namespace Sparrow.Export.iTextSharp
{
    /// <summary>
    /// Pdf表格
    /// </summary>
    public class PdfTable : PdfProperties<PdfTable>
    {
        /// <summary>
        /// 列宽
        /// </summary>
        public float[] ColumnWidths { get; set; }
        /// <summary>
        /// 表格行列表
        /// </summary>
        public List<PdfTableRow> Rows { get; private set; } = new List<PdfTableRow>();
        /// <summary>
        /// Pdf表格
        /// </summary>
        public PdfTable()
        {
            Element = this;
        }

        /// <summary>
        /// 添加行
        /// </summary>
        /// <returns></returns>
        public PdfTableRow AddRow()
        {
            var row = new PdfTableRow(Rows.Count + 1);
            Rows.Add(row);
            return row;
        }
    }
}
