using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;

namespace Sparrow.Security.JsonWebToken
{
    /// <summary>
    /// jwt解码器
    /// </summary>
    public class DefaultJwtDecoder<T> : IJwtDecoder<T> where T : class, new()
    {
        private readonly IHttpContextAccessor _http;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="http"></param>
        public DefaultJwtDecoder(IHttpContextAccessor http)
        {
            _http = http;
        }

        /// <summary>
        /// 获取令牌
        /// </summary>
        /// <returns></returns>
        public string GetToken()
        {
            var context = _http?.HttpContext;
            if (context == null)
            {
                return default;
            }
            string header = "Authorization";
            context?.Request?.Headers?.TryGetValue(header, out StringValues value);
            var authorization = value.ToString();
            if (string.IsNullOrWhiteSpace(authorization))
            {
                return default;
            }
            if (authorization.StartsWith("Bearer ", true, null))
            {
                authorization = authorization.Remove(0, 7);
            }
            if (string.IsNullOrWhiteSpace(authorization))
            {
                throw new ArgumentException("Invalid token");
            }
            var splits = authorization.Split('.');
            if (splits.Length != 3)
            {
                throw new ArgumentException("Invalid token");
            }
            return splits[1];
        }

        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <returns></returns>
        public T GetCurrentUser()
        {
            var token = GetToken();
            if (string.IsNullOrWhiteSpace(token))
            {
                return default;
            }
            return JsonConvert.DeserializeObject<T>(Base64UrlEncoder.Decode(token));
        }
    }
}
