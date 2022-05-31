using NPOI.XWPF.UserModel;
using Sparrow.Export.NPOI.Resources;
using System;
using System.IO;

namespace Sparrow.Export.NPOI
{
    public partial class Word : IDisposable
    {
        public XWPFDocument XWPFDocument { get; private set; }

        public Word()
        {
            //var file = File.OpenRead("files/94612b02-880c-48c0-997a-4f3a3ae0d191.doc");
            var buffer = Convert.FromBase64String(FormatWord.WordBase64);
            MemoryStream memory = new MemoryStream();
            memory.Write(buffer, 0, buffer.Length);
            memory.Position = 0;
            XWPFDocument = new XWPFDocument(memory);
            XWPFDocument.Document.body.RemoveTbl(0);
            XWPFDocument.Document.body.RemoveP(0);
        }

        public Word(XWPFDocument document)
        {
            XWPFDocument = document;
        }

        public void Save(string path)
        {
            //XWPFDocument.CreateTOC();
            using var file = File.Create(path);
            XWPFDocument.Write(file);
        }


        public void Dispose()
        {
            XWPFDocument?.Close();
        }
    }
}
