namespace Sparrow.Security.JsonWebToken
{
    /// <summary>
    /// 当前用户信息
    /// </summary>
    /// <typeparam name="T">用户实例类型</typeparam>
    public class SparrowCurrent<T> where T : class, new()
    {
        private readonly IJwtDecoder<T> _jwt;
        /// <summary>
        /// 当前用户信息
        /// </summary>
        /// <param name="jwt">jwt解码器</param>
        public SparrowCurrent(IJwtDecoder<T> jwt)
        {
            _jwt = jwt;
        }
        /// <summary>
        /// 用户信息
        /// </summary>
        public T User
        {
            get
            {
                return _jwt.GetCurrentUser() ?? new T();
            }
        }
    }
}
