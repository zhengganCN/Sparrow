using NPOI.XWPF.UserModel;
using Sparrow.Export.NPOI.Resources;
using System;
using System.IO;

namespace Sparrow.Export.NPOI
{
    /// <summary>
    /// Word
    /// </summary>
    public partial class SparrowWord : IDisposable
    {
        /// <summary>
        /// 文档
        /// </summary>
        public XWPFDocument XWPFDocument { get; private set; }
        /// <summary>
        /// Word
        /// </summary>
        public SparrowWord()
        {
            var buffer = Convert.FromBase64String(FormatWord.WordBase64);
            MemoryStream memory = new MemoryStream();
            memory.Write(buffer, 0, buffer.Length);
            memory.Position = 0;
            XWPFDocument = new XWPFDocument(memory);
            XWPFDocument.Document.body.RemoveTbl(0);
            XWPFDocument.Document.body.RemoveP(0);
        }
        /// <summary>
        /// Word
        /// </summary>
        /// <param name="document">文档</param>
        public SparrowWord(XWPFDocument document)
        {
            XWPFDocument = document;
        }
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="path">路径</param>
        public void Save(string path)
        {
            using (var file = File.Create(path))
            {
                XWPFDocument.Write(file);
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        public byte[] Save()
        {
            byte[] buffer;
            using (var memory = new MemoryStream())
            {
                XWPFDocument.Write(memory);
                memory.Position = 0;
                buffer = new byte[memory.Length];
                memory.Read(buffer, 0, buffer.Length);
            }
            return buffer;
        }

        /// <summary>
        /// 销毁
        /// </summary>
        public void Dispose()
        {
            XWPFDocument?.Close();
        }
    }
}
