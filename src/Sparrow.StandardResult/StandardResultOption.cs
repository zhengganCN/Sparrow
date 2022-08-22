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
        public string SuccessCode { get; set; } = "200";
        /// <summary>
        /// 设置成功信息，默认值为“操作成功”
        /// </summary>
        public string SuccessMessage { get; set; } = "操作成功";
        /// <summary>
        /// 设置失败代码，默认值为“-1”
        /// </summary>
        public string FailCode { get; set; } = "-1";
        /// <summary>
        /// 设置失败信息，默认值为“操作失败”
        /// </summary>
        public string FailMessage { get; set; } = "操作失败";
        /// <summary>
        /// 设置异常代码，默认值为“-2”
        /// </summary>
        public string ExceptionCode { get; set; } = "-2";
        /// <summary>
        /// 设置异常信息，默认值为“未知错误”
        /// </summary>
        public string ExceptionMessage { get; set; } = "未知错误";
        /// <summary>
        /// 设置模型验证失败代码，默认值为“-3”
        /// </summary>
        public string ModelValidCode { get; set; } = "-3";
        /// <summary>
        /// 设置模型验证失败信息，默认值为“无效数据”
        /// </summary>
        public string ModelValidMessage { get; set; } = "无效数据";
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
        /// <see cref="StandardDto"/>格式化委托
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public delegate object DtoFormat(StandardDto dto);
        /// <summary>
        /// <see cref="StandardDto"/>格式化
        /// </summary>
        public DtoFormat FormatDto { get; set; } = (dto) =>
        {
            return dto;
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
