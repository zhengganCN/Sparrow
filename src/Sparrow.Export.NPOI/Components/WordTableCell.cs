using NPOI.XWPF.UserModel;
using System.Collections.Generic;

namespace Sparrow.Export.NPOI.Components
{
    public class WordTableCell
    {
        private XWPFTableCell Cell { get; set; }
        public List<WordText> WordTexts { get; set; }
        public int Width { get; set; }
        public int Rowspan { get; set; }
        public int Colspan { get; set; }

        public WordTableCell()
        {
            Init(1, 1, null);
        }

        public WordTableCell(WordText value)
        {
            Init(1, 1, new List<WordText> { value });
        }
        public WordTableCell(List<WordText> value)
        {
            Init(1, 1, value);
        }


        private void Init(int rowspan, int colspan, List<WordText> value)
        {
            Rowspan = rowspan;
            Colspan = colspan;
            WordTexts = value;
            //Element = this;
        }


        public XWPFTableCell GetCell()
        {

            return Cell;
        }
    }
}
