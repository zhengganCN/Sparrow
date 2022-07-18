using Microsoft.AspNetCore.Http;
using Sparrow.Security.JsonWebToken;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// jwt解码器服务集合扩展
    /// </summary>
    public static class JwtDecoderServiceCollectionExtension
    {
        /// <summary>
        /// 添加jwt解码器
        /// </summary>
        /// <param name="services">服务集合</param>
        /// <returns></returns>
        public static IServiceCollection AddJwtDecoder(this IServiceCollection services)
        {
            services.AddJwtDecoder<JwtDecoder>();
            return services;
        }
        /// <summary>
        /// 添加jwt解码器
        /// </summary>
        /// <typeparam name="TJwtDecoder">jwt解码器实现</typeparam>
        /// <param name="services">服务集合</param>
        /// <returns></returns>
        public static IServiceCollection AddJwtDecoder<TJwtDecoder>(this IServiceCollection services) where TJwtDecoder : class, IJwtDecoder
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IJwtDecoder, TJwtDecoder>();
            return services;
        }
    }
}
