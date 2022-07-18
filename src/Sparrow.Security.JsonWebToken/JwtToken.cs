namespace Sparrow.Security.JsonWebToken
{
    /// <summary>
    /// jwt信息
    /// </summary>
    public class JwtToken
    {
        /// <summary>
        /// header
        /// </summary>
        public string Header { get; set; }
        /// <summary>
        /// 载荷
        /// </summary>
        public string Payload { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// 处理token字符串
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static string HandleToken(string token)
        {
            if (token.StartsWith("Bearer ", true, null))
            {
                token = token.Remove(0, 7);
            }
            return token;
        }
    }
}
