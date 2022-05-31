using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Sparrow.Export.NPOI.Resources;
using System;
using System.Collections.Generic;
using System.IO;

namespace Sparrow.Export.NPOI
{
    public partial class Excel : IDisposable
    {
        public XSSFWorkbook XSSFWorkbook { get; private set; }

        public Excel()
        {
            var buffer = Convert.FromBase64String(FormatExcel.Excel);
            MemoryStream memory = new MemoryStream();
            memory.Write(buffer, 0, buffer.Length);
            memory.Position = 0;
            XSSFWorkbook = new XSSFWorkbook(memory);
        }

        public Excel(XSSFWorkbook sheets)
        {
            XSSFWorkbook = sheets;
        }

        

        public void Save(string path)
        {
            using var file = File.Create(path);
            XSSFWorkbook.Write(file);
        }


        public void Dispose()
        {
            XSSFWorkbook?.Close();
        }
    }
}
