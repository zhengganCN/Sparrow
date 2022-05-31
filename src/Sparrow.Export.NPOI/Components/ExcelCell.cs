using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.Export.NPOI.Components
{
    public class ExcelCell
    {
        public string Value { get; private set; }
        public ExcelCell(string value)
        {
            Value = value;
        }
    }
}
