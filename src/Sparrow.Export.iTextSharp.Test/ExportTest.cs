using iText.Kernel.Colors;
using iText.Kernel.Geom;
using NUnit.Framework;
using Sparrow.Export.iTextSharp.Components;
using Sparrow.Export.iTextSharp.Enums;
using System;
using System.Collections.Generic;
using System.IO;

namespace Sparrow.Export.iTextSharp.Test
{
    public class ExportTest
    {
        [SetUp]
        public void Setup()
        {
            var path = System.IO.Path.Combine(AppContext.BaseDirectory, "resource/simsun.ttc");
            Pdf.Init((c) => { c.RegisterPdfFont(path); });
        }

        private PdfTable GetPdfTable()
        {
            var headers = new[]
            {
                "���",
                "����",
                "���֤",
                "���",
                "����ʱ��",
                "��һ�ν�������",
                "�Ա�",
                "����",
                "�ֻ�����",
                "���ֵ�λ",
                "��ְ��Ŀ"
            };
            var table = new PdfTable().SetBackgroundColor(new DeviceRgb(232, 246, 240));
            var headerCells = new List<PdfTableCell>();
            foreach (var header in headers)
            {
                var cell = new PdfTableCell(header).SetFontBold(true).SetWidth(50);
                headerCells.Add(cell.Element);
            }
            table.Element.Cells.Add(headerCells);
            for (int row = 0; row < 10; row++)
            {
                var rowCells = new List<PdfTableCell>();
                for (int column = 0; column < headers.Length; column++)
                {
                    rowCells.Add(new PdfTableCell("test"));
                }
                table.Element.Cells.Add(rowCells);
            }
            table.Element.Cells.Add(new List<PdfTableCell>
            {
                new PdfTableCell(2,5,"����ظ�����ظ�����ظ�����ظ�����ظ�����ظ�����ظ�����ظ�����ظ�����ظ�����ظ�"),
                new PdfTableCell(1,6,"����ظ�����"),
                new PdfTableCell(1,6,"����ظ�����")
            });
            table.Element.Cells.Add(new List<PdfTableCell>
            {
                new PdfTableCell(2,11,"����ظ�").SetHeight(100).Element
            });
            return table.Element;
        }

        [Test]
        public void ExportFileTest()
        {
            var sparrow = new SparrowPdfDocument();
            sparrow.SetWaterMark((water) =>
            {
                water.Text = "ˮӡ����";
                water.FontSize = 15;
                water.VerticalWaterMarks = 5;
            });
            sparrow.SetBackgroundColor((color) => { return new DeviceRgb(171, 217, 252); });
            using var pdf = new Pdf(PageSize.A4.Rotate(), sparrow);

            var top1 = pdf.AddTitleWithBookmark(new PdfTitle("����һ", H.H1));
            pdf.AddTitle(new PdfTitle("Top-1-1"), top1);
            var top1child2 = pdf.AddTitle(new PdfTitle("Top-1-2"), top1);
            pdf.AddTitle(new PdfTitle("Top-1-2-1"), top1child2);
            pdf.AddTitleWithBookmark(new PdfTitle("�����", H.H2));
            pdf.AddTitleWithBookmark(new PdfTitle("������", H.H3));
            pdf.AddTitleWithBookmark(new PdfTitle("������", H.H4));
            pdf.AddTitleWithBookmark(new PdfTitle("������", H.H5));
            pdf.AddTitleWithBookmark(new PdfTitle("������", H.H6));
            pdf.AddTable(GetPdfTable());
            pdf.AddTable(GetPdfTable());
            pdf.AddTable(GetPdfTable());
            pdf.AddTable(GetPdfTable());
            pdf.AddTable(GetPdfTable());
            pdf.AddTable(GetPdfTable());
            pdf.AddTable(GetPdfTable());
            pdf.AddTable(GetPdfTable());
            pdf.AddTable(GetPdfTable());
            pdf.AddTable(GetPdfTable());
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
            pdf.AddTable(GetPdfTable());

            pdf.Save();
            Assert.Pass();
        }
    }
}