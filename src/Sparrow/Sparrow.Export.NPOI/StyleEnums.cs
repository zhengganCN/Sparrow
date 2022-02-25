﻿namespace Sparrow.Export.NPOI
{
    /// <summary>
    /// 表格单元格的水平对齐方式
    /// </summary>
    public enum EnumWordTableCellHorizontalAlignment
    {
        /// <summary>
        /// 左对齐 
        /// </summary>
        Left = 0,
        /// <summary>
        /// 居中
        /// </summary>
        Center = 1,
        /// <summary>
        /// 右对齐
        /// </summary>
        Right = 2,
        /// <summary>
        /// 两端对齐
        /// </summary>
        Both = 3,
        /// <summary>
        /// 中等Kashida长度
        /// </summary>
        MediumKashida = 4,
        /// <summary>
        /// 平均分配所有字符
        /// </summary>
        Distribute = 5,
        /// <summary>
        /// 对齐到列表选项卡
        /// </summary>
        NumTab = 6,
        /// <summary>
        /// 高等Kashida长度
        /// </summary>
        HighKashida = 7,
        /// <summary>
        /// 低等Kashida长度
        /// </summary>
        LowKashida = 8,
        /// <summary>
        /// 泰语对齐
        /// </summary>
        ThaiDistribute = 9
    }
    /// <summary>
    /// 表格单元格的垂直对齐方式
    /// </summary>
    public enum EnumWordTableCellVerticalAlignment
    {
        /// <summary>
        /// 顶部对齐
        /// </summary>
        Top = 0,
        /// <summary>
        /// 居中
        /// </summary>
        Center = 1,
        /// <summary>
        /// 两端对齐
        /// </summary>
        Both = 2,
        /// <summary>
        /// 底部对齐
        /// </summary>
        Bottom = 3
    }
}
