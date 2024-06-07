using Microsoft.AspNetCore.Http;
using Sparrow.Security.JsonWebToken;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// jwt服务集合扩展
    /// </summary>
    public static class SparrowJwtServiceCollectionExtension
    {
        /// <summary>
        /// 添加jwt
        /// </summary>
        /// <typeparam name="TUser">用户实例类型</typeparam>
        /// <param name="services">服务集合</param>
        /// <returns></returns>
        public static IServiceCollection AddDefaultSparrowJwt<TUser>(this IServiceCollection services) where TUser : class, new()
        {
            services.AddSparrowJwt<TUser, DefaultJwtDecoder<TUser>>();
            return services;
        }

        /// <summary>
        /// 添加jwt
        /// </summary>
        /// <typeparam name="TUser">用户实例类型</typeparam>
        /// <typeparam name="TJwtDecoder">jwt解码器实现</typeparam>
        /// <param name="services">服务集合</param>
        /// <returns></returns>
        public static IServiceCollection AddSparrowJwt<TUser, TJwtDecoder>(this IServiceCollection services)
            where TUser : class, new()
            where TJwtDecoder : class, IJwtDecoder<TUser>
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IJwtDecoder<TUser>, TJwtDecoder>();
            services.AddSingleton<SparrowCurrent<TUser>>();
            return services;
        }
    }
}
