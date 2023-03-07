using iText.Kernel.Colors;
using iText.Kernel.Geom;
using NUnit.Framework;
using System;
using System.IO;

namespace Sparrow.Export.iTextSharp.Test
{
    /// <summary>
    /// 水印测试
    /// </summary>
    public class WaterMarkTest
    {
        [Test]
        public void SimpleWaterMarkTest()
        {
            using var pdf = new SparrowPdf(PageSize.A4.Rotate());
            pdf.RegisterFont(Common.FontPath);
            pdf.SetWaterMark(new WaterMark
            {
                Text = "水印测试",
                FontSize = 15,
                VerticalWaterMarks = 5
            });
            pdf.Save(Common.GenerateSavePath("SimpleWaterMarkTest"));
        }

        [Test]
        public void MinCountWaterMarkTest()
        {
            using var pdf = new SparrowPdf(PageSize.A4.Rotate());
            pdf.RegisterFont(Common.FontPath);
            pdf.SetWaterMark(new WaterMark
            {
                Text = "水印测试",
                FontSize = 15,
                VerticalWaterMarks = 1,
                HorizontalWaterMarks = 1
            });
            pdf.Save(Common.GenerateSavePath("MinCountWaterMarkTest"));
        }

        [Test]
        public void OpacityWaterMarkTest()
        {
            using var pdf = new SparrowPdf(PageSize.A4.Rotate());
            pdf.RegisterFont(Common.FontPath);
            pdf.SetWaterMark(new WaterMark
            {
                Text = "水印测试",
                FontSize = 15,
                VerticalWaterMarks = 5,
                Opacity = 0.8f
            });
            pdf.Save(Common.GenerateSavePath("OpacityWaterMarkTest"));
        }

        [Test]
        public void RotationAngleWaterMarkTest()
        {
            using var pdf = new SparrowPdf(PageSize.A4.Rotate());
            pdf.RegisterFont(Common.FontPath);
            pdf.SetWaterMark(new WaterMark
            {
                Text = "水印测试",
                FontSize = 15,
                VerticalWaterMarks = 5,
                RotationAngle = 0.9f
            });
            pdf.Save(Common.GenerateSavePath("RotationAngleWaterMarkTest"));
        }

        [Test]
        public void FontColorWaterMarkTest()
        {
            using var pdf = new SparrowPdf(PageSize.A4.Rotate());
            pdf.RegisterFont(Common.FontPath);
            pdf.SetWaterMark(new WaterMark
            {
                Text = "水印测试",
                FontSize = 15,
                VerticalWaterMarks = 5,
                FontColor = new DeviceRgb(249, 62, 62)
            });
            pdf.Save(Common.GenerateSavePath("FontColorWaterMarkTest"));
        }

        [Test]
        public void LongTextWaterMarkTest()
        {
            using var pdf = new SparrowPdf(PageSize.A4.Rotate());
            pdf.RegisterFont(Common.FontPath);
            pdf.SetWaterMark(new WaterMark
            {
                Text = "长文本水印测试长文本水印测试长文本水印测试长文本水印测试长文本水印测试",
                FontSize = 15,
                VerticalWaterMarks = 5,
            });
            pdf.Save(Common.GenerateSavePath("LongTextWaterMarkTest"));
        }


        [Test]
        public void ImageWaterMarkTest()
        {
            var path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "resource/1638175710256.jpg");
            var image = File.ReadAllBytes(path);
            using var pdf = new SparrowPdf(PageSize.A4.Rotate());
            pdf.RegisterFont(Common.FontPath);
            pdf.SetWaterMark(new ImageWaterMark
            {
                Image = image,
                VerticalWaterMarks = 5,
            });
            pdf.Save(Common.GenerateSavePath("ImageWaterMarkTest"));
        }
    }
}
