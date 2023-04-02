using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.XSSF.UserModel;
using NPOI.XWPF.UserModel;
using Sparrow.Export.NPOI.Components;
using Sparrow.Export.NPOI.Styles;

namespace Sparrow.Export.NPOI
{
    public partial class SparrowWord
    {      

        private void SetTableProperties(XWPFTable xWPFTable, WordTableStyle style)
        {
            CT_Tbl ctTbl = xWPFTable.GetCTTbl();
            //设置表水平居中
            var cT_TblPr = ctTbl.AddNewTblPr();
            cT_TblPr.jc = new CT_Jc
            {
                val = style.TableAlign
            };
            CT_TblLayoutType type = cT_TblPr.AddNewTblLayout();
            if (style.Width.HasValue)
            {
                type.type = ST_TblLayoutType.@fixed;
                //设置表宽度
                var cT_TblWidth = ctTbl.AddNewTblPr().AddNewTblW();
                cT_TblWidth.w = style.Width?.ToString();
                cT_TblWidth.type = ST_TblWidth.dxa;
            }
            else
            {
                type.type = ST_TblLayoutType.autofit;
            }
        }       

        /// <summary>
        /// 创建表格
        /// </summary>
        public WordTable AddTable()
        {
            var table = XWPFDocument.CreateTable();
            table.RemoveRow(0);
            return new WordTable { Table = table };
        }

        /// <summary>
        /// 创建表格
        /// </summary>
        public WordTable AddTable(WordTableStyle style)
        {
            var table = XWPFDocument.CreateTable();            
            SetTableProperties(table, style);
            table.RemoveRow(0);
            return new WordTable { Table = table };
        }


    }
}
