using Sparrow.DataValidation;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Sparrow.StandardResult
{
    /// <summary>
    /// 输出结果
    /// </summary>
    public class StandardDto : BaseDto<object>, IStandardResultFormat
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="key">标识</param>
        public StandardDto(string key = StandardResultConsts.DefaultKey)
        {
            option = StandardResultValues.StandardResultOptions[key];
        }        
    }
    /// <summary>
    /// 结果模型
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    public class StandardDto<T> : BaseDto<T>, IStandardResultFormat where T : class
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="key">标识</param>
        public StandardDto(string key = StandardResultConsts.DefaultKey)
        {
            option = StandardResultValues.StandardResultOptions[key];
        }
    }
}
