namespace Sparrow.Security.JsonWebToken
{
    /// <summary>
    /// jwt解码器接口
    /// </summary>
    public interface IJwtDecoder<T> where T : class, new()
    {
        /// <summary>
        /// 获取令牌
        /// </summary>
        /// <returns></returns>
        string GetToken();
        /// <summary>
        /// 获取当前用户信息
        /// </summary>
        /// <returns></returns>
        T GetCurrentUser();
    }
}
