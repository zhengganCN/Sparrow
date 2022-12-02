using iText.Layout.Element;
using Sparrow.Export.iTextSharp.Utils;

namespace Sparrow.Export.iTextSharp
{
    /// <summary>
    /// Pdf表格Cell
    /// </summary>
    public class PdfTableCell : PdfProperties<PdfTableCell>
    {
        /// <summary>
        /// 行号
        /// </summary>
        public int RowNumber { get; private set; }
        /// <summary>
        /// 列号
        /// </summary>
        public int ColumnNumber { get; private set; }
        /// <summary>
        /// Cell所占行数
        /// </summary>
        public int Rowspan { get; private set; } = 1;
        /// <summary>
        /// Cell所占列数
        /// </summary>
        public int Colspan { get; private set; } = 1;
        /// <summary>
        /// 文本
        /// </summary>
        public string Value { get; private set; }
        /// <summary>
        /// 单词换行(true：当为连续的字母时，不换行；false：当为连续的字母时，达到最大宽度后换行)
        /// </summary>
        public bool IsWordWrap { get; private set; } = true;
        /// <summary>
        /// 启用空格处理
        /// </summary>
        public bool EnableSpaceHandle { get; private set; } = true;

        /// <summary>
        /// 表格单元格
        /// </summary>
        /// <param name="value">文本</param>
        /// <param name="rowNumber">行号</param>
        /// <param name="columnNumber">列号</param>
        public PdfTableCell(string value, int rowNumber, int columnNumber)
        {
            Element = this;
            Value = value;
            RowNumber = rowNumber;
            ColumnNumber = columnNumber;
        }

        /// <summary>
        /// 设置Cell所占行数
        /// </summary>
        /// <param name="rowspan">行数</param>
        /// <returns></returns>
        public PdfTableCell SetRowspan(int rowspan)
        {
            Rowspan = rowspan;
            return this;
        }

        /// <summary>
        /// 设置Cell所占列数
        /// </summary>
        /// <param name="colspan">列数</param>
        /// <returns></returns>
        public PdfTableCell SetColspan(int colspan)
        {
            Colspan = colspan;
            return this;
        }

        /// <summary>
        /// 启用空格处理
        /// </summary>
        public PdfTableCell SetEnableSpaceHandle(bool enableSpaceHandle)
        {
            EnableSpaceHandle = enableSpaceHandle;
            return this;
        }

        /// <summary>
        /// 设置单词换行(true：当为连续的字母时，不换行；false：当为连续的字母时，达到最大宽度后换行)
        /// </summary>
        /// <returns></returns>
        public PdfTableCell SetIsWordWrap(bool isWordWrap)
        {
            IsWordWrap = isWordWrap;
            return this;
        }

        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="value"></param>
        public PdfTableCell SetCellValue(string value)
        {
            Value = value;
            return this;
        }

        /// <summary>
        /// 生成单元格
        /// </summary>
        /// <returns></returns>
        public Cell RendererCell()
        {
            var cell = new Cell(Rowspan, Colspan);
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
