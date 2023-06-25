using NPOI.XWPF.UserModel;
using System;

namespace Sparrow.Export.NPOI.Components
{
    /// <summary>
    /// 表格行
    /// </summary>
    public class WordTableRow
    {
        internal XWPFTableRow Row { get; set; }
        internal XWPFTable Table { get; set; }
        public int RowNum { get; internal set; }
        /// <summary>
        /// 表格列数
        /// </summary>
        public int Columns { get; private set; }
        public WordTableCell AddCell()
        {
            return AddCell(1);
        }


        public WordTableCell AddCell(int colspan)
        {
            if (colspan < 1)
            {
                throw new ArgumentException($"{nameof(colspan)} must be greater than 0");
            }
            Columns++;
            var cell = Row.AddNewTableCell();
            if (colspan > 1)
            {
                for (int i = 0; i < colspan - 1; i++)
                {
                    Row.AddNewTableCell();
                }
                Row.MergeCells(Columns - 1, Columns + colspan - 2);
            }
            return new WordTableCell
            {
                Colspan = colspan,
                Row = Row,
                RowNum = RowNum,
                ColNum = Columns,
                Cell = cell,
                Table = Table
            };
        }
    }
}
