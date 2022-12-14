using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.XWPF.UserModel;
using Sparrow.Export.NPOI.Components;

namespace Sparrow.Export.NPOI
{
    public partial class SparrowWord
    {
        private void SetTableProperties(XWPFTable xWPFTable, WordTable table)
        {
            CT_Tbl ctTbl = xWPFTable.GetCTTbl();
            //设置表水平居中
            var cT_TblPr = ctTbl.AddNewTblPr();
            cT_TblPr.jc = new CT_Jc
            {
                val = table.TableAlign
            };
            CT_TblLayoutType type = cT_TblPr.AddNewTblLayout();
            if (table.Width.HasValue)
            {
                type.type = ST_TblLayoutType.@fixed;
                //设置表宽度
                var cT_TblWidth = ctTbl.AddNewTblPr().AddNewTblW();
                cT_TblWidth.w = table.Width?.ToString();
                cT_TblWidth.type = ST_TblWidth.dxa;
            }
            else
            {
                type.type = ST_TblLayoutType.autofit;
            }
        }
        /// <summary>
        /// 创建表格
        /// </summary>
        public void AddTable(WordTable table)
        {
            XWPFTable xWPFTable = XWPFDocument.CreateTable();
            SetTableProperties(xWPFTable, table);
            for (int row = 0; row < table.Rows; row++)
            {
                var xWPFTableRow = new XWPFTableRow(new CT_Row(), xWPFTable);
                var style = new TableCellStyle
                {
                    HorizontalAlignment = EnumWordTableCellHorizontalAlignment.Center
                };
                for (int column = 0; column < table.Columns; column++)
                {
                    var xWPFTableCell = xWPFTableRow.AddNewTableCell();
                    xWPFTableCell.SetText(table.Cells[row, column].WordTexts);
                }
                xWPFTable.AddRow(xWPFTableRow);
            }
            xWPFTable.RemoveRow(0);
        }


    }
}
