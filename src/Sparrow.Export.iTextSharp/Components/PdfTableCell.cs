using iText.Layout.Element;

namespace Sparrow.Export.iTextSharp.Components
{
    public class PdfTableCell : PdfProperties<PdfTableCell>
    {
        private Cell cell;
        public string Value { get; set; }
        public int Rowspan { get; set; }
        public int Colspan { get; set; }

        public PdfTableCell()
        {
            Init(1, 1, string.Empty);
        }

        public PdfTableCell(string value)
        {
            Init(1, 1, value);
        }

        public PdfTableCell(int rowspan, int colspan, string value)
        {
            Init(rowspan, colspan, value);
        }

        private void Init(int rowspan, int colspan, string value)
        {
            Rowspan = rowspan;
            Colspan = colspan;
            Value = value;
            Element = this;
        }


        public Cell GetCell()
        {
            cell = new Cell(Rowspan, Colspan);
            var paragraph = new Paragraph(Value ?? "");
            cell.Add(paragraph);
            return cell;
        }
    }
}
