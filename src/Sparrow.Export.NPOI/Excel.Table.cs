using NPOI.SS.UserModel;
using NPOI.SS.Util;
using Sparrow.Export.NPOI.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.Export.NPOI
{
    public partial class Excel
    {
        public void AddTable(ExcelTable table, string sheetName = "Sheet1")
        {
            var sheet = XSSFWorkbook.GetSheet(sheetName);
            if (sheet is null)
            {
                sheet = XSSFWorkbook.CreateSheet(sheetName);
            }
            for (int row =  0; row < table.Rows ; row++)
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
