using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.Export.NPOI.Components
{
    public class ExcelTable
    {
        public int Rows { get; }
        public int Columns { get; }
        public ExcelCell[,] Cells { get; }
        public int StartRow { get; set; } = 0;
        public int StartColumn { get; set; } = 0;
        /// <summary>
        /// 是否有边框
        /// </summary>
        public bool IsBorder { get; set; } = true;
        public BorderStyle BorderStyle { get; set; } = BorderStyle.Thin;
        public ExcelTable(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Cells = new ExcelCell[Rows, Columns];
        }
        public ExcelCell this[int row, int col]
        {
            get
            {
                return Cells[row, col];
            }
            set
            {
                Cells[row, col] = value;
            }
        }
        public int? Width { get; set; }
        internal ICellStyle BorderTopStyle { get; set; }
        internal ICellStyle BorderLeftStyle { get; set; }
        internal ICellStyle BorderBottomStyle { get; set; }
        internal ICellStyle BorderRightStyle { get; set; }
        internal ICellStyle BorderLeftTopStyle { get; set; }
        internal ICellStyle BorderLeftBottomStyle { get; set; }
        internal ICellStyle BorderRightTopStyle { get; set; }
        internal ICellStyle BorderRightBottomStyle { get; set; }

        private void Init(IWorkbook workbook)
        {
            if (IsBorder)
            {
                if (BorderTopStyle is null)
                {
                    BorderTopStyle = workbook.CreateCellStyle();
                    BorderTopStyle.BorderTop = BorderStyle;
                }
                if (BorderBottomStyle is null)
                {
                    BorderBottomStyle = workbook.CreateCellStyle();
                    BorderBottomStyle.BorderBottom = BorderStyle;
                }
                if (BorderLeftStyle is null)
                {
                    BorderLeftStyle = workbook.CreateCellStyle();
                    BorderLeftStyle.BorderLeft = BorderStyle;
                }
                if (BorderRightStyle is null)
                {
                    BorderRightStyle = workbook.CreateCellStyle();
                    BorderRightStyle.BorderRight = BorderStyle;
                }
                if (BorderLeftTopStyle is null)
                {
                    BorderLeftTopStyle = workbook.CreateCellStyle();
                    BorderLeftTopStyle.BorderTop = BorderStyle;
                    BorderLeftTopStyle.BorderLeft = BorderStyle;
                }
                if (BorderLeftBottomStyle is null)
                {
                    BorderLeftBottomStyle = workbook.CreateCellStyle();
                    BorderLeftBottomStyle.BorderBottom = BorderStyle;
                    BorderLeftBottomStyle.BorderLeft = BorderStyle;
                }
                if (BorderRightTopStyle is null)
                {
                    BorderRightTopStyle = workbook.CreateCellStyle();
                    BorderRightTopStyle.BorderTop = BorderStyle;
                    BorderRightTopStyle.BorderRight = BorderStyle;
                }
                if (BorderRightBottomStyle is null)
                {
                    BorderRightBottomStyle = workbook.CreateCellStyle();
                    BorderRightBottomStyle.BorderRight = BorderStyle;
                    BorderRightBottomStyle.BorderBottom = BorderStyle;
                }

            }
        }

        internal void SetStyle(IWorkbook workbook, ISheet sheet)
        {
            Init(workbook);
            for (int row = 0; row < Rows; row++)
            {
                sheet.GetRow(row + StartRow).GetCell(StartColumn).CellStyle = BorderLeftStyle;
            }
            for (int column = 0; column < Columns; column++)
            {
                sheet.GetRow(StartRow).GetCell(column + StartColumn).CellStyle = BorderTopStyle;
            }
            for (int row = 0; row < Rows; row++)
            {
                sheet.GetRow(row + StartRow).GetCell(Columns + StartColumn - 1).CellStyle = BorderRightStyle;
            }
            for (int column = 0; column < Columns; column++)
            {
                sheet.GetRow(Rows + StartRow - 1).GetCell(column + StartColumn).CellStyle = BorderBottomStyle;
            }
            sheet.GetRow(StartRow).GetCell(StartColumn).CellStyle = BorderLeftTopStyle;
            sheet.GetRow(StartRow + Rows - 1).GetCell(StartColumn).CellStyle = BorderLeftBottomStyle;
            sheet.GetRow(StartRow).GetCell(StartColumn + Columns - 1).CellStyle = BorderRightTopStyle;
            sheet.GetRow(StartRow + Rows - 1).GetCell(StartColumn + Columns - 1).CellStyle = BorderRightBottomStyle;

        }
    }
}
