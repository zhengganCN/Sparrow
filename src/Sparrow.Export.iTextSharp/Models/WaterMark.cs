using iText.Kernel.Colors;

namespace Sparrow.Export.iTextSharp
{
    /// <summary>
    /// 水印
    /// </summary>
    public class WaterMark
    {
        /// <summary>
        /// 透明度
        /// </summary>
        public float Opacity { get; set; } = 0.5f;
        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 水平方向水印数量
        /// </summary>
        public int HorizontalWaterMarks { get; set; } = 5;
        /// <summary>
        /// 垂直方向水印数量
        /// </summary>
        public int VerticalWaterMarks { get; set; } = 10;
        /// <summary>
        /// 字体颜色
        /// </summary>
        public DeviceRgb FontColor { get; set; } = new DeviceRgb(0, 0, 0);
        /// <summary>
        /// 旋转
        /// </summary>
        public float RotationAngle { get; set; } = 0.5f;
        /// <summary>
        /// 字体大小
        /// </summary>
        public float FontSize { get; set; } = 15;
    }
}
