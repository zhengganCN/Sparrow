using NPOI.OpenXmlFormats.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.Export.NPOI.Styles
{
    /// <summary>
    /// 表格样式
    /// </summary>
    public class WordTableStyle
    {
        /// <summary>
        /// 表格对齐方式
        /// </summary>
        public ST_Jc TableAlign { get; set; } = ST_Jc.center;
        /// <summary>
        /// 表格宽度
        /// </summary>
        public int? Width { get; set; }
    }
}
