using SqlSugar;
using System;

namespace Sparrow.Database.SqlSugar.Migrations
{
    /// <summary>
    /// 命名规则
    /// </summary>
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
    /// <summary>
    /// 表字段信息
    /// </summary>
    public class SheetField
    {
        /// <summary>
        /// 字段驼峰名
        /// </summary>
        public string FieldHumpName { get; set; }
        /// <summary>
        /// 字段下划线名
        /// </summary>
        public string FieldSnakeName { get; set; }
        /// <summary>
        /// 字段类型
        /// </summary>
        public Type FieldType { get; set; }
        /// <summary>
        /// 字段列定义
        /// </summary>
        public SugarColumn FieldColumn { get; set; }
        /// <summary>
        /// 获取字段名
        /// </summary>
        /// <param name="naming"></param>
        /// <returns></returns>
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
