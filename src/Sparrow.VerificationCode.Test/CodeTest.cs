using SkiaSharp;

namespace Sparrow.VerificationCode.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        private static void SaveImage2Disk(CodeParamter param, byte[] bytes)
        {
            var dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            var path = Path.Combine(dir, $"{param.Code}_{Guid.NewGuid()}.{param.ImageFormat.ToString().ToLower()}");
            File.WriteAllBytes(path, bytes);
        }

        /// <summary>
        /// 验证码生成测试
        /// </summary>
        [Test]
        public void GenerateCodeTest()
        {
            var param = new CodeParamter
            {
                Code = "1267",
                Width = 120,
                Height = 30
            };
            var bytes = SparrowVerificationCode.GetImage(param);
            SaveImage2Disk(param, bytes);
            Assert.Pass();
        }

        /// <summary>
        /// 干扰线粗细生成测试
        /// </summary>
        [Test]
        public void GenerateLineStrokeWidthTest()
        {
            var param = new CodeParamter
            {
                Code = "6585",
                Width = 120,
                Height = 30,
                LineStrokeWidth = 4,
            };
            var bytes = SparrowVerificationCode.GetImage(param);
            SaveImage2Disk(param, bytes);
            Assert.Pass();
        }

        /// <summary>
        /// 干扰线数量生成测试
        /// </summary>
        [Test]
        public void GenerateLineTest()
        {
            var param = new CodeParamter
            {
                Code = "6585",
                Width = 120,
                Height = 30,
                Line = 6,
            };
            var bytes = SparrowVerificationCode.GetImage(param);
            SaveImage2Disk(param, bytes);
            Assert.Pass();
        }

        /// <summary>
        /// 图片格式生成测试
        /// </summary>
        [Test]
        public void GenerateImageFormatTest()
        {
            var param = new CodeParamter
            {
                Code = "6585",
                Width = 120,
                Height = 30,
                ImageFormat = SkiaSharp.SKEncodedImageFormat.Png
            };
            var bytes = SparrowVerificationCode.GetImage(param);
            SaveImage2Disk(param, bytes);
            Assert.Pass();
        }

        /// <summary>
        /// 图片质量生成测试
        /// </summary>
        [Test]
        public void GenerateImageQualityTest()
        {
            var param = new CodeParamter
            {
                Code = "6585",
                Width = 120,
                Height = 30,
                ImageQuality = 50
            };
            var bytes = SparrowVerificationCode.GetImage(param);
            SaveImage2Disk(param, bytes);
            Assert.Pass();
        }

        /// <summary>
        /// 背景色生成测试
        /// </summary>
        [Test]
        public void GenerateBackgroundColorTest()
        {
            var param = new CodeParamter
            {
                Code = "6585",
                Width = 120,
                Height = 30,
                BackgroundColor = SKColors.White
            };
            var bytes = SparrowVerificationCode.GetImage(param);
            SaveImage2Disk(param, bytes);
            Assert.Pass();
        }

        /// <summary>
        /// 验证码颜色生成测试
        /// </summary>
        [Test]
        public void GenerateCodeColorsTest()
        {
            var param = new CodeParamter
            {
                Code = "6585",
                Width = 120,
                Height = 30,
                BackgroundColor = SKColors.White,
                CodeColors = new SKColor[]
                {
                    SKColors.Red,
                    SKColors.Green,
                    SKColors.Blue,
                }
            };
            var bytes = SparrowVerificationCode.GetImage(param);
            SaveImage2Disk(param, bytes);
            Assert.Pass();
        }

        /// <summary>
        /// 排除验证码颜色生成测试
        /// </summary>
        [Test]
        public void GenerateExcludeCodeColorsTest()
        {
            var param = new CodeParamter
            {
                Code = "6585",
                Width = 120,
                Height = 30,
                BackgroundColor = SKColors.White,
                ExcludeCodeColors = new SKColor[]
                {
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
                }
            };
            var bytes = SparrowVerificationCode.GetImage(param);
            SaveImage2Disk(param, bytes);
            Assert.Pass();
        }

        /// <summary>
        /// 干扰线颜色生成测试
        /// </summary>
        [Test]
        public void GenerateLineColorsTest()
        {
            var param = new CodeParamter
            {
                Code = "6585",
                Width = 120,
                Height = 30,
                BackgroundColor = SKColors.White,
                LineColors = new SKColor[]
                {
                    SKColors.Red,
                    SKColors.Green,
                    SKColors.Blue,
                }
            };
            var bytes = SparrowVerificationCode.GetImage(param);
            SaveImage2Disk(param, bytes);
            Assert.Pass();
        }

        /// <summary>
        /// 排除干扰线颜色生成测试
        /// </summary>
        [Test]
        public void GenerateExcludeLineColorsTest()
        {
            var param = new CodeParamter
            {
                Code = "6585",
                Width = 120,
                Height = 30,
                BackgroundColor = SKColors.White,
                ExcludeLineColors = new SKColor[]
                {
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
                }
            };
            var bytes = SparrowVerificationCode.GetImage(param);
            SaveImage2Disk(param, bytes);
            Assert.Pass();
        }
    }
}