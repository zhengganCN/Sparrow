using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.XWPF.UserModel;

namespace Sparrow.Export.NPOI.Styles
{
    /// <summary>
    /// 文本样式
    /// </summary>
    public class WordTextStyle
    {
        /// <summary>
        /// SpacingAfterLines
        /// </summary>
        public int SpacingAfterLines { get; set; }
        /// <summary>
        /// SpacingAfter
        /// </summary>
        public int SpacingAfter { get; set; }
        /// <summary>
        /// IsPageBreak
        /// </summary>
        public bool IsPageBreak { get; set; }
        /// <summary>
        /// BorderBetween
        /// </summary>
        public Borders BorderBetween { get; set; }
        /// <summary>
        /// 填充背景色
        /// </summary>
        public string FillBackgroundColor { get; set; }
        /// <summary>
        /// FillPattern
        /// </summary>
        public ST_Shd FillPattern { get; set; }
        /// <summary>
        /// 底部边框
        /// </summary>
        public Borders BorderBottom { get; set; }
        /// <summary>
        /// 左侧边框
        /// </summary>
        public Borders BorderLeft { get; set; }
        /// <summary>
        /// SpacingBefore
        /// </summary>
        public int SpacingBefore { get; set; }
        /// <summary>
        /// 顶部边框
        /// </summary>
        public Borders BorderTop { get; set; }
        /// <summary>
        /// 垂直对齐方式
        /// </summary>
        public TextAlignment VerticalAlignment { get; set; } = TextAlignment.CENTER;
        /// <summary>
        /// 字体对齐
        /// </summary>
        public int FontAlignment { get; set; }
        /// <summary>
        /// 右侧边框
        /// </summary>
        public Borders BorderRight { get; set; }
        /// <summary>
        /// SpacingBeforeLines
        /// </summary>
        public int SpacingBeforeLines { get; set; }
        /// <summary>
        /// IndentationLeft
        /// </summary>
        public int IndentationLeft { get; set; }
        /// <summary>
        /// 对齐
        /// </summary>
        public ParagraphAlignment Alignment { get; set; } = ParagraphAlignment.LEFT;
        /// <summary>
        /// IndentationRight
        /// </summary>
        public int IndentationRight { get; set; }
        /// <summary>
        /// IndentationHanging
        /// </summary>
        public int IndentationHanging { get; set; }
        /// <summary>
        /// IndentationFirstLine
        /// </summary>
        public int IndentationFirstLine { get; set; }
        /// <summary>
        /// IndentFromLeft
        /// </summary>
        public int IndentFromLeft { get; set; }
        /// <summary>
        /// IndentFromRight
        /// </summary>
        public int IndentFromRight { get; set; }
        /// <summary>
        /// FirstLineIndent
        /// </summary>
        public int FirstLineIndent { get; set; }
        /// <summary>
        /// IsWordWrapped
        /// </summary>
        public bool IsWordWrapped { get; set; }
        /// <summary>
        /// 样式
        /// </summary>
        public string Style { get; set; }
        /// <summary>
        /// SpacingLineRule
        /// </summary>
        public LineSpacingRule SpacingLineRule { get; set; }

    }
}
