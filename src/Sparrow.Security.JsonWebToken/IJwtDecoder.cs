using System.IdentityModel.Tokens.Jwt;

namespace Sparrow.Security.JsonWebToken
{
    /// <summary>
    /// jwt解码器接口
    /// </summary>
    public interface IJwtDecoder
    {
        /// <summary>
        /// 获取令牌
        /// </summary>
        /// <param name="header">header key</param>
        /// <returns></returns>
        string GetToken(string header = "Authorization");
        /// <summary>
        /// 获取Jwt令牌信息
        /// </summary>
        /// <param name="header">header key</param>
        /// <returns></returns>
        JwtToken GetJwtToken(string header = "Authorization");
        /// <summary>
        /// 解码jwt头部数据
        /// </summary>
        /// <param name="header">header key</param>
        /// <returns></returns>
        JwtHeader DecodeHeader(string header = "Authorization");
        /// <summary>
        /// 解码jwt头部数据
        /// </summary>
        /// <typeparam name="T">转换类型</typeparam>
        /// <param name="header">header key</param>
        /// <returns></returns>
        T DecodeHeader<T>(string header = "Authorization") where T : class;
        /// <summary>
        /// 解码jwt载荷
        /// </summary>
        /// <param name="header">header key</param>
        /// <returns></returns>
        JwtPayload DecodePayload(string header = "Authorization");
        /// <summary>
        /// 解码jwt载荷
        /// </summary>
        /// <typeparam name="T">转换类型</typeparam>
        /// <param name="header">header key</param>
        /// <returns></returns>
        T DecodePayload<T>(string header = "Authorization") where T : class;
        /// <summary>
        /// 获取签名数据
        /// </summary>
        /// <param name="header">header key</param>
        /// <returns></returns>
        string GetSignature(string header = "Authorization");

    }
}
