using iText.Kernel.Colors;
using iText.Kernel.Geom;
using NUnit.Framework;
using Sparrow.Export.iTextSharp.Enums;

namespace Sparrow.Export.iTextSharp.Test
{
    public partial class TableTest
    {
        private readonly string[] HeaderColumns = new[]
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

        [SetUp]
        public void Setup()
        {
        }

        private PdfTable GetPdfTable()
        {
            var table = new PdfTable().SetBackgroundColor(new DeviceRgb(232, 246, 240));
            var tableHeaderRow = table.AddRow();
            foreach (var header in HeaderColumns)
            {
                tableHeaderRow.AddCell()
                    .SetCellValue(header)
                    .SetFontBold(true)
                    .SetWidth(50);
            }
            for (int row = 0; row < 10; row++)
            {
                var tableContentRow = table.AddRow();
                for (int column = 0; column < HeaderColumns.Length; column++)
                {
                    tableContentRow.AddCell()
                        .SetCellValue("test");
                }
            }
            return table;
        }

        [Test]
        public void ExportFileTest()
        {
            using var pdf = new SparrowPdf(PageSize.A4.Rotate());
            pdf.RegisterFont(Common.FontPath);
            pdf.SetWaterMark(new WaterMark
            {
                Text = "水印测试",
                FontSize = 15,
                VerticalWaterMarks = 5
            });
            //pdf.SetBackgroundColor((color) => { return new DeviceRgb(171, 217, 252); });
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
            pdf.Save(Common.GenerateSavePath("导出pdf文件"));
            Assert.Pass();
        }

        [Test]
        public void ExportBytesTest()
        {
            using var pdf = new SparrowPdf(PageSize.A4);
            pdf.AddTable(GetPdfTable());
            pdf.Save();
            Assert.Pass();
        }
    }
}
