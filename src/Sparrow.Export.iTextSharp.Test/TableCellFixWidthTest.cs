using iText.Kernel.Geom;
using NUnit.Framework;
using Sparrow.Export.iTextSharp.Components;
using Sparrow.Export.iTextSharp.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow.Export.iTextSharp.Test
{
    /// <summary>
    /// 表格固定宽度测试
    /// </summary>
    public class TableCellFixWidthTest
    {
        [SetUp]
        public void Setup()
        {
            var path = System.IO.Path.Combine(AppContext.BaseDirectory, "resource/simsun.ttc");
            Pdf.Init((c) => { c.RegisterPdfFont(path); });
        }

        [Test]
        public void ExportTableCellFixWidthTest()
        {
            using var pdf = new Pdf(PageSize.A4);
            pdf.AddTable(GetPdfTable());
            pdf.Save(Common.GenerateSavePath("固定表格块宽度"));
            Assert.Pass();
        }

        private static PdfTable GetPdfTable()
        {
            var widths = new float[] { 100, 50, 50, 50, 100, 70, 100, };
            var table = new PdfTable(widths)
            {
                Width = widths.Sum()
            };
            var rows = table.Cells;
            Summary(rows);
            Method(rows);
            Description(rows);
            Path(rows);
            ContentType(rows);
            UrlParams(rows);
            BodyParams(rows);
            ResponseObjects(rows);
            RequestDemo(rows);
            ResponseDemo(rows);
            ObjectList(rows);
            return table;
        }

        private static void ObjectList(List<List<PdfTableCell>> rows)
        {
            rows.Add(new List<PdfTableCell>
            {
                new PdfTableCell("对象列表",1, 7),
            });
            rows.Add(new List<PdfTableCell>
            {
                new PdfTableCell("对象名称" ,1, 2),
                new PdfTableCell("参数名称"),
                new PdfTableCell("参数类型"),
                new PdfTableCell("参数说明" ,1, 2),
                new PdfTableCell("对象名称"),
            });
            var refObjects = new List<dynamic>
            {
                new
                {
                    RefId = "RefId",
                    Params = new List<dynamic>
                    {
                        new
                        {
                            Name = "Name",
                            Type = "Type",
                            Description = "Description",
                            RefId = "RefId"
                        }
                    }
                }
            };
            foreach (var refObject in refObjects)
            {
                var cells = new List<PdfTableCell>
                {
                    new PdfTableCell(refObject.RefId, refObject.Params.Count, 1)
                };
                foreach (var item in refObject.Params)
                {
                    cells.Add(new PdfTableCell(item.Name, 1, 2));
                    cells.Add(new PdfTableCell(item.Type));
                    cells.Add(new PdfTableCell(item.Description, 1, 2));
                    cells.Add(new PdfTableCell(item.RefId));
                }
            }
        }

        private static void ResponseDemo(List<List<PdfTableCell>> rows)
        {
            rows.Add(new List<PdfTableCell>
            {
                new PdfTableCell("响应示例"),
                new PdfTableCell("响应示例响应示例响应示例响应示例",1, 6),
            });
        }

        private static void RequestDemo(List<List<PdfTableCell>> rows)
        {
            rows.Add(new List<PdfTableCell>
            {
                new PdfTableCell("请求示例"),
                new PdfTableCell("?project_name={value}cons_corp_name={value}area_code={value}cons_corp_name={value}area_code={value}cons_corp_name={value}area_code={value}",1, 6).SetIsWordWrap(false),
            });
        }

        private static void ResponseObjects(List<List<PdfTableCell>> rows)
        {
            rows.Add(new List<PdfTableCell>
            {
                new PdfTableCell("响应参数",1, 7),
            });
            rows.Add(new List<PdfTableCell>
            {
                new PdfTableCell("状态码"),
                new PdfTableCell("参数名称",1, 2),
                new PdfTableCell("参数类型"),
                new PdfTableCell("参数说明",1, 2),
                new PdfTableCell("对象名称"),
            });
            var responseObjects = new List<dynamic>
            {
                new
                {
                    Code = "200",
                    Params = new List<dynamic>
                    {
                        new
                        {
                            Name = "Name",
                            Type = "Type",
                            Description = "Description",
                            RefId = "RefId"
                        }
                    }
                }
            };
            foreach (var response in responseObjects)
            {
                var cells = new List<PdfTableCell>
                {
                    new PdfTableCell(response.Code, response.Params.Count, 1)
                };
                foreach (var item in response.Params)
                {
                    cells.Add(new PdfTableCell(item.Name, 1, 2));
                    cells.Add(new PdfTableCell(item.Type));
                    cells.Add(new PdfTableCell(item.Description, 1, 2));
                    cells.Add(new PdfTableCell(item.RefId));
                }
            }
        }

        private static void BodyParams(List<List<PdfTableCell>> rows)
        {
            rows.Add(new List<PdfTableCell>
            {
                new PdfTableCell("请求体参数",1, 7),
            });
            rows.Add(new List<PdfTableCell>
            {
                new PdfTableCell("参数名称"),
                new PdfTableCell("参数类型"),
                new PdfTableCell("长度限制"),
                new PdfTableCell("是否必填"),
                new PdfTableCell("参数说明"),
                new PdfTableCell("备注"),
                new PdfTableCell("对象名称"),
            });
            var bodyParams = new List<dynamic>
            {
                new
                {
                    Name = "Name",
                    Type = "Type",
                    Length = "Length",
                    Required = "Required",
                    Description = "Description",
                    Remark = "Remark",
                    RefId = "RefId"
                }
            };
            foreach (var item in bodyParams)
            {
                rows.Add(new List<PdfTableCell>
                {
                    new PdfTableCell(item.Name),
                    new PdfTableCell(item.Type),
                    new PdfTableCell(item.Length?.ToString()),
                    new PdfTableCell(item.Required?.ToString()),
                    new PdfTableCell(item.Description),
                    new PdfTableCell(item.Remark),
                    new PdfTableCell(item.RefId),
                });
            }
        }

        private static void UrlParams(List<List<PdfTableCell>> rows)
        {
            rows.Add(new List<PdfTableCell>
            {
                new PdfTableCell("URL参数",1, 7),
            });
            rows.Add(new List<PdfTableCell>
            {
                new PdfTableCell("参数名称"),
                new PdfTableCell("参数类型"),
                new PdfTableCell("长度限制"),
                new PdfTableCell("是否必填"),
                new PdfTableCell("参数说明"),
                new PdfTableCell("备注"),
                new PdfTableCell("对象名称"),
            });
            var queries = new List<dynamic>
            {
                new
                {
                    Name = "Name",
                    Type = "Type",
                    Length = "Length",
                    Required = "Required",
                    Description = "Description",
                    Remark = "Remark",
                    RefId = "RefId"
                }
            };
            foreach (var item in queries)
            {
                rows.Add(new List<PdfTableCell>
                {
                    new PdfTableCell(item.Name),
                    new PdfTableCell(item.Type),
                    new PdfTableCell(item.Length?.ToString()),
                    new PdfTableCell(item.Required?.ToString()),
                    new PdfTableCell(item.Description),
                    new PdfTableCell(item.Remark),
                    new PdfTableCell(item.RefId),
                });
            }
        }

        private static void ContentType(List<List<PdfTableCell>> rows)
        {
            rows.Add(new List<PdfTableCell>
            {
                new PdfTableCell("Content-Type"),
                new PdfTableCell("Content-TypeContent-TypeContent-TypeContent-TypeContent-TypeContent-TypeContent-TypeContent-TypeContent-TypeContent-TypeContent-Type",1, 6),
            });
        }

        private static void Path(List<List<PdfTableCell>> rows)
        {
            rows.Add(new List<PdfTableCell>
            {
                new PdfTableCell("请求路径"),
                new PdfTableCell("请求路径请求路径请求路径请求路径请求路径请求路径",1, 6),
            });
        }

        private static void Description(List<List<PdfTableCell>> rows)
        {
            rows.Add(new List<PdfTableCell>
            {
                new PdfTableCell("接口说明"),
                new PdfTableCell( "接口说明接口说明接口说明接口说明接口说明接口说明接口说明",1, 6),
            });
        }

        private static void Method(List<List<PdfTableCell>> rows)
        {
            rows.Add(new List<PdfTableCell>
            {
                new PdfTableCell("Method"),
                new PdfTableCell("Get",1, 6),
            });
        }

        private static void Summary(List<List<PdfTableCell>> rows)
        {
            rows.Add(new List<PdfTableCell>
            {
                new PdfTableCell("摘要"),
                new PdfTableCell("摘要摘要摘要摘要摘要摘要摘要摘要摘要摘要摘要摘要摘要摘要摘要摘要",1, 6)
            });
        }
    }
}
