using NPOI.OpenXmlFormats.Wordprocessing;

namespace Sparrow.Export.NPOI.Components
{
    /// <summary>
    /// Word表格
    /// </summary>
    public class WordTable
    {
        /// <summary>
        /// 表格行数
        /// </summary>
        public int Rows { get; }
        /// <summary>
        /// 表格列数
        /// </summary>
        public int Columns { get; }
        /// <summary>
        /// Word表格Cell
        /// </summary>
        public WordTableCell[,] Cells { get; }
        /// <summary>
        /// Word表格
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        public WordTable(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Cells = new WordTableCell[Rows, Columns];
        }
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
