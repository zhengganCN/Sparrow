using iText.Kernel.Geom;
using NUnit.Framework;

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
                VerticalWaterMarks = 5,
            });
            pdf.Save(Common.GenerateSavePath("SimpleWaterMarkTest"));
        }
    }
}
