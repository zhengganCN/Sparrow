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
        internal static DateTime DateTime1970 { get; set; } = new DateTime(1970, 1, 1, 0, 0, 0);
        /// <summary>
        /// 配置项集合
        /// </summary>
        internal static Dictionary<string, StandardResultOption> StandardResultOptions { get; set; } =
            new Dictionary<string, StandardResultOption>
            {
                { StandardResultConsts.DefaultKey, new StandardResultOption() }
            };
    }
}
