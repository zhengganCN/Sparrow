using iText.Kernel.Geom;
using NUnit.Framework;

namespace Sparrow.Export.iTextSharp.Test
{
    /// <summary>
    /// 导出文本测试
    /// </summary>
    public partial class TableTest
    {
        [Test]
        public void TextTest()
        {
            using var pdf = new SparrowPdf(PageSize.A4);
            pdf.RegisterFont(Common.FontPath);
            var table = new PdfTable();
            table.AddRow().AddCell().SetCellValue("你好！");
            table.AddRow().AddCell().SetCellValue("！@#￥%……&*（）——+=-");
            table.AddRow().AddCell().SetCellValue("~·？、》。《，“‘：；}】{【、|");
            table.AddRow().AddCell().SetCellValue("*/-+.");
            table.AddRow().AddCell().SetCellValue("0123456789");
            table.AddRow().AddCell().SetCellValue("qwertyuiopasdfghjklzxcvbnm");
            table.AddRow().AddCell().SetCellValue("QWERTYUIOPASDFGHJKLZXCVBNM");
            table.AddRow().AddCell().SetCellValue("A B  C");
            table.AddRow().AddCell().SetCellValue("A B  C").SetEnableSpaceHandle(false);
            pdf.AddTable(table);
            pdf.Save(Common.GenerateSavePath("TextTest"));
        }
    }
}