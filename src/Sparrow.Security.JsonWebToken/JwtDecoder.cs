using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace Sparrow.Security.JsonWebToken
{

    /// <summary>
    /// jwt解码器
    /// </summary>
    public class JwtDecoder : IJwtDecoder
    {
        private readonly IHttpContextAccessor _http;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="http"></param>
        public JwtDecoder(IHttpContextAccessor http)
        {
            _http = http;
        }

        /// <summary>
        /// 获取令牌
        /// </summary>
        /// <param name="header">header key</param>
        /// <returns></returns>
        public string GetToken(string header = "Authorization")
        {
            var context = _http?.HttpContext;
            if (context != null)
            {
                context?.Request?.Headers?.TryGetValue(header, out StringValues value);
                var authorization = value.ToString();
                if (!string.IsNullOrWhiteSpace(authorization))
                {
                    return JwtToken.HandleToken(authorization);
                }
            }
            return null;
        }

        /// <summary>
        /// 获取Jwt令牌信息
        /// </summary>
        /// <param name="header">header key</param>
        /// <returns></returns>
        public JwtToken GetJwtToken(string header = "Authorization")
        {
            return ConvertJwtToken(GetToken(header));
        }

        /// <summary>
        /// token转JwtToken
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private JwtToken ConvertJwtToken(string token)
        {
            if (!string.IsNullOrWhiteSpace(token))
            {
                var splits = token.Split('.');
                if (splits.Length == 3)
                {
                    return new JwtToken
                    {
                        Header = splits[0],
                        Payload = splits[1],
                        Signature = splits[2]
                    };
                }
            }
            return null;
        }

        /// <summary>
        /// 解码jwt头部数据
        /// </summary>
        /// <param name="header">header key</param>
        /// <returns></returns>
        public JwtHeader DecodeHeader(string header = "Authorization")
        {
            var token = GetToken(header);
            return JwtDataConvert<JwtHeader>(token, EnumDataType.FrameHeaderDecoder);
        }
        /// <summary>
        /// 解码jwt头部数据
        /// </summary>
        /// <typeparam name="T">转换类型</typeparam>
        /// <param name="header">header key</param>
        /// <returns></returns>
        public T DecodeHeader<T>(string header = "Authorization") where T : class
        {
            var token = GetToken(header);
            return JwtDataConvert<T>(token, EnumDataType.SelfHeaderDecoder);
        }
        /// <summary>
        /// 解码jwt载荷
        /// </summary>
        /// <param name="header">header key</param>
        /// <returns></returns>
        public JwtPayload DecodePayload(string header = "Authorization")
        {
            var token = GetToken(header);
            return JwtDataConvert<JwtPayload>(token, EnumDataType.FramePayloadDecoder);

        }
        /// <summary>
        /// 解码jwt载荷
        /// </summary>
        /// <typeparam name="T">转换类型</typeparam>
        /// <param name="header">header key</param>
        /// <returns></returns>
        public T DecodePayload<T>(string header = "Authorization") where T : class
        {
            var token = GetToken(header);
            return JwtDataConvert<T>(token, EnumDataType.SelfPayloadDecoder);
        }
        /// <summary>
        /// 获取签名数据
        /// </summary>
        /// <param name="header">header key</param>
        /// <returns></returns>
        public string GetSignature(string header = "Authorization")
        {
            var token = GetToken(header);
            return GetJwtToken(token)?.Signature;
        }

        /// <summary>
        /// jwt数据序列化
        /// </summary>
        /// <typeparam name="T">序列化类型</typeparam>
        /// <param name="base64">base64</param>
        /// <returns></returns>
        private static T JwtDeserialize<T>(string base64) where T : class
        {
            return JsonSerializer.Deserialize<T>(Base64UrlEncoder.Decode(base64));
        }


        /// <summary>
        /// jwt数据域转换
        /// </summary>
        /// <typeparam name="T">转换类型</typeparam>
        /// <param name="token">令牌</param>
        /// <param name="type">转换方式</param>
        /// <returns></returns>
        private T JwtDataConvert<T>(string token, EnumDataType type) where T : class
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return null;
            }
            var jwtToken = ConvertJwtToken(token);
            if (jwtToken is null)
            {
                return null;
            }
            T result = null;
            switch (type)
            {
                case EnumDataType.FrameHeaderDecoder:
                    result = JwtHeader.Base64UrlDeserialize(jwtToken.Header) as T;
                    break;
                case EnumDataType.FramePayloadDecoder:
                    result = JwtPayload.Base64UrlDeserialize(jwtToken.Payload) as T;
                    break;
                case EnumDataType.SelfHeaderDecoder:
                    result = JwtDeserialize<T>(jwtToken.Header);
                    break;
                case EnumDataType.SelfPayloadDecoder:
                    result = JwtDeserialize<T>(jwtToken.Payload);
                    break;
            }
            return result;
        }

    }
}
