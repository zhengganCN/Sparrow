using iText.Kernel.Colors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.Export.iTextSharp
{
    /// <summary>
    /// 图片水印
    /// </summary>
    public class ImageWaterMark
    {
        /// <summary>
        /// 透明度
        /// </summary>
        public float Opacity { get; set; } = 0.5f;
        /// <summary>
        /// 图片
        /// </summary>
        public byte[] Image { get; set; }
        /// <summary>
        /// 水平方向水印数量
        /// </summary>
        public int HorizontalWaterMarks { get; set; } = 5;
        /// <summary>
        /// 垂直方向水印数量
        /// </summary>
        public int VerticalWaterMarks { get; set; } = 10;
        /// <summary>
        /// 旋转
        /// </summary>
        public float RotationAngle { get; set; } = 0.5f;
    }
}
