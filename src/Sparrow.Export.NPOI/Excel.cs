using NPOI.XSSF.UserModel;
using Sparrow.Export.NPOI.Resources;
using System;
using System.IO;

namespace Sparrow.Export.NPOI
{
    /// <summary>
    /// Excel
    /// </summary>
    public partial class Excel : IDisposable
    {
        /// <summary>
        ///  sheets
        /// </summary>
        public XSSFWorkbook XSSFWorkbook { get; private set; }
        /// <summary>
        /// Excel
        /// </summary>
        public Excel()
        {
            var buffer = Convert.FromBase64String(FormatExcel.Excel);
            MemoryStream memory = new MemoryStream();
            memory.Write(buffer, 0, buffer.Length);
            memory.Position = 0;
            XSSFWorkbook = new XSSFWorkbook(memory);
        }
        /// <summary>
        /// Excel
        /// </summary>
        /// <param name="sheets">sheets</param>
        public Excel(XSSFWorkbook sheets)
        {
            XSSFWorkbook = sheets;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="path">路径</param>
        public void Save(string path)
        {
            using (var file = File.Create(path))
            {
                XSSFWorkbook.Write(file);
            }
        }

        /// <summary>
        /// 销毁
        /// </summary>
        public void Dispose()
        {
            XSSFWorkbook?.Close();
        }
    }
}
