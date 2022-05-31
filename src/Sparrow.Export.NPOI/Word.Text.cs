using Sparrow.Export.NPOI.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.Export.NPOI
{
    public partial class Word
    {
        //private void SetTableProperties(XWPFTable xWPFTable, WordTable table)
        //{
        //    CT_Tbl ctTbl = xWPFTable.GetCTTbl();
        //    //设置表水平居中
        //    var cT_TblPr = ctTbl.AddNewTblPr();
        //    cT_TblPr.jc = new CT_Jc
        //    {
        //        val = table.TableAlign
        //    };
        //    CT_TblLayoutType type = cT_TblPr.AddNewTblLayout();
        //    if (table.Width.HasValue)
        //    {
        //        type.type = ST_TblLayoutType.@fixed;
        //        //设置表宽度
        //        var cT_TblWidth = ctTbl.AddNewTblPr().AddNewTblW();
        //        cT_TblWidth.w = table.Width?.ToString();
        //        cT_TblWidth.type = ST_TblWidth.dxa;
        //    }
        //    else
        //    {
        //        type.type = ST_TblLayoutType.autofit;
        //    }
        //}
        /// <summary>
        /// 创建表格
        /// </summary>
        public void AddText(WordText wordText)
        {
            var paragraph = XWPFDocument.CreateParagraph();
            paragraph.CreateRun().AppendText(wordText.Text);
        }
    }
}
