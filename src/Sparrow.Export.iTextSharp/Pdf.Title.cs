using iText.Layout.Element;
using Sparrow.Export.iTextSharp.Components;
using Sparrow.Export.iTextSharp.Models;

namespace Sparrow.Export.iTextSharp
{
    public partial class Pdf
    {
        /// <summary>
        /// 添加标题
        /// </summary>
        /// <param name="pdfTitle">标题</param>
        public void AddTitle(PdfTitle pdfTitle)
        {
            var paragraph = new Paragraph(pdfTitle.Title ?? "");
            SetProperties(paragraph, pdfTitle);
            Document.Add(paragraph);
        }
        /// <summary>
        /// 添加标题
        /// </summary>
        /// <param name="pdfTitle">标题</param>
        /// <returns></returns>
        public Catalogue AddTitleWithBookmark(PdfTitle pdfTitle)
        {
            return AddTitle(pdfTitle, null);
        }
        /// <summary>
        /// 添加标题
        /// </summary>
        /// <param name="pdfTitle">标题</param>
        /// <param name="parentCatalogue">目录</param>
        /// <returns></returns>
        public Catalogue AddTitle(PdfTitle pdfTitle, Catalogue parentCatalogue)
        {
            AddTitle(pdfTitle);
            if (parentCatalogue is null)
            {
                parentCatalogue = new Catalogue
                {
                    Title = pdfTitle.Title ?? ""
                };
                PdfBookmark.Catalogues.Add(parentCatalogue);
                return parentCatalogue;
            }
            else
            {
                var childCatalogue = new Catalogue
                {
                    Title = pdfTitle.Title ?? ""
                };
                parentCatalogue.Children.Add(childCatalogue);
                return childCatalogue;
            }
        }

    }
}
