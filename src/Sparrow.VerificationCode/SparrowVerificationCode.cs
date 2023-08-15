using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sparrow.VerificationCode
{
    /// <summary>
    /// 验证码操作
    /// </summary>
    public static class SparrowVerificationCode
    {
        /// <summary>
        /// 颜色集合
        /// </summary>
        private static readonly List<SKColor> Colors = new List<SKColor>
        {
            SKColors.AliceBlue,
            SKColors.PaleGreen,
            SKColors.PaleGoldenrod,
            SKColors.Orchid,
            SKColors.OrangeRed,
            SKColors.Orange,
            SKColors.OliveDrab,
            SKColors.Olive,
            SKColors.OldLace,
            SKColors.Navy,
            SKColors.NavajoWhite,
            SKColors.Moccasin,
            SKColors.MistyRose,
            SKColors.MintCream,
            SKColors.MidnightBlue,
            SKColors.MediumVioletRed,
            SKColors.MediumTurquoise,
            SKColors.MediumSpringGreen,
            SKColors.LightSteelBlue,
            SKColors.LightYellow,
            SKColors.Lime,
            SKColors.LimeGreen,
            SKColors.Linen,
            SKColors.PaleTurquoise,
            SKColors.Magenta,
            SKColors.MediumAquamarine,
            SKColors.MediumBlue,
            SKColors.MediumOrchid,
            SKColors.MediumPurple,
            SKColors.MediumSeaGreen,
            SKColors.MediumSlateBlue,
            SKColors.Maroon,
            SKColors.PaleVioletRed,
            SKColors.PapayaWhip,
            SKColors.PeachPuff,
            SKColors.Snow,
            SKColors.SpringGreen,
            SKColors.SteelBlue,
            SKColors.Tan,
            SKColors.Teal,
            SKColors.Thistle,
            SKColors.Tomato,
            SKColors.Violet,
            SKColors.Wheat,
            SKColors.White,
            SKColors.WhiteSmoke,
            SKColors.Yellow,
            SKColors.YellowGreen,
            SKColors.Turquoise,
            SKColors.LightSkyBlue,
            SKColors.SlateBlue,
            SKColors.Silver,
            SKColors.Peru,
            SKColors.Pink,
            SKColors.Plum,
            SKColors.PowderBlue,
            SKColors.Purple,
            SKColors.Red,
            SKColors.SkyBlue,
            SKColors.RosyBrown,
            SKColors.SaddleBrown,
            SKColors.Salmon,
            SKColors.SandyBrown,
            SKColors.SeaGreen,
            SKColors.SeaShell,
            SKColors.Sienna,
            SKColors.RoyalBlue,
            SKColors.LightSeaGreen,
            SKColors.LightSalmon,
            SKColors.LightPink,
            SKColors.Crimson,
            SKColors.Cyan,
            SKColors.DarkBlue,
            SKColors.DarkCyan,
            SKColors.DarkGoldenrod,
            SKColors.DarkGray,
            SKColors.Cornsilk,
            SKColors.DarkGreen,
            SKColors.DarkMagenta,
            SKColors.DarkOliveGreen,
            SKColors.DarkOrange,
            SKColors.DarkOrchid,
            SKColors.DarkRed,
            SKColors.DarkSalmon,
            SKColors.DarkKhaki,
            SKColors.DarkSeaGreen,
            SKColors.CornflowerBlue,
            SKColors.Chocolate,
            SKColors.AntiqueWhite,
            SKColors.Aqua,
            SKColors.Aquamarine,
            SKColors.Azure,
            SKColors.Beige,
            SKColors.Bisque,
            SKColors.Coral,
            SKColors.Black,
            SKColors.Blue,
            SKColors.BlueViolet,
            SKColors.Brown,
            SKColors.BurlyWood,
            SKColors.CadetBlue,
            SKColors.Chartreuse,
            SKColors.BlanchedAlmond,
            SKColors.Transparent,
            SKColors.DarkSlateBlue,
            SKColors.DarkTurquoise,
            SKColors.IndianRed,
            SKColors.Indigo,
            SKColors.Ivory,
            SKColors.Khaki,
            SKColors.Lavender,
            SKColors.LavenderBlush,
            SKColors.HotPink,
            SKColors.LawnGreen,
            SKColors.LightBlue,
            SKColors.LightCoral,
            SKColors.LightCyan,
            SKColors.LightGoldenrodYellow,
            SKColors.LightGreen,
            SKColors.LemonChiffon,
            SKColors.Honeydew,
            SKColors.Green,
            SKColors.DarkViolet,
            SKColors.DeepPink,
            SKColors.DeepSkyBlue,
            SKColors.DimGray,
            SKColors.DodgerBlue,
            SKColors.Firebrick,
            SKColors.GreenYellow,
            SKColors.FloralWhite,
            SKColors.Fuchsia,
            SKColors.Gainsboro,
            SKColors.GhostWhite,
            SKColors.Gold,
            SKColors.Goldenrod,
            SKColors.ForestGreen
        };

        /// <summary>
        /// 获取验证码图片
        /// </summary>
        /// <param name="code">验证码文本</param>
        /// <returns></returns>
        public static byte[] GetImage(string code)
        {
            return GetImage(new CodeParamter
            {
                Code = code
            });
        }

        /// <summary>
        /// 获取验证码图片
        /// </summary>
        /// <param name="paramter">验证码参数</param>
        /// <returns></returns>
        public static byte[] GetImage(CodeParamter paramter)
        {
            //创建bitmap位图
            using var bitmap = new SKBitmap(paramter.Width, paramter.Height, SKColorType.Bgra8888, SKAlphaType.Premul);
            //创建画布
            using var canvas = new SKCanvas(bitmap);
            //填充背景颜色
            canvas.DrawColor(paramter.BackgroundColor);
            var array = paramter.Code.ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                //将文字写到画布上
                using var paintText = CreatePaint(paramter.Height);
                canvas.DrawText(array[i].ToString(), i * 32 + 1, paramter.Height - 1, paintText);
            }
            DrawInterferenceLine(paramter, canvas);
            //返回图片byte
            using var img = SKImage.FromBitmap(bitmap);
            using var data = img.Encode(paramter.ImageFormat, paramter.ImageQuality);
            return data.ToArray();
        }

        /// <summary>
        /// 画随机干扰线
        /// </summary>
        /// <returns></returns>
        private static void DrawInterferenceLine(CodeParamter paramter, SKCanvas canvas)
        {
            using SKPaint paint = new SKPaint();
            var random = GetRandom();
            for (int i = 0; i < paramter.Line; i++)
            {
                paint.Color = GetColor();
                paint.StrokeWidth = paramter.LineStrokeWidth;
                var x0 = random.Next(0, paramter.Width);
                var y0 = random.Next(0, paramter.Height);
                var x1 = random.Next(0, paramter.Width);
                var y1 = random.Next(0, paramter.Height);
                canvas.DrawLine(x0, y0, x1, y1, paint);
            }
        }

        /// <summary>
        /// 创建画笔
        /// </summary>
        /// <param name="fontSize">画笔大小</param>
        /// <param name="excludeColors">需要排除的颜色</param>
        /// <returns></returns>
        private static SKPaint CreatePaint(float fontSize, SKColor[] excludeColors = null)
        {
            SKPaint paint = new SKPaint
            {
                IsAntialias = true,
                Color = GetColor(excludeColors),
                TextSize = fontSize
            };
            return paint;
        }

        /// <summary>
        /// 获取颜色
        /// </summary>
        /// <param name="excludeColors">需要排除的颜色</param>
        /// <returns></returns>
        private static SKColor GetColor(SKColor[] excludeColors = null)
        {
            return Colors[GetRandom().Next(Colors.Count)];
        }

        private static Random GetRandom()
        {
            return new Random();
        }
    }
}
