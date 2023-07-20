using Microsoft.AspNetCore.Mvc.Filters;
using Sparrow.Monitor.Enums;
using System;

namespace Sparrow.Monitor.Flow
{
    /// <summary>
    /// 接口访问频率限制
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class SparrowAccessFrequencyAttribute : Attribute, IResourceFilter
    {
        internal static AccessFrequency AccessFrequency { get; set; } = new AccessFrequency();
        private readonly uint UnitCount;
        /// <summary>
        /// 访问频率单位,默认值为分钟
        /// </summary>
        public AccessFrequencyUnit Unit { get; set; } = AccessFrequencyUnit.Minite;
        /// <summary>
        /// 访问频率次数,默认值为1800000
        /// </summary>
        public ulong Times { get; set; } = 1800000;
        /// <summary>
        /// 接口访问频率限制
        /// </summary>
        /// <param name="unitCount">单位数量，默认值为1</param>
        /// <remarks>
        /// 当<see cref="Unit"/>为<see cref="AccessFrequencyUnit.Day"/>时，<see cref="UnitCount"/>无效
        /// <br></br>
        /// 例子：如果要限制5秒内可访问100次，则可以设置<see cref="UnitCount"/>为5，<see cref="Unit"/>为<see cref="AccessFrequencyUnit.Seconds"/>，<see cref="Times"/>为100
        /// </remarks>
        public SparrowAccessFrequencyAttribute(uint unitCount = 1)
        {
            if (unitCount == 0)
            {
                new ArgumentException($"{nameof(unitCount)}不能为0");
            }
            UnitCount = unitCount;
        }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var path = context.HttpContext.Request.Path;
            var method = context.HttpContext.Request.Method;
            if (AccessFrequencyCachae.Access(method, path, UnitCount, Unit) > (long)Times)
            {
                context.Result = AccessFrequency.Result;
            }
        }
    }
}
