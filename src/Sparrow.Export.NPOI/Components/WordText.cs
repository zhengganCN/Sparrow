using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.Export.NPOI.Components
{
    public class WordText
    {
        internal string Text { get; set; }

        public WordText(string text)
        {
            Text = text;
        }

        public int SpacingAfterLines { get; set; }
        public int SpacingAfter { get; set; }
        public bool IsPageBreak { get; set; }
        public Borders BorderBetween { get; set; }
        public string FillBackgroundColor { get; set; }
        public ST_Shd FillPattern { get; set; }
        public Borders BorderBottom { get; set; }
        public Borders BorderLeft { get; set; }
        public int SpacingBefore { get; set; }
        public Borders BorderTop { get; set; }
        public TextAlignment VerticalAlignment { get; set; }
        public int FontAlignment { get; set; }
        public Borders BorderRight { get; set; }
        public int SpacingBeforeLines { get; set; }
        public int IndentationLeft { get; set; }
        public ParagraphAlignment Alignment { get; set; }
        public int IndentationRight { get; set; }
        public int IndentationHanging { get; set; }
        public int IndentationFirstLine { get; set; }
        public int IndentFromLeft { get; set; }
        public int IndentFromRight { get; set; }
        public int FirstLineIndent { get; set; }
        public bool IsWordWrapped { get; set; }
        public string Style { get; set; }
        public LineSpacingRule SpacingLineRule { get; set; }

    }
}
