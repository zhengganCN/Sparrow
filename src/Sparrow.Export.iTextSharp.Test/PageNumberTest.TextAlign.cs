using iText.Kernel.Geom;
using NUnit.Framework;

namespace Sparrow.Export.iTextSharp.Test
{
    internal partial class PageNumberTest
    {
        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void FooterPageNumberTextAlignTest(int textAlign)
        {
            using var pdf = new SparrowPdf(PageSize.A4.Rotate());
            pdf.RegisterFont(Common.FontPath);
            var align = (PageNumber.EnumTextAlign)textAlign;
            pdf.SetFooter((footer) =>
            {
                footer.SetPageNumber(page =>
                {
                    page.IsShow = true;
                    page.DefinePageText = (num) =>
                    {
                        return $"第{num}页";
                    };
                    page.TextAlign = align;
                });
            });
            for (int i = 0; i < 1000; i++)
            {
                pdf.AddTitle(new PdfTitle
                {
                    Title = "测试页码"
                });
            }
            pdf.Save(Common.GenerateSavePath("FooterPageNumberTextAlignTest" + align.ToString()));
        }

        [Test]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void HeaderPageNumberTextAlignTest(int textAlign)
        {
            using var pdf = new SparrowPdf(PageSize.A4.Rotate());
            pdf.RegisterFont(Common.FontPath);
            var align = (PageNumber.EnumTextAlign)textAlign;
            pdf.SetHeader((header) =>
            {
                header.SetPageNumber(page =>
                {
                    page.IsShow = true;
                    page.DefinePageText = (num) =>
                    {
                        return $"第{num}页";
                    };
                    page.TextAlign = align;
                });
            });
            for (int i = 0; i < 1000; i++)
            {
                pdf.AddTitle(new PdfTitle
                {
                    Title = "测试页码"
                });
            }
            pdf.Save(Common.GenerateSavePath("HeaderPageNumberTextAlignTest" + align.ToString()));
        }
    }
}
