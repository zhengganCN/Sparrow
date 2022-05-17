using iText.Kernel.Colors;

namespace Sparrow.Export.iTextSharp.Models
{
    public class WaterMark
    {
        public float Opacity { get; set; } = 0.5f;
        public string Text { get; set; }
        public int HorizontalWaterMarks { get; set; } = 5;
        public int VerticalWaterMarks { get; set; } = 10;
        public DeviceRgb FontColor { get; set; } = new DeviceRgb(0, 0, 0);
        public float RotationAngle { get; set; } = 0.5f;
        public float FontSize { get; set; } = 15;
    }
}
