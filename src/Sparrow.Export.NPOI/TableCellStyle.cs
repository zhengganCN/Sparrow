namespace Sparrow.Export.NPOI
{
    /// <summary>
    /// 表格单元格样式
    /// </summary>
    public class TableCellStyle
    {
        /// <summary>
        /// 垂直对齐方式
        /// </summary>
        public EnumWordTableCellVerticalAlignment VerticalAlignment { get; set; } = EnumWordTableCellVerticalAlignment.Center;
        /// <summary>
        /// 水平对齐方式
        /// </summary>
        public EnumWordTableCellHorizontalAlignment HorizontalAlignment { get; set; } = EnumWordTableCellHorizontalAlignment.Left;
        /// <summary>
        /// 字体颜色
        /// </summary>
        public string TextColor { get; set; }
        /// <summary>
        /// 单元格颜色
        /// </summary>
        public string CellColor { get; set; }
    }
}
