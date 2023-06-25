using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.XWPF.UserModel;
using System.Collections.Generic;

namespace Sparrow.Export.NPOI.Components
{
    /// <summary>
    /// Word表格
    /// </summary>
    public class WordTable
    {
        public XWPFTable Table { get; internal set; }
        /// <summary>
        /// 表格行数
        /// </summary>
        public int Rows { get; private set; }
        /// <summary>
        /// 添加行
        /// </summary>
        /// <returns></returns>
        public WordTableRow AddRow()
        {
            Rows++;
            var row = new XWPFTableRow(new CT_Row(), Table);
            Table.AddRow(row);
            return new WordTableRow
            {
                Table = Table,
                RowNum = Rows,
                Row = row
            };
        }

        /// <summary>
        /// 设置列宽
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <param name="width"></param>
        public void SetColumnWidth(int columnIndex, ulong width)
        {
            CT_Tbl cT_Tbl = Table.GetCTTbl();
            for (int i = 0; i <= columnIndex; i++)
            {
                if (cT_Tbl.tblGrid == null)
                {
                    cT_Tbl.tblGrid = cT_Tbl.AddNewTblGrid();
                }
                List<CT_TblGridCol> cT_TblGridCols = cT_Tbl.tblGrid.gridCol;
                if (cT_TblGridCols.Count < i + 1)
                {
                    cT_Tbl.tblGrid.AddNewGridCol();
                }
                if (columnIndex == i)
                {
                    cT_TblGridCols[i].w = width;
                }
            }
        }

        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="col">合并列</param>
        /// <param name="fromRow">合并的起始行，从0开始</param>
        /// <param name="toRow">合并的结束行</param>
        /// <returns>合并后的单元格</returns>
        public WordTableCell MergeRows(int col, int fromRow, int toRow)
        {
            for (int rowIndex = fromRow; rowIndex <= toRow; rowIndex++)
            {
                var cell = Table.GetRow(rowIndex).GetCell(col);
                CT_Tc cttc = cell.GetCTTc();
                if (cttc.tcPr == null)
                {
                    cttc.AddNewTcPr();
                }
                //第一个合并单元格用重启合并值设置
                if (rowIndex == fromRow)
                {
                    cell.GetCTTc().AddNewTcPr().AddNewVMerge().val = ST_Merge.restart;
                }
                else
                {
                    //合并第一个单元格的单元被设置为“继续”
                    cell.GetCTTc().AddNewTcPr().AddNewVMerge().val = ST_Merge.@continue;
                }
            }
            return new WordTableCell
            {
                Cell = Table.GetRow(fromRow).GetCell(col),
                ColNum = col + 1,
                Colspan = 1,
                Row = Table.GetRow(fromRow),
                RowNum = fromRow + 1,
                Table = Table
            };
        }
    }
}
