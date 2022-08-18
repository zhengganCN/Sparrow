﻿using Microsoft.Extensions.DependencyInjection;
using Sparrow.StandardResult;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 输出结果服务扩展
    /// </summary>
    public static class StandardResultServiceCollectionExtensions
    {
        /// <summary>
        /// 添加默认输出结果
        /// </summary>
        /// <param name="services"></param>
        /// <param name="option">配置项</param>
        /// <returns></returns>
        public static IServiceCollection AddDefaultStandardResult(this IServiceCollection services, Action<StandardResultOption> option = null)
        {
            return services.AddStandardResult(StandardResultValues.DefaultKey, option);
        }

        /// <summary>
        /// 添加输出结果
        /// </summary>
        /// <param name="services"></param>
        /// <param name="key">标识</param>
        /// <param name="option">配置项</param>
        /// <returns></returns>
        public static IServiceCollection AddStandardResult(this IServiceCollection services, string key, Action<StandardResultOption> option = null)
        {
            if (!StandardResultValues.StandardResultOptions.ContainsKey(key))
            {
                StandardResultValues.StandardResultOptions.Add(key, new StandardResultOption());
            }
            option?.Invoke(StandardResultValues.StandardResultOptions[key]);
            return services;
        }
    }
}
