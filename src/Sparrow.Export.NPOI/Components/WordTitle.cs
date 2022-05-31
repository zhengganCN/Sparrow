using Sparrow.Export.NPOI.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.Export.NPOI.Components
{
    public class WordTitle
    {
        public string Title { get; set; }
        public EnumTitle EnumTitle { get; set; } = EnumTitle.Header_1;
        public WordTitle(string title)
        {
            Title = title;
        }

        public WordTitle(string title, EnumTitle enumTitle)
        {
            Title = title;
            EnumTitle = enumTitle;
        }
    }
}
