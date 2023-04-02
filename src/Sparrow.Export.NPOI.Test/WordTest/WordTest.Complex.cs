using NPOI.XWPF.UserModel;
using NUnit.Framework;
using Sparrow.Export.NPOI.Components;
using Sparrow.Export.NPOI.Enums;
using Sparrow.Export.NPOI.Styles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow.Export.NPOI.Test.WordTest
{
    internal partial class WordTest
    {
        private static int _cols = 7;
        private static readonly WordTextStyle TextStyle = new WordTextStyle
        {
            Alignment = ParagraphAlignment.CENTER,
            VerticalAlignment = TextAlignment.BASELINE,
            FontAlignment = 11
        };
        [Test]
        public void ExportComplexTest()
        {
            using var word = new SparrowWord();
            word.AddTitle("XXXX接口", WordTitleType.Header_2);
            var table = word.AddTable(new WordTableStyle
            {
                Width = 8000
            });
            table.SetColumnWidth(0, 600);
            table.SetColumnWidth(1, 500);            
            var row = table.AddRow();
            row.AddCell().SetText("摘要", TextStyle);
            row.AddCell(_cols - 1).SetText("XXXXXXX接口", TextStyle);
            var row2 = table.AddRow();
            row2.AddCell().SetText("GET", TextStyle);
            row2.AddCell(_cols - 1).SetText("/v1/Bank/QueryRegistrationBank", TextStyle);
            var row3 = table.AddRow();
            row3.AddCell().SetText("接口说明", TextStyle);
            row3.AddCell(_cols - 1).SetText("XXXXXXX接口", TextStyle);
            var row4 = table.AddRow();
            row4.AddCell().SetText("请求路径", TextStyle);
            row4.AddCell(_cols - 1).SetText("/xx/xxxx/xxxxxxxxxxxxx", TextStyle);
            var row5 = table.AddRow();
            row5.AddCell().SetText("Content-Type", TextStyle);
            row5.AddCell(_cols - 1).SetText("Query（附加到URL的参数）", TextStyle);
            var row_cols = table.AddRow();
            row_cols.AddCell().SetText("Method", TextStyle);
            row_cols.AddCell(_cols - 1).SetText("GET", TextStyle);
            GetUrlParamters(table);
            GetBodyParamters(table);
            GetResponseParamters(table);
            GetRequestDemo(table);
            GetResponseDemo(table);
            GetObjects(table);
            if (!Directory.Exists("files"))
            {
                Directory.CreateDirectory("files");
            }
            word.Save();
        }

        private static void GetUrlParamters(WordTable table)
        {
            var title = table.AddRow();
            title.AddCell(_cols).SetText("URL参数", TextStyle);
            var header = table.AddRow();
            header.AddCell().SetText("名称", TextStyle);
            header.AddCell().SetText("类型", TextStyle);
            header.AddCell().SetText("长度", TextStyle);
            header.AddCell().SetText("必填", TextStyle);
            header.AddCell(2).SetText("描述", TextStyle);
            header.AddCell().SetText("示例值", TextStyle);
            var data = new List<string[]>
            {
                new string[] { "pageSize", "int32", "", "true", "每页条数", "" },
                new string[] { "pageSize", "int32", "", "true", "每页条数", "" },
                new string[] { "pageSize", "int32", "", "true", "每页条数", "" }
            };
            foreach (var item in data)
            {
                var row = table.AddRow();
                row.AddCell().SetText(item[0], TextStyle);
                row.AddCell().SetText(item[1], TextStyle);
                row.AddCell().SetText(item[2], TextStyle);
                row.AddCell().SetText(item[3], TextStyle);
                row.AddCell(2).SetText(item[4], TextStyle);
                row.AddCell().SetText(item[5], TextStyle);
            }
        }

        private static void GetBodyParamters(WordTable table)
        {
            var title = table.AddRow();
            title.AddCell(_cols).SetText("请求体参数", TextStyle);
            var header = table.AddRow();
            header.AddCell().SetText("名称", TextStyle);
            header.AddCell().SetText("类型", TextStyle);
            header.AddCell().SetText("长度", TextStyle);
            header.AddCell().SetText("必填", TextStyle);
            header.AddCell(2).SetText("描述", TextStyle);
            header.AddCell().SetText("示例值", TextStyle);
            var data = new List<string[]>
            {
                new string[] { "pageSize", "int32", "10", "true", "每页条数", "" },
                new string[] { "pageSize", "int32", "10", "true", "每页条数", "" },
                new string[] { "pageSize", "int32", "10", "true", "每页条数", "" }
            };
            foreach (var item in data)
            {
                var row = table.AddRow();
                row.AddCell().SetText(item[0], TextStyle);
                row.AddCell().SetText(item[1], TextStyle);
                row.AddCell().SetText(item[2], TextStyle);
                row.AddCell().SetText(item[3], TextStyle);
                row.AddCell(2).SetText(item[4], TextStyle);
                row.AddCell().SetText(item[5], TextStyle);
            }
        }

        private static void GetResponseParamters(WordTable table)
        {
            var title = table.AddRow();
            title.AddCell(_cols).SetText("响应体参数", TextStyle);
            var header = table.AddRow();
            header.AddCell().SetText("名称", TextStyle);
            header.AddCell().SetText("类型", TextStyle);
            header.AddCell().SetText("长度", TextStyle);
            header.AddCell().SetText("必填", TextStyle);
            header.AddCell(2).SetText("描述", TextStyle);
            header.AddCell().SetText("示例值", TextStyle);
            var data = new List<string[]>
            {
                new string[] { "pageSize", "int32", "10", "每页条数", "" },
                new string[] { "pageSize", "int32", "10", "每页条数", "" },
                new string[] { "pageSize", "int32", "10", "每页条数", "" }
            };
            var row = table.AddRow();
            var beginRow = row.RowNum;
            row.AddCell();
            row.AddCell().SetText(data[0][0], TextStyle);
            row.AddCell().SetText(data[0][1], TextStyle);
            row.AddCell().SetText(data[0][2], TextStyle);
            row.AddCell(2).SetText(data[0][3], TextStyle);
            row.AddCell().SetText(data[0][4], TextStyle);
            var endRow = 0;
            for (int i = 1; i < data.Count; i++)
            {
                row = table.AddRow();
                row.AddCell().SetText("", TextStyle);
                row.AddCell().SetText(data[i][0], TextStyle);
                row.AddCell().SetText(data[i][1], TextStyle);
                row.AddCell().SetText(data[i][2], TextStyle);
                row.AddCell(2).SetText(data[i][3], TextStyle);
                row.AddCell().SetText(data[i][4], TextStyle);
                endRow = row.RowNum;
            }
            table.MergeRows(0, beginRow - 1, endRow - 1).SetText("0", TextStyle);
        }

        private static void GetRequestDemo(WordTable table)
        {
            var title = table.AddRow();
            title.AddCell(_cols).SetText("请求示例", TextStyle);
            var header = table.AddRow();
            header.AddCell().SetText("ContentType", TextStyle);
            header.AddCell(_cols - 1).SetText("示例", TextStyle);
            var row = table.AddRow();
            row.AddCell().SetText("json", TextStyle);
            row.AddCell(_cols - 1).SetText("{{\r\n  \"bank_code\": \"value\",\r\n  \"responsible_name\": \"value\",\r\n  \"responsible_phone\": \"value\",\r\n  \"responsible_email\": \"value\"\r\n}}");

        }

        private static void GetResponseDemo(WordTable table)
        {
            var title = table.AddRow();
            title.AddCell(_cols).SetText("响应示例", TextStyle);
            var header = table.AddRow();
            header.AddCell().SetText("状态码", TextStyle);
            header.AddCell(_cols - 1).SetText("示例", TextStyle);
            var row = table.AddRow();
            row.AddCell().SetText("0", TextStyle);
            row.AddCell(_cols - 1).SetText("{{\r\n  \"code\": 199_cols - 1,\r\n  \"msg\": {},\r\n  \"data\": {},\r\n  \"time\": {}\r\n}}", TextStyle);
        }

        private static void GetObjects(WordTable table)
        {
            var title = table.AddRow();
            title.AddCell(_cols).SetText("对象列表", TextStyle);
            var header = table.AddRow(); 
            header.AddCell().SetText("对象类型", TextStyle);
            header.AddCell().SetText("名称", TextStyle);
            header.AddCell().SetText("类型", TextStyle);
            header.AddCell().SetText("长度", TextStyle);
            header.AddCell().SetText("必填", TextStyle);
            header.AddCell().SetText("描述", TextStyle);
            header.AddCell().SetText("示例值", TextStyle);
            var data = new List<string[]>
            {
                new string[] { "pageSize", "int32", "10", "", "每页条数", "1" },
                new string[] { "pageSize", "int32", "10", "", "每页条数", "2" },
                new string[] { "pageSize", "int32", "10", "", "每页条数", "3" }
            };
            var row = table.AddRow();
            var beginRow = row.RowNum;
            row.AddCell();
            row.AddCell().SetText(data[0][0], TextStyle);
            row.AddCell().SetText(data[0][1], TextStyle);
            row.AddCell().SetText(data[0][2], TextStyle);
            row.AddCell().SetText(data[0][3], TextStyle);
            row.AddCell().SetText(data[0][4], TextStyle);
            row.AddCell().SetText(data[0][5], TextStyle);
            var endRow = 0;
            for (int i = 1; i < data.Count; i++)
            {
                row = table.AddRow();
                row.AddCell().SetText("", TextStyle);
                row.AddCell().SetText(data[i][0], TextStyle);
                row.AddCell().SetText(data[i][1], TextStyle);
                row.AddCell().SetText(data[i][2], TextStyle);
                row.AddCell().SetText(data[i][3], TextStyle);
                row.AddCell().SetText(data[i][4], TextStyle);
                row.AddCell().SetText(data[i][5], TextStyle);
                endRow = row.RowNum;
            }
            table.MergeRows(0, beginRow - 1, endRow - 1).SetText("xxxxx", TextStyle);
        }
    }
}
