using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.DataValidation
{
    /// <summary>
    /// 错误信息
    /// </summary>
    public class ModelValidErrorInfo
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 错误提示
        /// </summary>
        public string[] Errors { get; set; }
    }
}
