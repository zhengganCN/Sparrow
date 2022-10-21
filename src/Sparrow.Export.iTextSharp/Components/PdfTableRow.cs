using System.Collections.Generic;

namespace Sparrow.Export.iTextSharp
{
    /// <summary>
    /// 表格行
    /// </summary>
    public class PdfTableRow
    {
        /// <summary>
        /// 行号
        /// </summary>
        public int RowNumber { get; private set; }
        /// <summary>
        /// 列数
        /// </summary>
        public int Columns { get; private set; } = 0;
        /// <summary>
        /// 表格单元格
        /// </summary>
        public List<PdfTableCell> Cells { get; private set; } = new List<PdfTableCell>();
        /// <summary>
        /// 表格行
        /// </summary>
        /// <param name="rowNumber">行号</param>
        public PdfTableRow(int rowNumber)
        {
            RowNumber = rowNumber;
        }

        /// <summary>
        /// 添加单元格
        /// </summary>
        /// <returns></returns>
        public PdfTableCell AddCell()
        {
            var cell = new PdfTableCell(RowNumber, ++Columns);
            Cells.Add(cell);
            return cell;
        }
    }
}
