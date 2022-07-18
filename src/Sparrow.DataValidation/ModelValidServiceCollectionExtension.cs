using Sparrow.DataValidation;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 模型验证扩展
    /// </summary>
    public static class ModelValidServiceCollectionExtension
    {
        /// <summary>
        /// 添加默认格式化错误信息
        /// </summary>
        public static IServiceCollection AddFormatErrors(this IServiceCollection services,
            Action<ModelValidOptions> options)
        {
            options?.Invoke(ModelValidStaticValues.ValidOptions);
            return services;
        }
    }
}
