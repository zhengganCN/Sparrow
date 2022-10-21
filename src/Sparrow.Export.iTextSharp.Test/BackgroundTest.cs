using iText.Kernel.Colors;
using iText.Kernel.Geom;
using NUnit.Framework;

namespace Sparrow.Export.iTextSharp.Test
{
    /// <summary>
    /// 背景测试
    /// </summary>
    public class BackgroundTest
    {
        [Test]
        public void BackgroundColorTest()
        {
            using var pdf = new SparrowPdf(PageSize.A4.Rotate());
            pdf.RegisterFont(Common.FontPath);
            pdf.SetBackground(new Background
            {
                Rgb = new DeviceRgb(85, 255, 235)
            });
            pdf.Save(Common.GenerateSavePath("BackgroundColorTest"));
        }
    }
}
