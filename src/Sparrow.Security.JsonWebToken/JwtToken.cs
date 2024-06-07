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
    }
}
