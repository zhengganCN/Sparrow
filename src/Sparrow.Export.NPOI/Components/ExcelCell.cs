namespace Sparrow.Export.NPOI.Components
{
    /// <summary>
    /// Excel的Cell
    /// </summary>
    public class ExcelCell
    {
        /// <summary>
        /// 文本
        /// </summary>
        public string Value { get; private set; }
        /// <summary>
        /// Excel的Cell
        /// </summary>
        /// <param name="value">文本</param>
        public ExcelCell(string value)
        {
            Value = value;
        }
    }
}
