﻿using System;
using System.IO;

namespace Sparrow.Export.iTextSharp.Test
{
    internal class Common
    {
        internal static string FontPath = Path.Combine(AppContext.BaseDirectory, "resource/simsun.ttc");
        /// <summary>
        /// 生成保存路径字符串
        /// </summary>
        /// <returns></returns>
        public static string GenerateSavePath(string name)
        {
            if (!Directory.Exists("pdf"))
            {
                Directory.CreateDirectory("pdf");
            }
            return Path.Combine("pdf", name + DateTime.Now.ToString("yyyyMMddHHmmssfffff") + ".pdf");
        }
    }
}
