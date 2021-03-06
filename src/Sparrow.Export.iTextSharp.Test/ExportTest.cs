using iText.Kernel.Colors;
using iText.Kernel.Geom;
using NUnit.Framework;
using Sparrow.Export.iTextSharp.Components;
using Sparrow.Export.iTextSharp.Enums;
using System;
using System.Collections.Generic;

namespace Sparrow.Export.iTextSharp.Test
{
    public class ExportTest
    {
        [SetUp]
        public void Setup()
        {
            var path = System.IO.Path.Combine(AppContext.BaseDirectory, "resource/simsun.ttc");
            Pdf.Init((c) => { c.RegisterPdfFont(path); });
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
            var table = new PdfTable(headers.Length).SetBackgroundColor(new DeviceRgb(232, 246, 240));
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
                new PdfTableCell("打道回府打道回府打道回府打道回府打道回府打道回府打道回府打道回府打道回府打道回府打道回府",2,5),
                new PdfTableCell("打道回府打道回府打道回府打道回府打道回府打道回府打道回府打道回府打道回府打道回府打道回府",1,6),
                new PdfTableCell("打道回府描述",1,6)
            });
            table.Element.Cells.Add(new List<PdfTableCell>
            {
                new PdfTableCell("打道回府",2,11).SetHeight(100).Element
            });
            return table.Element;
        }

        [Test]
        public void ExportFileTest()
        {
            var sparrow = new PdfDocumentProperties();
            sparrow.SetWaterMark((water) =>
            {
                water.Text = "水印测试";
                water.FontSize = 15;
                water.VerticalWaterMarks = 5;
            });
            sparrow.SetBackgroundColor((color) => { return new DeviceRgb(171, 217, 252); });
            using var pdf = new Pdf(PageSize.A4.Rotate(), sparrow);

            var top1 = pdf.AddTitleWithBookmark(new PdfTitle("标题一", H.H1));
            pdf.AddTitle(new PdfTitle("Top-1-1"), top1);
            var top1child2 = pdf.AddTitle(new PdfTitle("Top-1-2"), top1);
            pdf.AddTitle(new PdfTitle("Top-1-2-1"), top1child2);
            pdf.AddTitleWithBookmark(new PdfTitle("标题二", H.H2));
            pdf.AddTitleWithBookmark(new PdfTitle("标题三", H.H3));
            pdf.AddTitleWithBookmark(new PdfTitle("标题四", H.H4));
            pdf.AddTitleWithBookmark(new PdfTitle("标题五", H.H5));
            pdf.AddTitleWithBookmark(new PdfTitle("标题六", H.H6));
            pdf.AddTable(GetPdfTable());
            pdf.AddTable(GetPdfTable());
            pdf.AddTable(GetPdfTable());
            pdf.AddTable(GetPdfTable());
            pdf.AddTable(GetPdfTable());
            pdf.AddTable(GetPdfTable());
            pdf.AddTable(GetPdfTable());
            pdf.AddTable(GetPdfTable());
            pdf.AddTable(GetPdfTable());
            pdf.AddTable(GetPdfTable());
            pdf.Save(Common.GenerateSavePath("导出pdf文件"));
            Assert.Pass();
        }

        [Test]
        public void ExportBytesTest()
        {
            using var pdf = new Pdf(PageSize.A4);
            pdf.AddTable(GetPdfTable());
            pdf.Save();
            Assert.Pass();
        }
    }
}