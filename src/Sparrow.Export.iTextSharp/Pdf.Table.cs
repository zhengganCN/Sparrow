﻿using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Layout.Element;
using Sparrow.Export.iTextSharp.Components;
using System.Linq;

namespace Sparrow.Export.iTextSharp
{
    public partial class Pdf
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
        public void AddTable(PdfTable pdfTable)
        {
            if (pdfTable.Columns == 0 && pdfTable.Cells?.Any() == true)
            {
                pdfTable.Columns = pdfTable.Cells[0].Count;
            }
            var table = new Table(pdfTable.Columns);
            SetPdfTableProperties(table, pdfTable);
            foreach (var row in pdfTable.Cells)
            {
                foreach (var column in row)
                {
                    var cell = column.GetCell();
                    SetProperties(cell, column);
                    table.AddCell(cell);
                }
            }
            Document.Add(table);
        }
    }
}