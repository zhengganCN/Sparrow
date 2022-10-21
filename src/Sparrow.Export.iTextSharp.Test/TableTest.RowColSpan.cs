using iText.Kernel.Geom;
using NUnit.Framework;

namespace Sparrow.Export.iTextSharp.Test
{
    public partial class TableTest
    {
        [Test]
        public void ColspanTest()
        {
            using var pdf = new SparrowPdf(PageSize.A4.Rotate());
            pdf.RegisterFont(Common.FontPath);
            var table = new PdfTable();
            var row_1 = table.AddRow();
            row_1.AddCell().SetCellValue("hellow row 1 col 1").SetColspan(3);
            var row_2 = table.AddRow();
            row_2.AddCell().SetCellValue("hellow row 2 col 1").SetColspan(1);
            row_2.AddCell().SetCellValue("hellow row 2 col 2").SetColspan(1);
            row_2.AddCell().SetCellValue("hellow row 2 col 3").SetColspan(1);
            pdf.AddTable(table);
            pdf.Save(Common.GenerateSavePath("ColspanTestt"));
        }

        [Test]
        public void RowspanTest()
        {
            using var pdf = new SparrowPdf(PageSize.A4.Rotate());
            pdf.RegisterFont(Common.FontPath);
            var table = new PdfTable();
            var row_1 = table.AddRow();
            row_1.AddCell().SetCellValue("hellow row 1 col 1");
            row_1.AddCell().SetCellValue("hellow row 1 col 2");
            row_1.AddCell().SetCellValue("hellow row 1 col 3").SetRowspan(2);
            var row_2 = table.AddRow();
            row_2.AddCell().SetCellValue("hellow row 2 col 1");
            row_2.AddCell().SetCellValue("hellow row 2 col 2");
            pdf.AddTable(table);
            pdf.Save(Common.GenerateSavePath("RowspanTest"));
        }

        [Test]
        public void RowsColsSpanTest()
        {
            using var pdf = new SparrowPdf(PageSize.A4.Rotate());
            pdf.RegisterFont(Common.FontPath);
            var table = new PdfTable();
            var row_1 = table.AddRow();
            row_1.AddCell().SetCellValue("hellow row 1 col 1").SetColspan(3);
            var row_2 = table.AddRow();
            row_2.AddCell().SetCellValue("hellow row 2 col 1").SetColspan(1);
            row_2.AddCell().SetCellValue("hellow row 2 col 2").SetColspan(1);
            row_2.AddCell().SetCellValue("hellow row 2 col 3").SetColspan(1);
            var row_3 = table.AddRow();
            row_3.AddCell().SetCellValue("hellow row 3 col 1").SetColspan(2);
            row_3.AddCell().SetCellValue("hellow row 3 col 2").SetColspan(1);
            var row_4 = table.AddRow();
            row_4.AddCell().SetCellValue("hellow row 4 col 1").SetColspan(1);
            row_4.AddCell().SetCellValue("hellow row 4 col 2").SetColspan(1);
            row_4.AddCell().SetCellValue("hellow row 4 col 3").SetRowspan(2);
            var row_5 = table.AddRow();
            row_5.AddCell().SetCellValue("hellow row 5 col 1").SetColspan(1);
            row_5.AddCell().SetCellValue("hellow row 5 col 2").SetColspan(1);
            pdf.AddTable(table);
            pdf.Save(Common.GenerateSavePath("RowsColsSpanTest"));
        }
    }
}
