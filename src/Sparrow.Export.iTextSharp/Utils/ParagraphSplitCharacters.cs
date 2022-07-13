using iText.IO.Font.Otf;
using iText.Layout.Splitting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.Export.iTextSharp.Utils
{
    internal class ParagraphSplitCharacters : DefaultSplitCharacters
    {
        public override bool IsSplitCharacter(GlyphLine text, int glyphPos)
        {
            return true;
        }
    }
}
