using iText.Kernel.Geom;
using iText.Layout.Properties;
using NUnit.Framework;

namespace Sparrow.Export.iTextSharp.Test
{
    /// <summary>
    /// 复杂pdf测试
    /// </summary>
    internal class ComplexTest
    {
        [Test]
        public void Complex()
        {
            using var pdf = new SparrowPdf(PageSize.A4.Rotate());
            pdf.RegisterFont(Common.FontPath);
            pdf.AddTitle(new PdfTitle
            {
                Title = "项目查询"
            });
            var table = new PdfTable();
            var summary = table.AddRow();
            summary.AddCell().SetCellValue("摘要");
            summary.AddCell().SetCellValue("项目查询").SetColspan(5);
            var tag = table.AddRow();
            tag.AddCell().SetCellValue("POST");
            tag.AddCell().SetCellValue("/v1/ZHGDApp/ItemQuery").SetColspan(5);
            var desc = table.AddRow();
            desc.AddCell().SetCellValue("接口说明");
            desc.AddCell().SetCellValue("项目查询").SetColspan(5);
            var path = table.AddRow();
            path.AddCell().SetCellValue("请求路径");
            path.AddCell().SetCellValue("/v1/ZHGDApp/ItemQuery").SetColspan(5);
            var types = table.AddRow();
            types.AddCell().SetCellValue("Content-Type");
            types.AddCell().SetCellValue("application/json-patch+json\rapplication/json\rtext/json\rnapplication/*+json").SetColspan(5);
            var method = table.AddRow();
            method.AddCell().SetCellValue("Method");
            method.AddCell().SetCellValue("POST").SetColspan(5);
            GenerateQueryParamters(table);
            GenerateRequestDemo(table);
            GenerateResponseDemo(table);
            GenerateObjectList(table);
            pdf.AddTable(table);
            pdf.Save(Common.GenerateSavePath("Complex"));
        }

        private static void GenerateQueryParamters(PdfTable table)
        {
            var summary = table.AddRow();
            summary.AddCell().SetCellValue("请求体参数").SetColspan(6);
            var titles = table.AddRow();
            titles.AddCell().SetCellValue("参数名称");
            titles.AddCell().SetCellValue("参数类型");
            titles.AddCell().SetCellValue("长度限制");
            titles.AddCell().SetCellValue("是否必填");
            titles.AddCell().SetCellValue("参数说明");
            titles.AddCell().SetCellValue("备注");
            var paramters = new dynamic[]
            {
                new
                {
                    name = "searchWords",
                    type = "string" ,
                    length = "",
                    required= "false",
                    desc = "搜索关键字",
                    remark = ""
                },
                new
                {
                    name = "searchWords",
                    type = "string" ,
                    length = "",
                    required= "false",
                    desc = "搜索关键字",
                    remark = ""
                },
                new
                {
                    name = "searchWords",
                    type = "string" ,
                    length = "",
                    required= "false",
                    desc = "搜索关键字",
                    remark = ""
                },
                new
                {
                    name = "searchWords",
                    type = "string" ,
                    length = "",
                    required= "false",
                    desc = "搜索关键字",
                    remark = ""
                },
                new
                {
                    name = "searchWords",
                    type = "string" ,
                    length = "",
                    required= "false",
                    desc = "搜索关键字",
                    remark = ""
                }
            };
            foreach (var item in paramters)
            {
                var row = table.AddRow();
                row.AddCell().SetCellValue(item.name);
                row.AddCell().SetCellValue(item.type);
                row.AddCell().SetCellValue(item.length);
                row.AddCell().SetCellValue(item.required);
                row.AddCell().SetCellValue(item.desc);
                row.AddCell().SetCellValue(item.remark);
            }
        }

        private static void GenerateRequestDemo(PdfTable table)
        {
            table.AddRow().AddCell().SetCellValue("请求示例").SetColspan(6);
            var request = table.AddRow();
            request.AddCell().SetCellValue("URL参数");
            request.AddCell().SetCellValue("?code={value}&value={value}&province={value}").SetColspan(5);
        }
        private static void GenerateResponseDemo(PdfTable table)
        {
            table.AddRow().AddCell().SetCellValue("响应示例").SetColspan(6);
            var title = table.AddRow();
            title.AddCell().SetCellValue("状态码");
            title.AddCell().SetCellValue("示例").SetColspan(5);
            var response = table.AddRow();
            response.AddCell().SetCellValue("0");
            response.AddCell().SetCellValue("{\r\n  \"code\": \"value\",\r\n  \"msg\": {},\r\n  \"data\": [\r\n    {\r\n      \"code\": \"value\",\r\n      \"value\": \"value\",\r\n      \"province\": \"value\"\r\n    }\r\n  ],\r\n  \"time\": {},\r\n  \"traceId\": \"value\"\r\n}").SetTextAlignment(TextAlignment.LEFT).SetColspan(5);
        }

        private static void GenerateObjectList(PdfTable table)
        {
            table.AddRow().AddCell().SetCellValue("对象列表").SetColspan(6);
            var list = new dynamic[]
            {
                new
                {
                    name = "searchWords",
                    type = "string" ,
                    length = "",
                    required= "false",
                    desc = "搜索关键字",
                    demo = ""
                },
            };
            for (int i = 0; i < 5; i++)
            {
                var ob = table.AddRow();
                ob.AddCell().SetCellValue("ModelResult").SetRowspan(5);
                for (int j = 0; j < 5; j++)
                {
                    var paramter = table.AddRow();
                    paramter.AddCell().SetCellValue(list[0].name);
                    paramter.AddCell().SetCellValue(list[0].type);
                    paramter.AddCell().SetCellValue(list[0].length);
                    paramter.AddCell().SetCellValue(list[0].required);
                    paramter.AddCell().SetCellValue(list[0].desc);
                }
            }
        }
    }
}
