using NPOI.SS.UserModel;

namespace Sparrow.Export.NPOI.Components
{
    /// <summary>
    /// Excel表格
    /// </summary>
    public class ExcelTable
    {
        /// <summary>
        /// 行数量
        /// </summary>
        public int Rows { get; }
        /// <summary>
        /// 列数量
        /// </summary>
        public int Columns { get; }
        /// <summary>
        /// Excel Cell
        /// </summary>
        public ExcelCell[,] Cells { get; }
        /// <summary>
        /// 起始行索引，从0开始
        /// </summary>
        public int StartRow { get; set; } = 0;
        /// <summary>
        /// 起始列索引，从0开始
        /// </summary>
        public int StartColumn { get; set; } = 0;
        /// <summary>
        /// 是否有边框
        /// </summary>
        public bool IsBorder { get; set; } = true;
        /// <summary>
        /// 边框样式
        /// </summary>
        public BorderStyle BorderStyle { get; set; } = BorderStyle.Thin;
        /// <summary>
        /// Excel表格
        /// </summary>
        /// <param name="rows">行数</param>
        /// <param name="columns">列数</param>
        public ExcelTable(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Cells = new ExcelCell[Rows, Columns];
        }
        /// <summary>
        /// 索引
        /// </summary>
        /// <param name="row">行索引，从0开始</param>
        /// <param name="col">列索引，从0开始</param>
        /// <returns></returns>
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
        /// <summary>
        /// 表格宽度
        /// </summary>
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
