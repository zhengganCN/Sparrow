using iText.Layout.Element;

namespace Sparrow.Export.iTextSharp.Components
{
    /// <summary>
    /// Pdf表格Cell
    /// </summary>
    public class PdfTableCell : PdfProperties<PdfTableCell>
    {
        private Cell cell;
        /// <summary>
        /// 文本
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Cell所占行数
        /// </summary>
        public int Rowspan { get; set; }
        /// <summary>
        /// Cell所占列数
        /// </summary>
        public int Colspan { get; set; }
        /// <summary>
        /// Pdf表格Cell
        /// </summary>
        public PdfTableCell()
        {
            Init(string.Empty, 1, 1);
        }
        /// <summary>
        /// Pdf表格Cell
        /// </summary>
        /// <param name="value">文本</param>
        public PdfTableCell(string value)
        {
            Init(value, 1, 1);
        }
        /// <summary>
        /// Pdf表格Cell
        /// </summary>
        /// <param name="value"></param>
        /// <param name="rowspan"></param>
        /// <param name="colspan"></param>
        public PdfTableCell(string value, int rowspan, int colspan)
        {
            Init(value, rowspan, colspan);
        }

        private void Init(string value, int rowspan, int colspan)
        {
            Rowspan = rowspan;
            Colspan = colspan;
            Value = value;
            Element = this;
        }

        /// <summary>
        /// 获取Cell
        /// </summary>
        /// <returns></returns>
        public Cell GetCell()
        {
            cell = new Cell(Rowspan, Colspan);
            var paragraph = new Paragraph(Value ?? "");
            cell.Add(paragraph);
            return cell;
        }
    }
}
