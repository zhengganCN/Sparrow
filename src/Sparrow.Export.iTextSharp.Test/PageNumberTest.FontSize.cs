using iText.Kernel.Geom;
using NUnit.Framework;

namespace Sparrow.Export.iTextSharp.Test
{
    internal partial class PageNumberTest
    {
        [Test]
        public void FooterPageNumberFontSizeTest()
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
                    page.FontSize = 15;
                });
            });
            for (int i = 0; i < 1000; i++)
            {
                pdf.AddTitle(new PdfTitle
                {
                    Title = "测试页码"
                });
            }
            pdf.Save(Common.GenerateSavePath("FooterPageNumberFontSizeTest"));
        }

        [Test]
        public void HeaderPageNumberFontSizeTest()
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
                    page.FontSize = 15;
                });
            });
            for (int i = 0; i < 1000; i++)
            {
                pdf.AddTitle(new PdfTitle
                {
                    Title = "测试页码"
                });
            }
            pdf.Save(Common.GenerateSavePath("HeaderPageNumberFontSizeTest"));
        }
    }
}
