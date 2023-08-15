using Sparrow.DataValidation;
using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace Sparrow.StandardResult
{
    /// <summary>
    /// 配置项
    /// </summary>
    public class StandardResultOption
    {
        /// <summary>
        /// 设置成功代码，默认值为“200”
        /// </summary>
        public string SuccessCode { get; set; } = StandardResultConsts.SuccessCode;
        /// <summary>
        /// 设置成功信息，默认值为“操作成功”
        /// </summary>
        public string SuccessMessage { get; set; } = StandardResultConsts.SuccessMessage;
        /// <summary>
        /// 设置失败代码，默认值为“-1”
        /// </summary>
        public string FailCode { get; set; } = StandardResultConsts.FailCode;
        /// <summary>
        /// 设置失败信息，默认值为“操作失败”
        /// </summary>
        public string FailMessage { get; set; } = StandardResultConsts.FailMessage;
        /// <summary>
        /// 设置异常代码，默认值为“-2”
        /// </summary>
        public string ExceptionCode { get; set; } = StandardResultConsts.ExceptionCode;
        /// <summary>
        /// 设置异常信息，默认值为“未知错误”
        /// </summary>
        public string ExceptionMessage { get; set; } = StandardResultConsts.ExceptionMessage;
        /// <summary>
        /// 设置模型验证失败代码，默认值为“-3”
        /// </summary>
        public string ModelValidCode { get; set; } = StandardResultConsts.ModelValidCode;
        /// <summary>
        /// 设置模型验证失败信息，默认值为“无效数据”
        /// </summary>
        public string ModelValidMessage { get; set; } = StandardResultConsts.ModelValidMessage;
        /// <summary>
        /// 模型验证错误信息格式化委托
        /// </summary>
        /// <param name="errors"></param>
        /// <returns></returns>
        public delegate object ModelValidFormat(List<ModelValidErrorInfo> errors);
        /// <summary>
        /// 格式化模型验证信息
        /// </summary>
        public ModelValidFormat FormatModelValid { get; set; } = (errors) =>
        {
            return errors;
        };
        /// <summary>
        /// 时间戳格式委托
        /// </summary>
        /// <returns></returns>
        public delegate string TimeFormat();
        /// <summary>
        /// 设置<see cref="BaseDto.Time"/>的值，默认输出时间戳
        /// </summary>
        public TimeFormat Time { get; set; } = () =>
        {
            return ((long)(DateTime.UtcNow - StandardResultValues.DateTime1970).TotalMilliseconds).ToString();
        };
        /// <summary>
        /// <see cref="StandardDto"/>结果格式化委托
        /// </summary>
        /// <param name="standard"></param>
        /// <returns></returns>
        public delegate object StandardDtoFormat(StandardDto standard);
        /// <summary>
        /// <see cref="StandardDto"/>格式化
        /// </summary>
        public StandardDtoFormat FormatStandardDto { get; set; } = (standard) =>
        {
            return standard;
        };
        /// <summary>
        /// <see cref="StandardPagination"/>分页格式化委托
        /// </summary>
        /// <param name="pagination"></param>
        /// <returns></returns>
        public delegate object StandardPaginationDtoFormat(StandardPagination pagination);
        /// <summary>
        /// <see cref="StandardPagination"/>格式化
        /// </summary>
        public StandardPaginationDtoFormat FormatStandardPagination { get; set; } = (pagination) =>
        {
            return pagination;
        };
        /// <summary>
        /// <see cref="StandardDto"/>格式化
        /// </summary>
        public JsonSerializerOptions FormatJsonSerializerOption { get; set; } = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        };
    }
}
