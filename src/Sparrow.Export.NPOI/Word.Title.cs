using Sparrow.Export.NPOI.Components;
using Sparrow.Extension.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.Export.NPOI
{
    public partial class Word
    {
        public void AddTitle(WordTitle wordTitle)
        {
            var paragraph = XWPFDocument.CreateParagraph();
            var id = wordTitle.EnumTitle.GetDescription();
            paragraph.Style = id;
            paragraph.CreateRun().SetText(wordTitle.Title);
        }
    }
}
