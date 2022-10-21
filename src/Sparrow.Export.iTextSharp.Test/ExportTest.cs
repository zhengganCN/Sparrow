﻿
using iText.Kernel.Colors;
using iText.Kernel.Geom;
using NUnit.Framework;

namespace Sparrow.Export.iTextSharp.Test
{
    public class ExportTest
    {
        [Test]
        public void ExportMultipleTest()
        {
            for (int i = 0; i < 5; i++)
            {
                PdfFile();
            }
        }

        private static void PdfFile()
        {
            using var pdf = new SparrowPdf(PageSize.A4.Rotate());
            pdf.RegisterFont(Common.FontPath);
            pdf.SetBackground(new Background
            {
                Rgb = new DeviceRgb(85, 255, 235)
            });
            pdf.Save(Common.GenerateSavePath("ExportMultipleTest"));
        }
    }
}
