using Sparrow.Export.NPOI.Components;

namespace Sparrow.Export.NPOI
{
    public partial class Excel
    {
        /// <summary>
        /// 添加表格
        /// </summary>
        /// <param name="table"></param>
        /// <param name="sheetName"></param>
        public void AddTable(ExcelTable table, string sheetName = "Sheet1")
        {
            var sheet = XSSFWorkbook.GetSheet(sheetName);
            if (sheet is null)
            {
                sheet = XSSFWorkbook.CreateSheet(sheetName);
            }
            for (int row = 0; row < table.Rows; row++)
            {
                var sheetRow = sheet.GetRow(row + table.StartRow);
                if (sheetRow is null)
                {
                    sheetRow = sheet.CreateRow(row + table.StartRow);
                }
                for (int column = 0; column < table.Columns; column++)
                {
                    var sheetColumn = sheetRow.GetCell(column + table.StartColumn);
                    if (sheetColumn is null)
                    {
                        sheetColumn = sheetRow.CreateCell(column + table.StartColumn);
                    }

                    sheetColumn.SetCellValue(table[row, column].Value);

                }
            }
            table.SetStyle(XSSFWorkbook, sheet);
        }
    }
}
