using Sparrow.Export.NPOI.Components;
using Sparrow.Extension.System;

namespace Sparrow.Export.NPOI
{
    public partial class SparrowWord
    {
        /// <summary>
        /// 添加标题
        /// </summary>
        /// <param name="wordTitle"></param>
        public void AddTitle(WordTitle wordTitle)
        {
            var paragraph = XWPFDocument.CreateParagraph();
            var id = wordTitle.EnumTitle.GetDescription();
            paragraph.Style = id;
            paragraph.CreateRun().SetText(wordTitle.Title);
        }
    }
}
