using iText.Kernel.Colors;
using iText.Kernel.Geom;
using iText.Layout.Element;
using Sparrow.Export.iTextSharp.Components;
using System;
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
        /// <summary>
        /// 添加表格
        /// </summary>
        /// <param name="pdfTable"></param>
        public void AddTable(PdfTable pdfTable)
        {
            if (pdfTable.Columns == 0)
            {
                throw new ArgumentException($"{nameof(pdfTable.Columns)}不能为0");
            }
            Table table;
            if (pdfTable.ColumnWidths?.Any() == true)
            {
                table = new Table(pdfTable.ColumnWidths);
            }
            else
            {
                table = new Table(pdfTable.Columns);
            }
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
