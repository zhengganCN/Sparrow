using System.Collections.Generic;

namespace Sparrow.StandardResult
{
    /// <summary>
    /// 格式化接口
    /// </summary>
    public interface IStandardResultFormat
    {
        /// <summary>
        /// 格式化返回结果
        /// </summary>
        /// <returns></returns>
        object Format();
        /// <summary>
        /// 格式化返回结果
        /// </summary>
        /// <returns></returns>
        object Format(Dictionary<string, object> additional);
    }
}
