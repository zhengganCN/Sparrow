using iText.Layout.Element;
using Sparrow.Export.iTextSharp.Components;
using Sparrow.Export.iTextSharp.Models;

namespace Sparrow.Export.iTextSharp
{
    public partial class Pdf
    {
        public void AddTitle(PdfTitle pdfTitle)
        {
            var paragraph = new Paragraph(pdfTitle.Title ?? "");
            SetProperties(paragraph, pdfTitle);
            Document.Add(paragraph);
        }
        public Catalogue AddTitleWithBookmark(PdfTitle pdfTitle)
        {
            return AddTitle(pdfTitle, null);
        }

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
