using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.XWPF.UserModel;

namespace Sparrow.Export.NPOI.Components
{
    /// <summary>
    /// Word表格Cell
    /// </summary>
    public class WordTableCell
    {
        internal XWPFTableRow Row { get; set; }
        internal XWPFTableCell Cell { get; set; }
        internal XWPFTable Table { get; set; }
        /// <summary>
        /// 行号，从1开始
        /// </summary>
        internal int RowNum { get; set; }
        /// <summary>
        /// 列号，从1开始
        /// </summary>
        internal int ColNum { get; set; }
        /// <summary>
        /// 表格Cell所占列数
        /// </summary>
        public int Colspan { get; set; }
    }
}
