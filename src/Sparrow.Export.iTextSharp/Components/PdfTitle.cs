using Sparrow.Export.iTextSharp.Enums;

namespace Sparrow.Export.iTextSharp.Components
{
    public class PdfTitle : PdfProperties<PdfTitle>
    {
        public string Title { get; set; }
        public H H { get; private set; }

        public PdfTitle()
        {
            Init(string.Empty);
        }
        public PdfTitle(string title, H h = H.H1)
        {
            Init(title, h);
        }

        private void Init(string title, H h = H.H1)
        {
            Title = title;
            FontSize = (int)h;
            Element = this;
        }
    }
}
