using iText.Kernel.Geom;
using NUnit.Framework;

namespace Sparrow.Export.iTextSharp.Test
{
    internal class PageNumberTest
    {
        [Test]
        public void SimplePageNumberTest()
        {
            using var pdf = new SparrowPdf(PageSize.A4.Rotate());
            pdf.RegisterFont(Common.FontPath);
            for (int i = 0; i < 1000; i++)
            {
                pdf.AddTitle(new PdfTitle
                {
                    Title = "测试页码"
                });
            }            
            pdf.SetPageNumber(new PageNumber
            {
                DefinePageText = (num) =>
                {
                    return $"第{num}页";
                }
            });
            pdf.Save(Common.GenerateSavePath("SimplePageNumberTest"));
        }
    }
}
