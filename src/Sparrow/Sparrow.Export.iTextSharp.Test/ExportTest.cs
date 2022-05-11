using iText.Kernel.Geom;
using iText.Layout.Element;
using iText.Layout.Properties;
using NUnit.Framework;
using System;
using System.IO;

namespace Sparrow.Export.iTextSharp.Test
{
    public class ExportTest
    {
        [SetUp]
        public void Setup()
        {
            var path = System.IO.Path.Combine(AppContext.BaseDirectory, "resource/simsun.ttc");
            PdfInitialization.Initialization((c) => { c.RegisterPdfFont(path, "simsun"); });
        }

        private Table GetTable()
        {
            var headers = new[]
            {
                "序号",
                "姓名",
                "身份证",
                "针次",
                "接种时间",
                "下一次接种日期",
                "性别",
                "年龄",
                "手机号码",
                "接种单位",
                "在职项目"
            };
            var table = new Table(headers.Length).SetTextAlignment(TextAlignment.CENTER);
            foreach (var header in headers)
            {
                table.AddHeaderCell(new Cell().Add(new Paragraph(header)).SetBold());
            }
            for (int i = 0; i < 10; i++)
            {
                table.AddCell(new Cell().Add(new Paragraph((i + 1).ToString())));
                table.AddCell(new Cell().Add(new Paragraph("test")));
                table.AddCell(new Cell().Add(new Paragraph("test")));
                table.AddCell(new Cell().Add(new Paragraph("test")));
                table.AddCell(new Cell().Add(new Paragraph("test")));
                table.AddCell(new Cell().Add(new Paragraph("test")));
                table.AddCell(new Cell().Add(new Paragraph("test")));
                table.AddCell(new Cell().Add(new Paragraph("test")));
                table.AddCell(new Cell().Add(new Paragraph("test")));
                table.AddCell(new Cell().Add(new Paragraph("test")));
                table.AddCell(new Cell().Add(new Paragraph("test")));
            }
            return table;
        }

        [Test]
        public void ExportFileTest()
        {
            using var pdf = new Pdf(PageSize.A4);
            
            pdf.Document.Add(GetTable());
            if (!Directory.Exists("pdf"))
            {
                Directory.CreateDirectory("pdf");
            }
            var tempPdfFileName = System.IO.Path.Combine("pdf", Guid.NewGuid().ToString() + ".pdf");
            pdf.Save(tempPdfFileName);
            Assert.Pass();
        }

        [Test]
        public void ExportBytesTest()
        {
            using var pdf = new Pdf(PageSize.A4);
            pdf.Document.Add(GetTable());
            pdf.Save();
            Assert.Pass();
        }
    }
}