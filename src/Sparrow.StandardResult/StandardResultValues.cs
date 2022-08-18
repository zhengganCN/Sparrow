using System;
using System.Collections.Generic;

namespace Sparrow.StandardResult
{
    /// <summary>
    /// 值
    /// </summary>
    internal static class StandardResultValues
    {
        /// <summary>
        /// 起始时间
        /// </summary>
        internal static readonly DateTime DateTime1970 = new DateTime(1970, 1, 1, 0, 0, 0);
        /// <summary>
        /// 默认key值
        /// </summary>
        internal const string DefaultKey = "default-sparrow-standard-result";
        /// <summary>
        /// 配置项集合
        /// </summary>
        internal static Dictionary<string, StandardResultOption> StandardResultOptions =
            new Dictionary<string, StandardResultOption>
            {
                { DefaultKey, new StandardResultOption() }
            };
    }
}
