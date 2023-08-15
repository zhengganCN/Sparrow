using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
