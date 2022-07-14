using iText.Layout.Element;
using Sparrow.Export.iTextSharp.Utils;

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
        /// 单词换行(true：当为连续的字母时，不换行；false：当为连续的字母时，达到最大宽度后换行)
        /// </summary>
        public bool IsWordWrap { get; set; } = true;
        /// <summary>
        /// 启用空格处理
        /// </summary>
        public bool EnableSpaceHandle { get; set; } = true;
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
        /// 设置单词换行(true：当为连续的字母时，不换行；false：当为连续的字母时，达到最大宽度后换行)
        /// </summary>
        /// <returns></returns>
        public PdfTableCell SetIsWordWrap(bool isWordWrap)
        {
            IsWordWrap = isWordWrap;
            return Element;
        }

        /// <summary>
        /// 获取Cell
        /// </summary>
        /// <returns></returns>
        public Cell GetCell()
        {
            cell = new Cell(Rowspan, Colspan);
            var value = (Value ?? "");
            if (EnableSpaceHandle)
            {
                value.Replace("\t", "\u00A0\u00A0").Replace(' ', '\u00A0');
            }
            var paragraph = new Paragraph(value);
            if (!IsWordWrap)
            {
                paragraph.SetSplitCharacters(new ParagraphSplitCharacters());
            }
            cell.Add(paragraph);
            return cell;
        }
    }
}
