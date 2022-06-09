using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Action;
using Sparrow.Export.iTextSharp.Components;
using Sparrow.Export.iTextSharp.Models;
using System.Collections.Generic;
using System.Linq;

namespace Sparrow.Export.iTextSharp
{
    public partial class Pdf
    {
        /// <summary>
        /// 设置书签
        /// </summary>
        public void SetPdfBookmark()
        {
            if (PdfBookmark.Catalogues is null || !PdfBookmark.Catalogues.Any())
            {
                return;
            }
            var pdfDocument = Document.GetPdfDocument();
            if (pdfDocument.HasOutlines())
            {
                pdfDocument.InitializeOutlines();
            }
            var outline = pdfDocument.GetOutlines(true);
            foreach (var catalogue in PdfBookmark.Catalogues)
            {
                var topOutline = outline.AddOutline(catalogue.Title);
                var pdfAction = PdfAction.CreateGoToR(catalogue.Title, catalogue.LinkPageNumber);
                topOutline.AddAction(pdfAction);
                AddChild(topOutline, catalogue.Children);
            }
        }

        private void AddChild(PdfOutline outline, List<Catalogue> catalogues)
        {
            if (catalogues is null || !catalogues.Any())
            {
                return;
            }
            foreach (var item in catalogues)
            {
                var childOutline = outline.AddOutline(item.Title);
                var pdfAction = PdfAction.CreateGoToR(item.Title, item.LinkPageNumber);
                childOutline.AddAction(pdfAction);
                AddChild(childOutline, item.Children);
            }
        }
    }
}
