using iText.Kernel.Geom;
using NUnit.Framework;
using Sparrow.Export.iTextSharp.Components;
using System;
using System.Collections.Generic;

namespace Sparrow.Export.iTextSharp.Test
{
    public class TableCellContentTest
    {
        [SetUp]
        public void Setup()
        {
            var path = System.IO.Path.Combine(AppContext.BaseDirectory, "resource/simsun.ttc");
            Pdf.Init((c) => { c.RegisterPdfFont(path); });
        }

        [Test]
        public void ExportTableCellContentWrapTabTest()
        {
            using var pdf = new Pdf(PageSize.A4.Rotate());
            pdf.AddTable(GetPdfTable());
            pdf.Save(Common.GenerateSavePath("表格单元格内容换行符与制表符测试"));
            Assert.Pass();
        }

        private PdfTable GetPdfTable()
        {
            var headers = new[]
            {
                "序号",
                "姓名",
                "身份证",
                "针次",
                "接种时间",
                "下一次接种日期",
                "性别",
                "年龄",
                "手机号码",
                "接种单位",
                "在职项目"
            };
            var table = new PdfTable(headers.Length);
            var headerCells = new List<PdfTableCell>();
            foreach (var header in headers)
            {
                var cell = new PdfTableCell(header).SetFontBold(true).SetWidth(50);
                headerCells.Add(cell.Element);
            }
            table.Element.Cells.Add(headerCells);
            for (int row = 0; row < 10; row++)
            {
                var rowCells = new List<PdfTableCell>();
                for (int column = 0; column < headers.Length; column++)
                {
                    rowCells.Add(new PdfTableCell("test"));
                }
                table.Element.Cells.Add(rowCells);
            }
            table.Element.Cells.Add(new List<PdfTableCell>
            {
                new PdfTableCell("{\n\t\"list\"\n }",2,5).SetTextAlignment(iText.Layout.Properties.TextAlignment.LEFT).Element,
                new PdfTableCell("打道回府打道回府打道回府打道回府打道回府打道回府打道回府打道回府打道回府打道回府打道回府",1,6),
                new PdfTableCell("打道回府描述",1,6)
            });
            table.Element.Cells.Add(new List<PdfTableCell>
            {
                new PdfTableCell("打道回府",2,11).SetHeight(100).Element
            });
            return table.Element;
        }
    }
}
