using Sparrow.Export.NPOI.Enums;
using Sparrow.Extension.System;

namespace Sparrow.Export.NPOI
{
    public partial class SparrowWord
    {
        /// <summary>
        /// 添加标题
        /// </summary>
        /// <param name="title"></param>
        public void AddTitle(string title)
        {
            AddTitle(title, WordTitleType.Header_1);
        }

        /// <summary>
        /// 添加标题
        /// </summary>
        /// <param name="title"></param>
        /// <param name="type"></param>
        public void AddTitle(string title, WordTitleType type)
        {
            var paragraph = XWPFDocument.CreateParagraph();
            var id = type.GetDescription();
            paragraph.Style = id;
            paragraph.CreateRun().SetText(title);
        }
    }
}
