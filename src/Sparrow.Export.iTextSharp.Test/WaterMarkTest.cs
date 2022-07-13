using iText.Kernel.Colors;
using iText.Kernel.Geom;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow.Export.iTextSharp.Test
{
    public class WaterMarkTest
    {
        [SetUp]
        public void Setup()
        {
            var path = System.IO.Path.Combine(AppContext.BaseDirectory, "resource/simsun.ttc");
            Pdf.Init((c) => { c.RegisterPdfFont(path); });
        }

        [Test]
        public void ExportWaterMarkTest()
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
            pdf.Save(Common.GenerateSavePath("水印测试"));
        }
    }
}
