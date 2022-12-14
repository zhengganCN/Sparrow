using NPOI.XWPF.UserModel;
using NUnit.Framework;
using Sparrow.Export.NPOI.Components;
using System;
using System.Collections.Generic;
using System.IO;

namespace Sparrow.Export.NPOI.Test.WordTest
{
    public class ExportTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ExportWordTest()
        {

            using var word = new SparrowWord();

            word.AddTitle(new WordTitle("1级标题", Enums.EnumTitle.Header_1));
            word.AddTitle(new WordTitle("2级标题", Enums.EnumTitle.Header_2));
            word.AddTitle(new WordTitle("3级标题", Enums.EnumTitle.Header_3));
            word.AddTitle(new WordTitle("4级标题", Enums.EnumTitle.Header_4));
            word.AddTitle(new WordTitle("5级标题", Enums.EnumTitle.Header_5));
            word.AddTitle(new WordTitle("6级标题", Enums.EnumTitle.Header_6));
            word.AddTitle(new WordTitle("7级标题", Enums.EnumTitle.Header_7));
            word.AddTitle(new WordTitle("8级标题", Enums.EnumTitle.Header_8));
            word.AddTitle(new WordTitle("9级标题", Enums.EnumTitle.Header_9));
            word.AddTitle(new WordTitle("标题", Enums.EnumTitle.Title));
            word.AddTitle(new WordTitle("副标题", Enums.EnumTitle.SubTitle));
            word.AddTable(GetWordTable());
            word.AddText(new WordText("\t这是一个文本段"));
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
            word.AddTable(GetLinesCellWordTable());
            if (!Directory.Exists("files"))
            {
                Directory.CreateDirectory("files");
            }
            word.Save(Path.Combine("files", Guid.NewGuid().ToString() + ".doc"));
        }

        [Test]
        public void ExportComplexWordTest()
        {
            using var word = new SparrowWord();
            var rows = 1;
            var cols = 6;
            var table = new WordTable(rows, cols);
            table.Cells[0, 0] = new WordTableCell(new WordText("摘要"));
            var summary = new WordTableCell(new WordText("摘要"))
            {
                Colspan = cols - 1
            };
            table.Cells[0, 1] = summary;

            word.AddTable(table);
            if (!Directory.Exists("files"))
            {
                Directory.CreateDirectory("files");
            }
            word.Save(Path.Combine("files", Guid.NewGuid().ToString() + ".doc"));
        }

        private static WordTable GetWordTable()
        {
            var table = new WordTable(10, 7)
            {
                Width = 8000
            };
            for (int row = 0; row < table.Rows; row++)
            {
                for (int column = 0; column < table.Columns; column++)
                {
                    var wordText = new WordText("测试")
                    {
                        BorderBottom = Borders.Dashed,
                        VerticalAlignment = TextAlignment.CENTER,
                        Alignment = ParagraphAlignment.CENTER
                    };
                    table.Cells[row, column] = new WordTableCell(wordText);
                }
            }
            return table;
        }

        private static WordTable GetLinesCellWordTable()
        {
            var table = new WordTable(10, 7)
            {
                Width = 8000
            };
            for (int row = 0; row < table.Rows; row++)
            {
                for (int column = 0; column < table.Columns; column++)
                {
                    var word = new List<WordText> { new WordText("测试"), };
                    table.Cells[row, column] = new WordTableCell(word);
                }
            }
            return table;
        }


    }
}