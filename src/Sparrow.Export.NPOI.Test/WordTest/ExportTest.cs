using NPOI.XWPF.UserModel;
using NUnit.Framework;
using Sparrow.Export.NPOI.Enums;
using Sparrow.Export.NPOI.Styles;
using System;
using System.IO;
using Borders = NPOI.XWPF.UserModel.Borders;

namespace Sparrow.Export.NPOI.Test.WordTest
{
    internal partial class ExportTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ExportWordTest()
        {

            using var word = new SparrowWord();

            word.AddTitle("1������", WordTitleType.Header_1);
            word.AddTitle("2������", WordTitleType.Header_2);
            word.AddTitle("3������", WordTitleType.Header_3);
            word.AddTitle("4������", WordTitleType.Header_4);
            word.AddTitle("5������", WordTitleType.Header_5);
            word.AddTitle("6������", WordTitleType.Header_6);
            word.AddTitle("7������", WordTitleType.Header_7);
            word.AddTitle("8������", WordTitleType.Header_8);
            word.AddTitle("9������", WordTitleType.Header_9);
            word.AddTitle("����", WordTitleType.Title);
            word.AddTitle("������", WordTitleType.SubTitle);
            var table = word.AddTable(new WordTableStyle
            {
                Width = 8000
            });
            for (int r = 0; r < 6; r++)
            {
                var row = table.AddRow();
                for (int c = 0; c < 6; c++)
                {
                    row.AddCell().SetText("����");
                }
            }
            word.AddText("\t����һ���ı���");
            if (!Directory.Exists("files"))
            {
                Directory.CreateDirectory("files");
            }
            word.Save(Path.Combine("files", Guid.NewGuid().ToString() + ".doc"));
        }

        [Test]
        public void ExportLinesCellWordTest()
        {
            using var word = new SparrowWord();
            var table = word.AddTable(new WordTableStyle
            {
                Width = 8000
            });
            var style = new WordTextStyle
            {
                BorderBottom = Borders.Dashed,
                VerticalAlignment = TextAlignment.CENTER,
                Alignment = ParagraphAlignment.CENTER
            };
            for (int r = 0; r < 6; r++)
            {
                var row = table.AddRow();
                for (int c = 0; c < 6; c++)
                {
                    row.AddCell().SetText("����", style);
                }
            }
            if (!Directory.Exists("files"))
            {
                Directory.CreateDirectory("files");
            }
            word.Save(Path.Combine("files", Guid.NewGuid().ToString() + ".doc"));
        }

        [Test]
        public void ExportMergeTest()
        {
            using var word = new SparrowWord();
            var table = word.AddTable();
            var row = table.AddRow();
            row.AddCell().SetText("ժҪ");
            row.AddCell().SetText("ժҪ");
            row.AddCell(2).SetText("ժҪ");
            row.AddCell(3).SetText("ժҪ");
            var row2 = table.AddRow();
            row2.AddCell().SetText("ժҪ");
            row2.AddCell().SetText("ժҪ");
            row2.AddCell().SetText("ժҪ");
            row2.AddCell().SetText("ժҪ");
            row2.AddCell().SetText("ժҪ");
            row2.AddCell().SetText("ժҪ");
            row2.AddCell().SetText("ժҪ");
            var row3 = table.AddRow();
            row3.AddCell().SetText("ժҪ");
            row3.AddCell().SetText("ժҪ");
            row3.AddCell().SetText("ժҪ");
            row3.AddCell().SetText("ժҪ");
            row3.AddCell().SetText("ժҪ");
            row3.AddCell().SetText("ժҪ");
            row3.AddCell().SetText("ժҪ");
            table.MergeRows(2, 1, 2);
            if (!Directory.Exists("files"))
            {
                Directory.CreateDirectory("files");
            }
            word.Save(Path.Combine("files", Guid.NewGuid().ToString() + ".doc"));
        }



    }
}