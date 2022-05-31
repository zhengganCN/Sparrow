using NUnit.Framework;
using Sparrow.Export.NPOI.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow.Export.NPOI.Test.ExcelTest
{
    public class ExportTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ExportExcelTest()
        {
            
            using var excel = new Excel();
            excel.AddTable(GetExcelTable());
            var table = GetExcelTable();
            table.StartColumn = 20;
            excel.AddTable(table,"sld");

            if (!Directory.Exists("files"))
            {
                Directory.CreateDirectory("files");
            }
            excel.Save(Path.Combine("files", Guid.NewGuid().ToString() + ".xlsx"));
        }

        private static ExcelTable GetExcelTable()
        {
            var table = new ExcelTable(10, 7)
            {
                Width = 8000,
                StartRow = 1,
                StartColumn = 1,
            };
            for (int row = 0; row < table.Rows; row++)
            {
                for (int column = 0; column < table.Columns; column++)
                {
                    table[row, column] = new ExcelCell("测试");
                }
            }
            return table;
        }

    }
}
