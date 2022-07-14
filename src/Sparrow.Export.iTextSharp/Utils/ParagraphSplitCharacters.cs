using iText.IO.Font.Otf;
using iText.Layout.Splitting;

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
