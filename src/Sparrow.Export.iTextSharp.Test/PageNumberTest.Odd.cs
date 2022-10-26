using iText.Kernel.Geom;
using NUnit.Framework;

namespace Sparrow.Export.iTextSharp.Test
{
    internal partial class PageNumberTest
    {
        [Test]
        public void FooterNotOddPageNumberTest()
        {
            using var pdf = new SparrowPdf(PageSize.A4.Rotate());
            pdf.RegisterFont(Common.FontPath);
            pdf.SetFooter((footer) =>
            {
                footer.SetPageNumber(page =>
                {
                    page.IsShow = true;
                    page.DefinePageText = (num) =>
                    {
                        return $"第{num}页";
                    };
                });
            });
            for (int i = 0; i < 1000; i++)
            {
                pdf.AddTitle(new PdfTitle
                {
                    Title = "测试页码"
                });
            }
            pdf.Save(Common.GenerateSavePath("FooterNotOddPageNumberTest"));
        }

        [Test]
        public void HeaderNotOddPageNumberTest()
        {
            using var pdf = new SparrowPdf(PageSize.A4.Rotate());
            pdf.RegisterFont(Common.FontPath);
            pdf.SetHeader((header) =>
            {
                header.SetPageNumber(page =>
                {
                    page.IsShow = true;
                    page.DefinePageText = (num) =>
                    {
                        return $"第{num}页";
                    };
                });
            });
            for (int i = 0; i < 1000; i++)
            {
                pdf.AddTitle(new PdfTitle
                {
                    Title = "测试页码"
                });
            }
            pdf.Save(Common.GenerateSavePath("HeaderNotOddPageNumberTest"));
        }
    }
}
