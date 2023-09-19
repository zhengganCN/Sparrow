using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sparrow.StandardResult.Web
{
    /// <summary>
    /// 
    /// </summary>
    public static class StandardResultWebServiceCollectionExtensions
    {
        /// <summary>
        /// 添加web输出结果
        /// </summary>
        /// <param name="services"></param>
        /// <param name="option">配置项</param>
        /// <returns></returns>
        public static IServiceCollection AddWebStandardResult(this IServiceCollection services, Action<StandardResultWebOptions> option)
        {
            option?.Invoke(StardandResultWeb.StandardResultWebOptions);
            return services;
        }
    }
}
