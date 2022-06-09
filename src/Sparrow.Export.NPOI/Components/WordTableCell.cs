using NPOI.XWPF.UserModel;
using System.Collections.Generic;

namespace Sparrow.Export.NPOI.Components
{
    /// <summary>
    /// Word表格Cell
    /// </summary>
    public class WordTableCell
    {
        private XWPFTableCell Cell { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public List<WordText> WordTexts { get; set; }
        /// <summary>
        /// 表格Cell宽度
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 表格Cell所占行数
        /// </summary>
        public int Rowspan { get; set; }
        /// <summary>
        /// 表格Cell所占列数
        /// </summary>
        public int Colspan { get; set; }
        /// <summary>
        /// Word表格Cell
        /// </summary>
        public WordTableCell()
        {
            Init(1, 1, null);
        }
        /// <summary>
        /// Word表格Cell
        /// </summary>
        /// <param name="value">内容</param>
        public WordTableCell(WordText value)
        {
            Init(1, 1, new List<WordText> { value });
        }
        /// <summary>
        /// Word表格Cell
        /// </summary>
        /// <param name="value">内容</param>
        public WordTableCell(List<WordText> value)
        {
            Init(1, 1, value);
        }


        private void Init(int rowspan, int colspan, List<WordText> value)
        {
            Rowspan = rowspan;
            Colspan = colspan;
            WordTexts = value;
        }

        /// <summary>
        /// 获取Cell
        /// </summary>
        /// <returns></returns>
        public XWPFTableCell GetCell()
        {
            return Cell;
        }
    }
}
