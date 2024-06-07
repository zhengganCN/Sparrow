using SqlSugar;
using System;

namespace Sparrow.Database.SqlSugar.Migrations
{
    public enum NamingScheme
    {
        /// <summary>
        /// 驼峰
        /// </summary>
        Hump = 1,
        /// <summary>
        /// 下划线
        /// </summary>
        Snake = 2
    }
    public class SheetField
    {
        public string FieldHumpName { get; set; }
        public string FieldSnakeName { get; set; }
        public Type FieldType { get; set; }
        public SugarColumn FieldColumn { get; set; }
        public string GetFieldName(NamingScheme naming = NamingScheme.Hump)
        {
            var name = "";
            switch (naming)
            {
                case NamingScheme.Hump:
                    name = FieldHumpName;
                    break;
                case NamingScheme.Snake:
                    name = FieldSnakeName;
                    break;
            }
            return name;
        }
    }
}
