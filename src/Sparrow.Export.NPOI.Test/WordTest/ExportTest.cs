using DocumentFormat.OpenXml.Spreadsheet;
using NPOI.XWPF.UserModel;
using NUnit.Framework;
using Sparrow.Export.NPOI.Components;
using Sparrow.Export.NPOI.Enums;
using Sparrow.Export.NPOI.Styles;
using System;
using System.Collections.Generic;
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

            word.AddTitle("1级标题", WordTitleType.Header_1);
            word.AddTitle("2级标题", WordTitleType.Header_2);
            word.AddTitle("3级标题", WordTitleType.Header_3);
            word.AddTitle("4级标题", WordTitleType.Header_4);
            word.AddTitle("5级标题", WordTitleType.Header_5);
            word.AddTitle("6级标题", WordTitleType.Header_6);
            word.AddTitle("7级标题", WordTitleType.Header_7);
            word.AddTitle("8级标题", WordTitleType.Header_8);
            word.AddTitle("9级标题", WordTitleType.Header_9);
            word.AddTitle("标题", WordTitleType.Title);
            word.AddTitle("副标题", WordTitleType.SubTitle);
            var table = word.AddTable(new WordTableStyle
            {
                Width = 8000
            });
            for (int r = 0; r < 6; r++)
            {
                var row = table.AddRow();
                for (int c = 0; c < 6; c++)
                {
                    row.AddCell().SetText("测试");
                }
            }
            word.AddText("\t这是一个文本段");
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
                    row.AddCell().SetText("测试", style);
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
            row.AddCell().SetText("摘要");
            row.AddCell().SetText("摘要");
            row.AddCell(2).SetText("摘要");
            row.AddCell(3).SetText("摘要");
            var row2 = table.AddRow();
            row2.AddCell().SetText("摘要");
            row2.AddCell().SetText("摘要");
            row2.AddCell().SetText("摘要");
            row2.AddCell().SetText("摘要");
            row2.AddCell().SetText("摘要");
            row2.AddCell().SetText("摘要");
            row2.AddCell().SetText("摘要"); 
            var row3 = table.AddRow();
            row3.AddCell().SetText("摘要");
            row3.AddCell().SetText("摘要");
            row3.AddCell().SetText("摘要");
            row3.AddCell().SetText("摘要");
            row3.AddCell().SetText("摘要");
            row3.AddCell().SetText("摘要");
            row3.AddCell().SetText("摘要");
            table.MergeRows(2, 1, 2);
            if (!Directory.Exists("files"))
            {
                Directory.CreateDirectory("files");
            }
            word.Save(Path.Combine("files", Guid.NewGuid().ToString() + ".doc"));
        }

       

    }
}