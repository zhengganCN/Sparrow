using NPOI.OpenXmlFormats.Wordprocessing;
using NPOI.XWPF.UserModel;
using Sparrow.Export.NPOI.Components;
using Sparrow.Export.NPOI.Styles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sparrow.Export.NPOI
{
    /// <summary>
    /// Word表格Cell扩展
    /// </summary>
    public static class WordTableCellExtension
    {
        /// <summary>
        /// 设置文本
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="text"></param>
        public static void SetText(this WordTableCell cell, string text)
        {
            SetText(cell, new List<string> { text }, new WordTextStyle());
        }
        /// <summary>
        /// 设置文本
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="text"></param>
        /// <param name="style"></param>
        public static void SetText(this WordTableCell cell, string text, WordTextStyle style)
        {
            SetText(cell, new List<string> { text }, style);
        }
        /// <summary>
        /// 设置文本
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="texts"></param>
        /// <param name="style"></param>
        public static void SetText(this WordTableCell cell, List<string> texts, WordTextStyle style)
        {
            var ctTc = cell.Cell.GetCTTc();
            for (int i = 0; i < texts.Count; i++)
            {
                CT_P ctP;
                if (ctTc.SizeOfPArray() > i)
                {
                    ctP = ctTc.GetPArray(i);
                }
                else
                {
                    ctP = ctTc.AddNewP();
                }
                var paragraph = new XWPFParagraph(ctP, cell.Cell);
                paragraph.CreateRun().AppendText(texts[i]);
                paragraph.Alignment = style.Alignment;
                paragraph.VerticalAlignment = style.VerticalAlignment;
                cell.Cell.AddParagraph();
            }
            if (ctTc.tcPr == null)
            {
                ctTc.tcPr = ctTc.AddNewTcPr();
            }
            cell.Cell.SetVerticalAlignment(XWPFTableCell.XWPFVertAlign.CENTER);
            ctTc.RemoveP(texts.Count);
        }

        /// <summary>
        /// 处理表格单元格文本，获取按行读取的文本列表
        /// </summary>
        /// <param name="text">文本</param>
        /// <returns></returns>
        internal static string[] HandleTableCellText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return Array.Empty<string>();
            }
            var textLines = new List<string>();
            var bytes = Encoding.UTF8.GetBytes(text);
            using (MemoryStream memory = new MemoryStream(bytes))
            {
                using (StreamReader streamReader = new StreamReader(memory))
                {
                    string line;
                    var index = 0;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        if (index == 0 && string.IsNullOrWhiteSpace(line))
                        {
                            continue;
                        }
                        textLines.Add(line);
                    }
                }
            }
            return textLines.ToArray();
        }

        /// <summary>
        /// 设置表格单元格的宽度
        /// </summary>
        /// <param name="cell">单元格</param>
        /// <param name="width">宽度</param>
        internal static void SetCellWidth(WordTableCell cell, int? width = null)
        {
            CT_TcPr m_Pr = cell.Cell.GetCTTc().AddNewTcPr();
            if (width != null)
            {
                m_Pr.tcW = new CT_TblWidth
                {
                    w = width.ToString(),//单元格宽
                    type = ST_TblWidth.dxa//固定宽度，auto为自动伸缩
                };
            }
        }

        /// <summary>
        /// 向表格单元格追加文本
        /// </summary>
        /// <param name="cell">单元格</param>
        /// <param name="text">文本</param>
        /// <returns></returns>
        internal static void AppendText(WordTableCell cell, string text)
        {
            AddTextNewLine(cell, HandleTableCellText(text));
        }

        /// <summary>
        /// 换行后追加文本
        /// </summary>
        /// <param name="cell">单元格</param>
        /// <param name="lines">文本行</param>
        internal static void AddTextNewLine(WordTableCell cell, string[] lines)
        {
            var paragraph = cell.Cell.AddParagraph();
            for (int i = 1; i < lines.Length; i++)
            {
                XWPFRun xWPFRun = paragraph.CreateRun();
                xWPFRun.SetText(lines[i]);
                if (i != lines.Length - 1)
                {
                    xWPFRun.AddBreak(BreakType.TEXTWRAPPING);
                }
            }
        }

        /// <summary>
        /// 设置单元格背景色
        /// </summary>
        /// <param name="cell">单元格</param>
        /// <param name="color">颜色，十六进制颜色代码</param>
        internal static void SetCellBacogroundColor(WordTableCell cell, string color)
        {
            cell.Cell.SetColor(color);
        }

        /// <summary>
        /// 合并单元格
        /// </summary>
        /// <param name="table">表</param>
        /// <param name="fromCol">合并的起始列，从0开始</param>
        /// <param name="toCol">合并的结束列</param>
        /// <param name="fromRow">合并的起始行，从0开始</param>
        /// <param name="toRow">合并的结束行</param>
        /// <returns>合并后的单元格</returns>
        internal static XWPFTableCell MergeCells(XWPFTable table, int fromCol, int toCol, int fromRow, int toRow)
        {
            for (int rowIndex = fromRow; rowIndex <= toRow; rowIndex++)
            {
                if (fromCol < toCol)
                {
                    table.GetRow(rowIndex).MergeCells(fromCol, toCol);
                }
                XWPFTableCell rowcell = table.GetRow(rowIndex).GetCell(fromCol);
                CT_Tc cttc = rowcell.GetCTTc();
                if (cttc.tcPr == null)
                {
                    cttc.AddNewTcPr();
                }
                if (rowIndex == fromRow)
                {
                    // The first merged cell is set with RESTART merge value  
                    rowcell.GetCTTc().tcPr.AddNewVMerge().val = ST_Merge.restart;
                }
                else
                {
                    // Cells which join (merge) the first one, are set with CONTINUE  
                    rowcell.GetCTTc().tcPr.AddNewVMerge().val = ST_Merge.@continue;
                }
            }
            return table.GetRow(fromRow).GetCell(fromCol);
        }
    }
}
