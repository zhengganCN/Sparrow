using iText.Kernel.Colors;
using iText.Kernel.Geom;
using NUnit.Framework;

namespace Sparrow.Export.iTextSharp.Test
{
    public partial class TableTest
    {

        [Test]
        public void BackgroundColorTest()
        {
            using var pdf = new SparrowPdf(PageSize.A4.Rotate());
            pdf.RegisterFont(Common.FontPath);
            var rgb = new DeviceRgb(255, 0, 0);
            var table = new PdfTable().SetBackgroundColor(rgb);
            table.AddRow().AddCell().SetCellValue("background color");
            pdf.AddTable(table);
            pdf.Save(Common.GenerateSavePath("BackgroundColorTest"));
            Assert.Pass();
        }
    }
}
