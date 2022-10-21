using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Layout.Element;

namespace Sparrow.Export.iTextSharp
{
    public partial class SparrowPdf
    {

        private void SetPdfTableProperties(Table table, PdfTable pdfTable)
        {
            if (!pdfTable.Width.HasValue)
            {
                var width = Document.GetLeftMargin() * 2;
                table.SetWidth(PageSize.GetWidth() - width);
            }
            if (pdfTable.BackgroundColor != null)
            {
                var color = Color.ConvertRgbToCmyk(pdfTable.BackgroundColor);
                table.SetBackgroundColor(color);
            }
            SetProperties(table, pdfTable);
        }
        /// <summary>
        /// 添加表格
        /// </summary>
        /// <param name="pdfTable"></param>
        public void AddTable(PdfTable pdfTable)
        {
            var maxColNum = 0;
            foreach (var row in pdfTable.Rows)
            {
                var rowColNum = 0;
                foreach (var cell in row.Cells)
                {
                    rowColNum += cell.Colspan;
                }
                if (maxColNum < rowColNum)
                {
                    maxColNum = rowColNum;
                }
            }
            Table table = new Table(maxColNum);
            SetPdfTableProperties(table, pdfTable);
            foreach (var tableRow in pdfTable.Rows)
            {
                foreach (var column in tableRow.Cells)
                {
                    var cell = column.RendererCell();
                    SetProperties(cell, column);
                    table.AddCell(cell);
                }
            }
            Document.Add(table);
        }
    }
}
