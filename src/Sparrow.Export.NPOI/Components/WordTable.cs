using NPOI.OpenXmlFormats.Wordprocessing;
using System.Collections.Generic;

namespace Sparrow.Export.NPOI.Components
{
    public class WordTable
    {
        public int Rows { get; }
        public int Columns { get; }
        public WordTableCell[,] Cells { get; }
        public WordTable(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            Cells = new WordTableCell[Rows, Columns];
        }
        public ST_Jc TableAlign { get; set; } = ST_Jc.center;
        public int? Width { get; set; }
    }
}
