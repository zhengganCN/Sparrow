using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.StandardResult
{
    /// <summary>
    /// 常量
    /// </summary>
    public static class StandardResultConsts
    {
        /// <summary>
        /// 默认key值
        /// </summary>
        public const string DefaultKey = "default-sparrow-standard-result";
        /// <summary>
        /// 设置成功代码，默认值为“200”
        /// </summary>
        public const string SuccessCode = "200";
        /// <summary>
        /// 设置成功信息，默认值为“操作成功”
        /// </summary>
        public const string SuccessMessage = "操作成功";
        /// <summary>
        /// 设置失败代码，默认值为“-1”
        /// </summary>
        public const string FailCode = "-1";
        /// <summary>
        /// 设置失败信息，默认值为“操作失败”
        /// </summary>
        public const string FailMessage = "操作失败";
        /// <summary>
        /// 设置异常代码，默认值为“-2”
        /// </summary>
        public const string ExceptionCode = "-2";
        /// <summary>
        /// 设置异常信息，默认值为“未知错误”
        /// </summary>
        public const string ExceptionMessage = "未知错误";
        /// <summary>
        /// 设置模型验证失败代码，默认值为“-3”
        /// </summary>
        public const string ModelValidCode = "-3";
        /// <summary>
        /// 设置模型验证失败信息，默认值为“无效数据”
        /// </summary>
        public const string ModelValidMessage = "无效数据";
    }
}
